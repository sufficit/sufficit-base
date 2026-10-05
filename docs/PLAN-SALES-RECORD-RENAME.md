# Nomenclatura do registro comercial

Objetivo: renomear o DTO InvoiceMsSql para SalesRecord e ajustar todos os consumidores ativos, sem alterar propriedades ou o contrato JSON.

1. Concluído — mapear consumidores e compatibilidade netstandard2.0.
2. Concluído — renomear classe, arquivo, extensão e referências; adaptar geração do perfil congelado.
3. Concluído — compilar Web, API e bibliotecas, executar testes existentes e registrar entrega.

Preservar mudanças preexistentes e documentos históricos. Não criar alias com nome antigo. Renomeação CLR exige publicação conjunta de bibliotecas/consumidores; esta tarefa será validada no código antes de qualquer publicação.

Validação concluída: Standard 379 testes, EFData 574 testes, API RecordBridge 3 testes. Perfil netstandard2.0 e Web Release compilados sem erros. Todos os 17 campos do DTO permanecem iguais. Nenhuma referência ao tipo antigo em fontes C# ativas do workspace. Alteração local, sem nova publicação.
