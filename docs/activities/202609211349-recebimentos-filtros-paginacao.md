# sufficit-base: recebimentos paginados

Entrega concluída e validada. Relatório completo: [recebimentos e paginação](../../../sufficit-blazor/docs/activities/202609211349-recebimentos-filtros-paginacao.md).

## Contratos e alterações
- Base: `RecentPaymentSearchParameters : SearchParameters, ILimit`; reutiliza `PagingParameters.Position/Size`. `Limit` segue compatível quando `Paging` não é enviado. `Count` é o tamanho da página, `TotalCount` e `TotalValue` representam todo o conjunto filtrado.
- EFData: duas consultas SQL, agregação e página; nenhuma alteração em dados financeiros.
- Client: serialização explícita de `Paging.Position/Size` junto de todos os filtros. Projeto de testes net10 tinha dependências Microsoft.Extensions 9 incompatíveis; alinhadas à versão 10.
- Endpoints: valida posição/tamanho/deslocamento, métodos, período e valor; usa consulta EF. Contrato documentado em `sufficit-endpoints/docs/USAGE-recent-payments.md`.
- Blazor: estado de paginação remota e layout solicitado; componentes SUI e tokens existentes preservados. Referência visual: captura do usuário, DESIGN.md e componentes SUI. Sem nova direção visual ou sistema de paginação paralelo.

## Validação
- `dotnet test tests/Sufficit.Blazor.RecentPayments.Tests.csproj --no-restore`: **13 testes aprovados**, incluindo datas de Brasília, padrão semanal, filtros recolhidos, paginação real, total global, erro de página/tamanho, restauração e última página removida.
- EFData `RecentPaymentsQueryTests`: **1 teste relacional aprovado**. SQLite com interceptação de SQL comprovou filtros/ordem antes de LIMIT/OFFSET, desempate, bordas inclusivas, totais completos, página vazia, método isolado e Limit legado.
- Client `RecentPaymentsRequestTests`: **1 teste aprovado**; URI e todos os filtros/paginação sob cultura pt-BR, resposta com totais.
- Endpoints `RecentPaymentsValidationTests`: **4 casos aprovados** (posição negativa, tamanho zero/excessivo e overflow).
- `dotnet build src/Sufficit.EFData.csproj -f net7.0`: aprovado. Publicações Release de Endpoints e Blazor aprovadas.
- Harness temporário somente leitura com o provider real no SQL Server: duas páginas de dois itens, sem sobreposição, contagem/soma estáveis; **718 ms** para ambas, sem incluir enriquecimento de clientes. Não é benchmark completo do endpoint.
- Playwright: desktop 1440px, tema escuro e móvel 390px, abertura pelo teclado, filtros recolhidos/abertos, segunda página com 3 de 28 resultados e mesmo total; sem overflow horizontal e sem erros no console. Evidências sintéticas versionadas em `validation/recent-payments-preview/paging-*.png` no Blazor.
- `git diff --check` aprovado. Warnings preexistentes dos projetos não foram tratados como erros de produto.

## Integração e publicação
Fontes enviadas a main:

| Repositório | Commit |
| --- | --- |
| sufficit-base | 453951f |
| sufficit-efdata | 867cb74 |
| sufficit-client | 9e5e2ed |
| sufficit-endpoints | a17a430 |
| sufficit-blazor | 9b58457 |

Deploys oficiais `python3 -u deploy.py eveo-apps --publish`, primeiro API, depois Blazor. Backups privados em `/opt/sufficit-backups/receipts-paging-20260921/endpoints.tar.gz` e `blazor.tar.gz`, ambos verificados com tar antes da conclusão. Apenas eveo-apps, servidor principal autorizado.

- Endpoints: `publish-net10.0-20260921134232`; serviço ativo, saúde pública Healthy. SHA-256 EndPoints.dll: `9dca0ee24bd19c4c78a3fbbda4dc4092e66f534b0a80d1e8cbbd3f0ee172324e`. EFData.dll: `4dc4eec52398f483568877fc30cdf1035302996cfc9504ca8ce20ca34188169c`. Ambos idênticos no servidor.
- Blazor: `server/publish-20260921134458`; serviço ativo e saúde pública Healthy em 2026-09-21T16:48:05Z, versão `1.26.0921.1644+9b584575bf8ef4a04d123fc02007544659102e3c`. SHA-256 Blazor.dll: `4c87daaf526477fc57bf24469c80f3ba936d2f6a2630b9bba38fbc01ca3ffb8b`. Client/Base também comparados com os artefatos locais.
- O job automático de deploy Blazor 35627560926 foi cancelado deliberadamente pelo agente para evitar corrida com deploy.py; não foi cancelamento do usuário nem falha da aplicação. Não reexecutado. Publicação de pacote 35627560756 segue independente.

## Limitações registradas
O token dos testes para a API pública respondeu 401; não se afirma teste autenticado da página em produção. A validação funcional utilizou componente real com dados sintéticos, consulta real somente leitura e hashes/saúde dos serviços publicados. CI completo Endpoints 35627341060 e publicação de pacotes Blazor ainda estavam em andamento no fechamento; os 19 testes focados e as publicações locais acima foram efetivamente aprovados.

Os registros financeiros sem evidência de data tratados na atividade anterior não foram alterados nesta tarefa. Nenhuma mudança alheia foi incluída.
