# Contrato dos relatórios de telefonia

`TelephonyReportRequest`, `TelephonyReportModel` e `TelephonyReportResult` ficam em
`Sufficit.Telephony.Reports`. São compartilhados pela API, pelo cliente HTTP e pelo
Blazor. SchemaVersion 1: contexto obrigatório, instantes com fuso, offset de
apresentação, catálogo de capacidades, linhas JSON tipadas, totais decimais,
observações e Excel opcional em base64 da mesma execução. Não transportar o
objeto de execução, exceções internas ou identificadores de cache do servidor.

O catálogo declara filtros e período máximo por modelo. Consumidores não devem
inferir sucesso de uma lista vazia recebida junto com erro nem recalcular valores
financeiros a partir de duração. Uma resposta de sucesso representa geração
concluída; pendências de tarifação podem constar nas observações.
