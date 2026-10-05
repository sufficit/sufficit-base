# Campo inglês no contrato comercial

Objetivo: substituir SalesRecord.Cliente por LegacyCustomerCode e publicar no contrato JSON o campo legacyCustomerCode, preservando ContextId como identidade atual.

1. Concluído — identificar consumidores e distinguir DTO de armazenamento histórico.
2. Concluído — atualizar DTO, mapper, contrato e teste de transporte.
3. Concluído — validar testes, builds e registrar contrato atualizado.

Preservar dados e nomes do histórico persistido; remover o nome antigo apenas do contrato público SalesRecord. Renomeação anterior ainda não publicada; alterações binárias exigem publicação conjunta.

Teste de transporte reproduziu ausência do campo inglês: três casos falharam antes da alteração. Propriedade renomeada e mapper histórico ajustado; campo JSON explicitamente legacyCustomerCode.

Validação concluída: três testes de contrato falharam antes e passaram depois; 17 testes de transporte/gateway e três testes API passaram. Builds netstandard2.0/Web sem erros. Contrato permanente em docs/contracts/SALES-RECORD.md. Sem publicação de novos binários.
