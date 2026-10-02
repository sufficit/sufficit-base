# Entrada administrativa de renovação tarifada

POST /Sales/Contract/RenewBilled recebe ContractId e ExpectedSnapshot. Exige papéis administrativos de vendas já usados no controller e ator identificado; rejeita entrada incompleta ou snapshot acima de16KiB. O provider RequestLegacyBilledRenewal valida cliente/catálogo autorizados para transferência, contrato e snapshot e define horário UTC no servidor. Repetição do mesmo predecessor/snapshot recupera o sucessor, sem recalcular data ou sobrescrever o primeiro gestor. RequestedBy fica no recibo imutável. Resposta200 contém GUID do sucessor, não prova de pagamento ou crédito entregue. Snapshot divergente/corte não habilitado resulta409, entrada inválida422.

SDK Sales.RenewBilled usa o contrato tipado e a mesma rota. Não possui fallback MSSQL. Chamadores devem guardar/reutilizar o snapshot original na retentativa. O botão legado ainda não foi redirecionado.

Validação:7 testes de provider,6 de API/worker passaram. Build SDK net10 sem erros(3avisos). MySQL8 isolado confirmou DDL com RequestedBy binary16, identidade/horário de servidor, repetição, evento e entrega. Corrigida colisão de nome JsonException na compilação usando tipo qualificado. Container removido. Sem publicação, alteração de flags ou escrita em produção.

Restam interface/disparadores legados, histórico vivo e efeitos operacionais completos para o corte coordenado. Esta API não retira o MSSQL por si só.
