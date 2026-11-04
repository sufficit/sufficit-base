# Comissões por evento e bloqueio por dívida

Entrega de 04/11/2026: transição de devedor para quite aciona reconciliação; saldo
atual é verificado antes da reserva e atomicamente antes do crédito em saldo.
Eventos antigos não autorizam crédito de origem atualmente devedora. Recibos
independentes preservam o consumidor de auditoria e permitem retry. Varredura
periódica permanece. Extrato mostra AwaitingReconciliation (4), projetado sem
persistência, com motivo legível nas telas de gestão e do representante.

Validação: 153 testes Standard/Sales e 1295 testes API aprovados; integração com
MariaDB em schema isolado: 5 casos aprovados, schema removido ao final. Cobertura
inclui dívida, quitação, nova dívida, replay idempotente, falha/retry do evento e
independência de published_at_utc. Fixture do componente real no navegador validou
quatro estados e motivo da retenção em 1440/390 px, sem overflow/erros. Build Blazor
aprovado; avisos de dependências/obsolescência existentes permanecem. Não foi feito
teste autenticado das páginas de produção.

Ordem de instalação: migração EFData `202611041930-commission-balance-event-receipts.sql`,
conjunto compatível Base/Standard/API, depois Blazor. Nenhuma migração de produção
ou publicação foi executada nesta entrega; código enviado à main não é deploy.
Rollback deve preservar outbox, recibos e lançamentos. PIX continua registro de
transferência externa, validado antes do registro; proteção transacional descrita
acima aplica-se ao crédito no razão.
