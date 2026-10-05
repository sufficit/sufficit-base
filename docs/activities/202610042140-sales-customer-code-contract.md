# Campo de cliente em inglês no contrato comercial

Substituída a propriedade SalesRecord.Cliente por LegacyCustomerCode (uint?), com JsonPropertyName("legacyCustomerCode"). Removida a ressalva de preservação do nome português nos comentários XML; documentação inline continua em inglês. ContextId permanece a identidade atual utilizada no fluxo comercial/autorização.

Atualizado CurrentLegacySalesReader.ToInvoice para mapear o código histórico Cliente à nova propriedade. O histórico persistido não foi modificado: seus nomes fazem parte da evidência consolidada e não do novo contrato SalesRecord. Não há alias público do campo antigo. Busca dos consumidores não encontrou uso funcional adicional do código além do mapper. O perfil congelado netstandard2.0 não contém referências sobreviventes à propriedade removida; sua compilação foi conferida.

O contrato JSON de Sales/Record/Search e dos payloads de serviço em Sales/LegacyService passa a usar legacyCustomerCode. A propriedade anotada também define o nome na geração do esquema da API. Documentação permanente: docs/contracts/SALES-RECORD.md.

Validação: os três casos de contrato falharam antes (campo inglês ausente) e passaram depois. Casos: código 42, uint.MaxValue e null; serialização com opções Web e desserialização com opções do gateway, preservando ContextId e recusando emissão de Cliente/cliente. Foram executados 17 testes de transporte/contrato/gateway Standard e três testes RecordBridge API, todos aprovados. Builds Release netstandard2.0 e Web concluídos sem erros (63 e 13 avisos existentes, respectivamente). git diff --check passou. Logs tmp/sales-customer-code-{contract-before,contract-after,api-tests,netstandard-build,web-build}.log no workspace.

Alteração em disco, sem publicação neste pedido. Produção mantém os assemblies anteriores. A publicação deve entregar conjuntamente a renomeação prévia InvoiceMsSql para SalesRecord e os consumidores do novo campo, para evitar mistura de contratos CLR. Nenhuma alteração nos dados ou configurações de produção; mudanças preexistentes preservadas. Nenhum commit/push criado.
