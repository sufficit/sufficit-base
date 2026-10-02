# Captura transacional de eventos comerciais

## Implementação

- DTO público CustomerContractCoverageChanged sem dependência EF/telefonia.
- Snapshot por cliente e sequência transacional; correlação entre clientes em
  transferências; histórico preservado em exclusões; guardas append-only no EF.
- Captura opt-in na transação do agregado, mantendo invalidação legada independente.
- DDL aditivo e runner exclusivo de MySQL descartável em localhost:32768.

## Validação

- 31 testes passaram (SalesIntegrationEventTests e SalesProjectionTests).
- Teste de transferência revelou snapshot adicional ao excluir períodos históricos
  do cliente anterior; asserção corrigida para validar versões contíguas e conteúdo
  de ambos os clientes, sem assumir quantidade de invalidações igual a contratos.
- MySQL8: DDL entregue, GUIDs binários, UTC com microssegundos, sequência, histórico
  e exclusão passaram; container exclusivo removido após a execução.
- git diff --check sem erros nos repositórios Base/EFData.

## Limites

Código local. Nenhum deploy, configuração ou dado de produção alterado. Não há ainda
entrega/inbox operacional nem auditoria de execução nesta etapa. O DTO captura
cobertura, não pagamento ou identificação de DID. Consumidores e handoff continuam
pendentes no plano consolidado; jobs existentes preservados.
