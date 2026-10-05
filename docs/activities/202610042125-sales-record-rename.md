# Nomenclatura do registro comercial

## Alteração

Renomeados `Sufficit.Sales.InvoiceMsSql` e seu arquivo para `Sufficit.Sales.SalesRecord`. O novo nome representa registros comerciais sem indicar banco de dados ou nota fiscal. Todos os consumidores ativos e testes de Base, Standard, EFData, EndPoints e Web foram ajustados (42 arquivos existentes). A extensão `InvoiceExtensions` foi renomeada para `SalesRecordExtensions`, incluindo seu arquivo. Não foi criado alias com o nome antigo.

Os 17 nomes de propriedades e tipos foram comparados com o original e permanecem iguais; endpoints, contrato JSON, valores e identificação dos eventos permanecem inalterados. `ElectronicInvoice` não foi alterado. O gerador do perfil congelado netstandard2.0 agora adapta o nome histórico da revisão antiga ao DTO atual antes da compilação. A única ocorrência operacional do nome antigo fica nesse adaptador Python; nenhum fonte C# ativo mantém referências ao tipo antigo. Documentação histórica foi preservada.

## Verificação

- Standard: 379 testes passaram; build emitiu 236 avisos em quatro projetos.
- EFData: 574 testes passaram; três avisos existentes.
- API: três testes de SalesRecordBridge passaram, incluindo autorização e rejeição de autoridade divergente; 37 avisos no build de 28 projetos.
- Standard Release/netstandard2.0 (incluindo EFData congelado): zero erros/63 avisos.
- Web Release/net48 usando Mono: zero erros/13 avisos.
- Comparação dos 17 campos com o DTO anterior: idênticos.
- Busca no workspace: sem referências ao tipo antigo em fontes C# ativos, excluindo bin/obj, artefatos de publicação e worktree histórico independente.
- `git diff --check` nos cinco repositórios: passou.

Logs: `tmp/sales-record-rename-{standard-tests,efdata-tests,api-tests,netstandard-build,web-build}.log` no workspace. Inventário e cópia dos arquivos anteriores em `tmp/sales-record-rename-before-files` e `tmp/sales-record-rename-before-state.json`.

## Entrega e compatibilidade

Alteração validada em disco e não publicada neste pedido de nomenclatura. Produção permanece com seus binários atuais. Como o nome público CLR mudou, uma publicação deve entregar bibliotecas e consumidores juntos, inclusive serviços que referenciem essas bibliotecas, evitando misturar assemblies antigos e novos. O JSON permanece compatível. Não houve mudança em dados, configuração de produção, telefonia ou agendamentos. Mudanças locais anteriores foram preservadas; nenhum commit ou push criado.
