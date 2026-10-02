# Histórico comercial completo preservado no MySQL — 02/10/2026

## Entrega
Importador `migrations/scripts/sales_full_history_snapshot.py` e DDL
`migrations/sql/20261002_legacy_sales_history.sql` preservam todos os 17 campos
consumidos pelo modelo InvoiceMsSql, sem filtro por período, atividade ou tipo.
O snapshot usa identidade própria, contagem e SHA256; texto Unicode, nulos,
comissões, quatro casas decimais e frações de segundo são preservados.

A consulta de origem é uma transação de leitura serializável limitada por timeout;
a transação termina após fetch, antes de normalização/gravação no MySQL. Cada cópia
é nova; nenhuma cópia anterior é sobrescrita. Verificação antes e depois do commit.
A comparação posterior contra a origem retorna código 2 se a origem mudou.
Não confundir isso com falha de integridade da cópia.

LegacySalesHistoryReader exige snapshot explícito e verifica todos os registros
antes de devolver LegacySalesHistoryRecord. Modelo mantém nulos históricos e não
fabrica contratos ativos nem permissão por comissão. Leitor não consulta MSSQL.
`validation/sales-full-history` verifica o leitor real e imprime só agregados.

## Execução em produção
Snapshot: `4f95ea79-7312-419c-8e66-429e4299acdf`.
114452 registros copiados e conferidos no MySQL intranet, incluindo 25733 com
comissionado. Leitor .NET confirmou todos os registros e integridade, sem
identidades de serviço/cliente ausentes. SHA256 da cópia:
`94b25c23fa30f13e7265fe152f6ade7f77552c01e10b4e6b78b431e9e57eb5cc`.

Comparação posterior: 0 registros apenas na origem, 0 apenas no snapshot,
1 registro alterado na origem após a cópia. A origem continua recebendo escritas;
esta evidência histórica não autoriza substituir consultas operacionais atuais.
Não houve alteração de dados MSSQL, saldos, contratos operacionais ou agendamentos.
Túnel temporário próprio encerrado pelo PID após validação.

## Testes e limites
7 testes .NET e 3 Python passaram; build do validador passou. Conferência real
MySQL/Python e MySQL/.NET concluída. Cópia não é espelho contínuo e não comprova
transferência de escritores. APIs ainda precisam de histórico atualizado e integração
com sucessores MySQL antes de trocar GetRecords/GetOldCommissioned. Nenhuma flag
operacional ativada nem binário de produção substituído nesta etapa.

Evidências privadas: tmp/full-sales-history-copied.json,
full-sales-history-dotnet.json e full-sales-history-delta.json.
