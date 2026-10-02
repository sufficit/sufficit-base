# Identificador de chamadas por cobertura local — 02/10/2026

## Implementação
A captura comercial publica CallerIdNumber normalizado pelo mesmo extrator usado
no legado, sem transportar a observação livre. Null identifica eventos anteriores
sem evidência; vazio identifica extração sem número válido.

ContractCallerIdCoverage preserva a seleção por GUID de catálogo, precedência do
individual sobre o tarifado e conflito como resultado não resolvido. Evidência
ausente, duplicatas, texto não normalizado e interrupções atuais impedem aplicação.

SalesCallerIdProjectionWriter aceita Sufficit:CheckUp:CallerIdProjectionSource =
CoverageInbox. Nesse modo lê somente a inbox local para a cobertura comercial,
sob a proteção de concorrência do destino em cada tentativa. Overrides de ramais
e associação de fornecedor continuam sendo lidos na telefonia. O padrão Contracts
foi preservado. As autorizações por cliente já existentes continuam obrigatórias.

Após commit operacional registra caller-id-applied com evento, versão e hash do
recibo confirmado. Falha na auditoria propaga erro para manter a entrega pendente;
repetição recalcula a aplicação. O recibo não confirma troncos, DIDs, PBX ou créditos.

## Evidências
- Standard: 27 testes passaram (ContractCallerId e SalesCallerIdProjectionConsumer).
- EFData: 33 testes passaram (SalesIntegrationEventTests e CommercialCoverageInboxTests).
- Compilação net10 realizada pelos testes. Sem ensaio de gravação em cliente real.
- Logs privados: tmp/caller-inbox-standard.log e tmp/caller-inbox-efdata.log.

## Limites
Implementado localmente, sem publicação ou mudança de flags nesta etapa. Eventos
antigos precisam de nova captura; não fabricar número nem consultar o comercial
como fallback. A fila de entrega existente ainda coordena o disparo: substituir a
leitura no writer não conclui a independência do transporte. Agendamentos legados
continuam necessários até transferência coordenada. MSSQL permanece em uso.
