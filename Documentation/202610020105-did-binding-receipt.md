# Vínculo de DID e recibo atômico

Implementados DIDBindingCommand, preparação por identidade/filas e BindUnowned com
transação serializável e recibo EventId/DidId. Preserva campos alheios ao vínculo,
linha já pertencente ao cliente e edições posteriores no replay. Coorte explícita
obrigatória; nenhum consumidor automático registrado para execução do vínculo.

Validação:23 testes EFData +8 Standard passaram; diff --check sem erros nos três
repositórios de código. MySQL8 com mapeamento real reproduziu proprietário vazio
como string; a condição inicial recusava esse valor. Corrigida mantendo guarda de
titularidade no UPDATE; runner passou com DDL, replay e preservação de expiração.

Sem deploy/dados reais/configuração alterados. Recibo cobre cadastro, não PBX.
Faltam consumidor operacional/frescor da cobertura, recuperação do comando congelado,
consulta confiável de filas, sincronização PBX/cache e adaptador WhatsApp. Migração
MSSQL ainda não concluída; jobs existentes preservados.
