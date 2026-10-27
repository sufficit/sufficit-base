# Pesquisa — réguas (cadences) em outros sistemas

Pesquisa feita em 27/10/2026 para orientar a revisão do modelo de réguas
(ver [PLAN-CADENCES.md](PLAN-CADENCES.md)). Foco: **quem conta o tempo**, **quem decide a ação** e **como o resto do
sistema fica sabendo**.

## Resumo do que se repete
1. **O tempo é relativo a uma data do assunto** (vencimento, falha de pagamento, data de evento) e os marcos são
   "N dias antes/depois" — inclusive negativos (Odoo, Stripe "invoice due date upcoming", Salesforce "10 dias antes").
2. **O caso termina sozinho quando o assunto se resolve** (fatura paga/anulada encerra a automação no Stripe; pagamento
   leva a conta de volta ao estado `CLEAR` no Kill Bill).
3. **Mudança de versão não afeta casos em andamento** (Recurly: "changes to a campaign won't affect invoices already in
   dunning").
4. **Os sistemas maduros separam "estado/marco" de "efeito"**: o Kill Bill calcula o estado de inadimplência e publica
   `OVERDUE_CHANGE`; plugins e o próprio sistema de assinaturas reagem. Stripe e Chargebee expõem o marco como evento
   (webhook) para quem quiser agir fora do produto.
5. **Os produtos "tudo em um" misturam marco e ação** (Odoo follow-up levels, ERPNext dunning type, Stripe automations com
   ações embutidas). Funcionam bem dentro de um único módulo de cobrança, mas não servem para vários módulos donos de efeitos.
6. **Um único fluxo por evento**: no Stripe, várias automações para o mesmo gatilho são avaliadas por prioridade e só a
   primeira que casa roda — equivalente ao nosso "uma régua ativa por alvo".

## Sistemas

### Kill Bill (billing open source) — o modelo mais próximo do que queremos
- Estados de inadimplência declarados em `overdue.xml`, cada um com condição (ex.:
  `timeSinceEarliestUnpaidInvoiceEqualsOrExceeds`) e reavaliação periódica (`autoReevaluationInterval`).
- O estado só **descreve** efeitos (`blockChanges`, `disableEntitlementAndChangesBlocked`,
  `subscriptionCancellationPolicy`, `externalMessage`); quem aplica é o módulo de entitlement/assinatura.
- Transições viram evento **`OVERDUE_CHANGE`** no barramento; plugins de notificação reagem. Também dá para consultar o
  estado atual por API (`GET /accounts/{id}/overdue`).
- Pagamento reavalia e volta para `CLEAR`.
- Lição: **estado + evento + consumidores**; o motor de inadimplência não manda e-mail nem bloqueia nada sozinho.

### Stripe Billing — Automations
- Workflow = **gatilho** (ex.: "invoice due date upcoming", "invoice overdue", "subscription payment fails") +
  **filtros** (metadados, valor, produto) + **sequência de ações e esperas**.
- Termina automaticamente quando a fatura é paga/anulada.
- Uma das ações é **emitir um webhook agendado** (`invoice.will_be_due`) — ou seja, o próprio Stripe reconhece que
  muitas vezes a ação certa é "avise o sistema do cliente e deixe ele decidir".
- Prioridade entre automações do mesmo gatilho; só uma executa.

### Chargebee
- Dunning com tentativas configuradas; cada tentativa falha gera `payment_failed`; a última traz
  `dunning_status = exhausted`, que é o marco "fim da régua".
- A consequência final (cancelar ou manter a assinatura; anular/baixar a fatura) é configuração separada.

### Recurly
- "Dunning campaigns": ciclos com agenda e e-mails, campanhas diferentes por plano/conta (alvo mais específico).
- Webhook de dunning para quem quer responder programaticamente sem usar os e-mails nativos.
- Versão da campanha não altera casos já em andamento.

### Odoo (follow-up levels) e ERPNext (dunning)
- Níveis com "N dias após o vencimento" (aceita negativo para lembrete antes), e o nível carrega a ação (e-mail, carta,
  SMS, tarefa manual).
- Bom para um módulo só; acopla prazo e ação — é o desenho que estamos abandonando.

### Salesforce (time-based workflow)
- Ações agendadas relativas a uma data do registro ("10 dias antes do fechamento"), fila visível de ações pendentes.
- Tempo de disparo em lote (atrasos de minutos) — aceitável para régua diária.

### Customer.io / Braze (jornadas)
- Gatilho por data de um atributo ("important date") com deslocamento em dias; a comunidade Braze resolve "um dia antes"
  com um evento intermediário que dispara outra campanha — de novo, **marco vira evento** e o consumidor decide.

### Temporal / AWS EventBridge Scheduler (infraestrutura de tempo)
- Temporal: timers duráveis persistidos no servidor (dias ou meses), sobrevivem a quedas — mostra que o relógio precisa
  ser **durável**, não `sleep` em memória.
- EventBridge Scheduler: agendamento único `at(...)` que entrega um evento a um alvo com precisão de ~60 s.
- Para nós, um tique diário com registro durável cobre o caso de uso (marcos em dias) sem nova infraestrutura.

## O que adotamos
| Decisão | Inspiração |
|---|---|
| Régua só conta tempo e emite eventos de marco | Kill Bill `OVERDUE_CHANGE`, webhooks do Stripe/Recurly |
| Cada módulo configura e aplica o próprio efeito | Kill Bill (entitlement aplica o bloqueio), plugins |
| Caso encerra quando o assunto se resolve, com evento de encerramento | Stripe (fatura paga encerra), Kill Bill `CLEAR` |
| Caso segue a versão em que começou | Recurly |
| Alvo mais específico vence; uma régua por gatilho/alvo | Recurly (campanha por plano/conta), Stripe (prioridade) |
| Registro durável e idempotente dos marcos | Temporal (timers duráveis) |

## Fontes
- Kill Bill — Overdue: https://docs.killbill.io/latest/overdue.html
- Kill Bill — relato de comunidade sobre estados intermediários: https://groups.google.com/g/killbilling-users/c/9dWcSDBcZoI
- Stripe — Billing automations: https://docs.stripe.com/billing/automations
- Stripe — Revenue recovery: https://stripe.com/en-hu/docs/billing/revenue-recovery
- Chargebee — fim do período de dunning: https://chargebee.com/docs/1.0/payments/articles-and-faq/which-event-marks-the-closing-of-the-dunning-period.html
- Chargebee — dunning: https://www.chargebee.com/docs/payments/2.0/dunning.html
- Recurly — dunning management: https://docs.recurly.com/docs/dunning-management
- Recurly — webhook de dunning: https://blog.recurly.com/new-dunning-webhook
- Odoo — follow-ups automáticos: https://documentation-user.readthedocs.io/en/latest/accounting/receivables/getting_paid/automated_followups.html
- Odoo — níveis de follow-up: https://Hibou.io/docs/accounting-3/follow-up-levels-1506
- ERPNext — Dunning: https://docs.frappe.io/erpnext/dunning
- Zuora — workflows de cobrança: https://knowledgecenter.zuora.com/Zuora_Collections_articles/Automations/Automate_collection_workflows
- Salesforce — workflow cheatsheet: https://developer.salesforce.com/docs/atlas.en-us.salesforce_workflow_cheatsheet.meta/salesforce_workflow_cheatsheet/workflow_cheatsheet.htm
- Customer.io — campanhas por data: https://docs.customer.io/journeys/birthday-and-anniversary-campaigns
- Braze — "um dia antes" de uma data: https://community.braze.com/discussion/1586/send-one-day-before-event-property-date
- Temporal — timers: https://temporal.io/blog/timers-timeouts-and-the-art-of-waiting-in-temporal
- AWS EventBridge Scheduler — tipos de agendamento: https://docs.aws.amazon.com/scheduler/latest/UserGuide/schedule-types.md
