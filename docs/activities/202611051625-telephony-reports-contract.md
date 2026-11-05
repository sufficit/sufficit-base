# Contrato comum dos relatórios de telefonia

Adicionados request, catálogo e snapshot v1 para API/agentes/Blazor: contexto,
período com fuso, filtros declarados, linhas JSON, totais decimais e XLSX opcional.
Sem estado de execução ou dependência de WebForms. Contrato documentado em
`docs/contracts/TELEPHONY-REPORTS.md` e ligado ao README.

Validação: `dotnet build src/Sufficit.Base.csproj -c Packing --no-restore -v quiet`,
netstandard2.0/net7.0/net10.0, zero erros. Consumidores API e Blazor compilaram;
191 testes pertinentes passaram na API. Commit/push na main conforme autorização
do mantenedor; publicação do pacote depende do workflow e não comprova deploy.
