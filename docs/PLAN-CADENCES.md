# PLAN — Réguas (cadences) como relógio que emite eventos

Estado: **proposta em discussão com o dono (27/10/2026)**. Nada deste plano foi implementado ainda.
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

## Decisões em aberto (para a próxima conversa)
1. Chaves de marco livres por régua, ou vocabulário comum para um módulo configurar uma vez e valer para várias réguas?
2. Quem decide qual régua um assunto usa: o módulo dono (ex.: Vendas por tipo de serviço) — confirmar.
3. Casos abertos seguem a versão em que começaram (padrão Recurly) — confirmar.
4. Notificações: um evento genérico "marco de régua" com a inscrição carregando régua:marco — servirá para testar os
   lembretes antes de decidir se o canal oficial será esse.
5. Marco atrasado (sistema fora do ar no dia): emitir assim que voltar (com a data original) ou pular?
6. `MoveAnchor` (renegociação de vencimento): recalcula marcos futuros e mantém os já emitidos — confirmar.
