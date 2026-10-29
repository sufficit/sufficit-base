# PLAN — Réguas (cadences) como relógio que emite eventos

Estado: **fase 1 (núcleo, só simulação) no ar em 27/10/2026**; fases 2 e 3 pendentes.
Benchmark de mercado: [RESEARCH-CADENCES-MARKET.md](RESEARCH-CADENCES-MARKET.md).

## Por que revisar
A primeira versão (no ar desde 27/10, `Sufficit.Cadences`, tabelas `intranet.cadn_*`, tela `/pages/cadences`) colocou no
núcleo coisas que são dos módulos: catálogo fixo de ações (`CadenceActions`), tipos de alvo (`CadenceTargetTypes`),
condições (`CadenceConditions`), módulos (`CadenceModules`) e semântica de efeito (restrição, irreversível,
"pagamento desfaz"). O dono rejeitou: **toda régua deve gerar eventos de sistema, e cada módulo sabe o que fazer com o
evento; a configuração do que fazer não é responsabilidade da régua. No front pode facilitar; no back as
responsabilidades são distintas.**

## Princípio
**Régua = relógio.** Ela sabe contar dias a partir de uma data e avisar que um marco chegou. Não sabe o que é contrato,
Hermes, notificação, bloqueio ou pagamento.

## Modelo do núcleo (Base + EFData + API)
- **Régua** (`Cadence`): id, nome, descrição, situação (rascunho, ativa, aposentada), versão, histórico de revisões com
  autor e motivo.
- **Marco** (`CadenceMilestone`): chave estável (ex.: `lembrete`, `alerta`, `bloqueio`, `suspensao`, `encerramento`),
  rótulo e dias em relação ao D0 (negativo = antes). Sem ação, sem público, sem canal.
- **Caso** (`CadenceCase`): uma instância da régua para um assunto. Campos: régua, versão em que começou, assunto
  (tipo + id **opacos**), cliente (contextId), data D0, situação (aberto, encerrado), motivo do encerramento.
  - **Quem abre e encerra é o módulo dono do assunto** (ex.: Vendas abre quando o período do contrato tem vencimento e
    encerra quando é pago). O núcleo não consulta contratos.
- **Ocorrência** (`CadenceOccurrence`): registro durável e idempotente de cada marco atingido por caso
  (chave = caso + marco), com estado de entrega por assinante.

### Comandos e eventos
| Comando (módulo → régua) | Evento (régua → todos) |
|---|---|
| `OpenCase(cadence, subjectType, subjectId, contextId, anchorDate)` | `cadence.case.opened` |
| (tique diário) | `cadence.milestone.reached` — régua, versão, marco, caso, assunto, cliente, D0, data do marco |
| `CloseCase(case, reason)` | `cadence.case.closed` — motivo (ex.: `resolved`, `cancelled`) |
| `MoveAnchor(case, newDate)` (ex.: renegociação) | `cadence.case.rescheduled` |

- Tique diário: worker no sufficit-background chama `Cadences/Run` no endpoints (mesmo padrão da automação recorrente).
- Entrega: tabela durável de ocorrências + entrega por assinante com lease e nova tentativa (mesmo padrão de
  `sals_integration_events`/`sals_event_deliveries`); um worker no endpoints publica no `IEventBus` em memória para os
  handlers dos módulos. O `IEventBus` sozinho não serve (descarta quando cheio e perde em reinício).
- Hermes não recebe push hoje: o snapshot de pré-pago passa a expor os marcos atingidos do caso (pull que já existe).

## Responsabilidade de cada módulo (configuração e efeito no próprio módulo)
| Módulo | Configura (no próprio banco/API) | Ao receber o evento |
|---|---|---|
| Vendas | por tipo de serviço: qual régua abre o caso; marco → encerrar contrato | abre/encerra casos; encerra contrato |
| Notificações | inscrição no evento "marco de régua" (chave régua:marco), contatos e template | envia mensagem pelo fluxo existente (RabbitMQ/exchange) |
| Hermes | marco → estado da conta (alerta, bloqueado, suspenso, exclusão) | aplica; em `case.closed` reativa |
| Telefonia | marco → bloqueio de saída/entrada, liberar número | aplica; em `case.closed` desfaz |
| Atividades | marco → abrir revisão | cria atividade (idempotente por evento) |

Regras de negócio que saem do núcleo e vão para o módulo: "pular se tem pagamento automático" (Notificações/Vendas),
"pagamento desfaz restrição" (cada módulo reagindo a `case.closed`), "excluir exige exportar antes" (Hermes).

## Front (composição, não regra)
- Editor da régua: nome, marcos no eixo de dias, versão/histórico.
- Em cada marco, painel "o que acontece aqui", montado consultando a configuração de cada módulo; editar dali grava na
  API do módulo, não na régua.
- Simulação: mostra datas dos marcos para um D0 e, por módulo, o que cada um faria (cada módulo pode expor um "preview").

## O que muda no que está no ar
- Sai do Base: `CadenceActions`, `CadenceTargetTypes`, `CadenceConditions`, `CadenceModules`, `CadenceAnchors`,
  `CadenceAudience`, `CadenceActionCategory`, `CadenceStep.Action/Audience/Channels/Condition/Parameters`,
  `Cadence.Module/Kind/Anchor/RestoreOnResolution`, `CadenceTarget`, `Resolve`.
- Entra: `CadenceMilestone`, `CadenceCase`, `CadenceOccurrence`, contratos de evento, comandos de caso.
- Régua da Hermes migra para marcos `lembrete` (-3), `alerta` (0), `bloqueio` (+1), `suspensao` (+5),
  `encerramento` (+30); os efeitos passam a ser configuração de Vendas, Notificações e Hermes.
- Executor continua **somente em simulação** até o dono liberar (decisão de 27/10).

## Decisões (27/10/2026)
O dono definiu o item 1 e delegou os demais ("confio no teu julgamento"); justificativas na pesquisa.

1. **Nomes dos marcos vêm dos módulos.** Interface `ICadenceMilestoneSource` (Base): cada módulo injeta, via DI, os
   marcos que entende (`CadenceMilestoneDefinition`: chave `<módulo>.<nome>`, título, descrição, módulo). O runtime
   agrega todas as fontes e a API expõe `GET Cadences/Milestones`. A régua só aceita chaves do catálogo. Vários marcos
   podem cair no mesmo dia (ex.: D+1 `hermes.block` e `telephony.outbound-block`).
2. **Quem escolhe a régua de um assunto é o módulo dono** (ex.: Vendas guarda, por tipo de serviço, qual régua abre o
   caso). A régua não tem alvos.
3. **Caso fica preso à versão em que abriu**: no `OpenCase` grava-se a cópia dos marcos daquela versão (padrão Recurly).
   Editar a régua só afeta casos novos.
4. **Notificações**: um evento genérico "marco de régua" no sistema de notificações, com chave `régua:marco`; a
   inscrição de contatos/template fica em Notificações. Serve para testar lembretes antes de oficializar o canal.
5. **Marco atrasado** (sistema fora no dia): é emitido assim que o tique voltar, com a data original e `Late = true`;
   o consumidor decide se ainda age. Caso encerrado nunca emite.
6. **Mudança de D0** (`MoveAnchor`): recalcula só os marcos ainda não emitidos; os já emitidos ficam. Se a nova data
   deixar marcos no passado, eles saem no próximo tique como atrasados.
8. **Assunto da régua (dono, 27/10):** cada módulo declara os tipos de assunto para os quais abre casos
   (`ICadenceMilestoneSource.GetSubjects`, ex.: Vendas `sales.contract-period`, Telefonia `telephony.did`) e, em cada
   marco, sobre quais assuntos atua (`CadenceMilestoneDefinition.SubjectTypes`; vazio = qualquer). A régua tem
   `SubjectType`: o editor só oferece marcos compatíveis e ainda não usados; salvar e abrir caso validam. Evita, por
   exemplo, "bloquear saída da Telefonia" numa régua de hospedagem Hermes, que nunca teria efeito.
7. **Um período = um caso.** Novo vencimento abre novo caso; não se reabre caso encerrado.

## Fases
1. **Núcleo — FEITO 27/10/2026 (só simulação)**: modelo de marcos e casos no Base; catálogo injetável; EFData com casos e
   ocorrências idempotentes; runtime com `OpenCase/CloseCase/MoveAnchor/Run`, publicando os eventos no `IEventBus` sem
   handlers de efeito; API; tela nova (régua = nome + marcos do catálogo no eixo, casos abertos e ocorrências).
   Migra a régua da Hermes para marcos.
2. **Entrega durável** por assinante (outbox) + tique diário no sufficit-background.
3. **Consumidores**: Vendas abre/encerra casos por tipo de serviço; Notificações (evento genérico); Hermes via snapshot;
   Telefonia; Atividades. Cada um com sua configuração e tela, compostas no editor da régua.

## Fase 1 — o que está no ar (27/10/2026)
- Base `Sufficit.Cadences`: `Cadence`, `CadenceMilestone`, `CadenceMilestoneDefinition`, `ICadenceMilestoneSource`,
  `CadenceCase`, `CadenceOccurrence`, eventos (`CadenceCaseOpenedEvent`, `CadenceMilestoneReachedEvent`,
  `CadenceCaseClosedEvent`, `CadenceCaseRescheduledEvent`), `CadenceSchedule`, `CadenceValidator`, `ICadenceStore`.
- EFData: `cadn_cadences`, `cadn_milestones`, `cadn_cases`, `cadn_occurrences`, `cadn_revisions`; migração
  `migrations/sql/Cadences/202610272000-cadences-milestones.sql` aplicada em produção.
- Standard: `CadencesRuntime` (catálogo agregado, casos, tique `Run`, eventos no `IEventBus`; `Cadences:Simulation`
  padrão `true`). Marcos registrados por Vendas, Telefonia e Notificações; Hermes no endpoints.
- Endpoints `Cadences`: `Milestones`, CRUD, `Cases/Search|Open|Close|Move|Occurrences`, `Run` (administrador).
- Blazor `/pages/cadences`: marcos do catálogo com o módulo dono e a reação descrita pelo módulo; abas Marcos,
  Simular, Casos (caso de teste + tique em simulação) e Histórico.
- Ainda não há tique automático nem consumidores: nenhum módulo abre casos sozinho nem aplica efeitos.

## Réguas cadastradas (27/10/2026)
| Régua | Assunto | Marcos | Situação |
|---|---|---|---|
| Régua de corte — Hospedagem Hermes | `sales.contract-period` | D-3 lembrete de pagamento (Vendas; pula com pagamento automático) · D0 alerta (Hermes) · D+1 bloquear acesso · D+5 suspender · D+30 encerrar contrato (Vendas) + exportar/arquivar/excluir (Hermes) | Ativa (simulação) |
| Régua de cobrança — DIDs (tronco de entrada) | `telephony.did` | D0 aviso de cobrança · D+3 bloquear entrada (0800 direto; fixo/móvel 3 dias após a leitura confirmada) · D+90 revisão e aviso final (+ lembrete ao gestor a cada 7 dias) · D+182 fim da quarentena / revisão de liberação | Rascunho |
| Recarga obrigatória — restauração das tarifas | `telephony.recharge-cycle` | D-5 lembrete (se faltar recarga) · D0 avaliar ciclo (cumprido encerra o caso) · D+3 restaurar tarifas padrão (não cumprido; inconclusivo vira revisão) | Rascunho |

Origem das regras: Hermes = `sufficit-endpoints/docs/PLAN-HERMES-DUNNING.md`; DIDs = `DidCollectionPolicy` 2026-10-01
(o lembrete a cada 7 dias e a contagem a partir da leitura ficam na Telefonia, a régua só marca os dias; 6 meses
aproximados para 182 dias); recarga = `CallCreditCommitment` (a restauração de tarifas ainda é ação manual pendente; a
tolerância de 3 dias é proposta, para créditos ainda não entregues).

## Recorrente pré-pago (dono, 29/10/2026)
Serviço recorrente é **pré-pago**: renova automaticamente todo mês **desde que haja pagamento**, que renova o mês seguinte.
Pós-pago só para avulsos (ex.: Suporte do Chat de R$ 750). Consequências para as réguas:
- **D0 = fim da cobertura** (vencimento sem pagamento). Caso **por serviço** (a cobertura é por serviço), aberto por Vendas.
  - Legado: snapshot `migration.legacy_renewal_snapshot_v1` com `Renewed=false` e `End` (−3 h) antes de hoje; a equipe
    renova após o pagamento → fecha o caso.
  - Nativo: o período é debitado no início, pago ou não; caso abre quando o débito do período não está coberto
    (saldo negativo pela regra de `sufficit-endpoints/docs/CUSTOMER-DEBT.md`) e fecha quando o crédito cobre.
- **Não reclassificar `settlement_model`.** No código, `Prepaid` significa "cobertura só após recebimento confirmado"
  (prepaid grants): mudar os 1.413 recorrentes tiraria os nativos da automação mensal (sem períodos nem débitos). O campo
  segue `Postpaid` = "ciclo debitado no início"; a régua usa a cobertura/saldo, não esse campo.
- Valor mínimo de cobrança (R$ 10 + ½ mês) só se aplica ao pós-pago/saldo residual.

Simulação 29/10 (legado, cobertura vencida sem renovação): 85 serviços de 52 clientes, R$ 3.707/ciclo — 55 DIDs
(44 clientes; 6 em D+0..2 = só aviso; 49 em D+3..30 = bloqueio de entrada), 28 troncos tarifados/compartilhados,
2 outros. Nenhum além de D+30.
