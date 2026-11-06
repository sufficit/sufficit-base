# Relatórios sem limite de dias

1. Concluído: remover limites gerais, por hora e da UI; catálogo MaximumHours=0 significa sem limite de duração.
2. Concluído: testes de seis meses/mais de 48h, datas inválidas e navegador.
3. Em andamento: commit/push dos repositórios, publicar API e Blazor com dependências e conferir hosts.

Escopo: Base contrato; Standard validação/construtor; EndPoints regressões/publicação; Blazor UI/AI. Preservar autorização, datas obrigatórias/ordenadas, timeout/cancelamento e limite existente de linhas. Não truncar nem alterar períodos solicitados. Sem consultas extensas em produção durante a validação.

Validação: 14 testes da API aprovados; navegador 1440/768/390 com período de seis meses, horários exatos, Excel, paginação, cancelamento e isolamento de cliente.
