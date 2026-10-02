# Renovação mensal — interface, esquema e publicação

## Implementação
Editor de serviços RecurringItem ganhou painel mensal com consulta de disponibilidade
administrativa, confirmação, tratamento de falha e repetição do snapshot original.
A tentativa conserva o recibo antes do refresh e serializa cliques. Ações de salvar,
remover, alterar automação e outra renovação ficam bloqueadas durante a operação.
Identidade de tentativa é local à página, não armazenamento persistente do navegador.
O assistente da tela explica o comando e distingue recibo de pagamento/telefonia.

GET MonthlyRenewalAvailability exige gestor; sua resposta é consultiva. POST
RenewMonthly e provedor revalidam cliente/catálogo, snapshot e estado. Catálogos
compartilhados/tarifados não devem integrar a lista de mensal genérico. SDK alinhado.

## Validação
8 testes UI (tarifado/mensal) e 4 API passaram. Testes transacionais mensais já
validados na etapa anterior (4). Fixture com componente real em 1280 e 390 pixels:
consulta indisponível, resposta incerta, repetição, sucesso, botão bloqueado e
nenhum overflow; captura móvel inspecionada. Fixture não renova cliente real.
Host de teste encerrado por PIDs explícitos. Builds Release API/Blazor passaram.

## Esquema e produção
Tabela sals_legacy_monthly_renewals não existia: DDL base instalado e coluna
requestedby BINARY(16) NULL adicionada. Tabela vazia e esquema conferidos; nenhum
recibo anterior alterado. API e Blazor publicados pelo deploy oficial, com backups
e configurações próprias preservadas em cada host.

- api eveo-apps: 1.26.1002.1346 Healthy.
- api apoint-apps: 1.26.1002.1346 Healthy.
- api castrum-apps: 1.26.1002.1346 Healthy.
- blazor eveo-apps: 1.26.1002.1347+c6c188eea7a0c120368e982eb298abc7f0f97321 Healthy.

16 hashes de DLLs conferidos, 26 configurações conferidas. Consultas anônimas de
disponibilidade mensal retornam 401 nas três APIs. Backups em cada host:
/opt/sufficit-release-backups/monthly-ui-20261002/{api,blazor}/before.tar.gz.
Publicação da árvore local; não tratar como release de commit limpo nem afirmar
que os fluxos de negócio foram exercitados em cliente real.

## Limites
Nenhuma coorte habilitada nem escritor legado desativado. A funcionalidade exige
transferência de autoridade por cliente/catálogo; autorização não é presumida da
existência de dados importados. Histórico vivo/consultas, outros escritores,
consumidores DID/PBX e corte global continuam pendentes no plano principal.
Esta entrega não aposenta MSSQL.

Evidências privadas: tmp/monthly-release-verification.json, monthly-schema-result.json,
monthly-ui-tests.log, monthly-ui-api-tests.log, monthly-build.log e monthly-deploy.log.
