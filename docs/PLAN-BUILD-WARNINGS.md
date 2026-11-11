# Warnings dos contratos compartilhados

Objetivo: corrigir nullability dos contratos de checkout e XML/compatibilidade sem alterar a representação em runtime.

1. [concluído] Anotar como opcionais os campos de checkout que já permitem ausência em runtime; documentar parâmetro cadence e API netstandard antiga.
2. [concluído] Build Release dos três frameworks e regressões do consumidor em checkout isolado.
3. [concluído] Registrar atividade, revisar e fazer commit/push na main.

Campos sem inicialização continuam null; não mudar o payload para objetos vazios fictícios. Não mudar assinatura binária dos contratos.

Builds Release dos três frameworks passaram no checkout isolado. Consumidor: 131 testes NUnit, 113 regressões xUnit focadas e 35 de coleções passaram; quatro testes de banco foram explicitamente ignorados. Sem warnings de nullability/XML dos contratos Base.

## Continuidade: conector pelo fork Pomelo

4. [concluído] Permitir Extensions 8 nos consumidores net7, mantendo compilação/pisos 7.x e demais famílias intactas.
5. [concluído] Validar build e o consumo de EFData/Standard com MySqlConnector 2.6.1.
6. [concluído] Commit/push na main e conferir publicação existente.

O provider corrigido exige abstrações 8; os caps <8 do pacote Base antigo geravam NU1608. A compatibilidade de Base compilado com 7.x e consumidor com 8.x já foi exercitada nas regressões do Standard. Ampliar apenas os intervalos das quatro dependências Extensions preserva a API e elimina a contradição dos metadados.

Build isolado dos três frameworks aprovado; o código compilado/pisos continuam em 7.x para net7, os metadados permitem o consumidor usar a família 8. Publicação será conferida no workflow existente.

## Fechamento da entrega

Fonte c9b0f23 entregue; CI/publicação 43079836816 success. Standard 31ce9f6 passou integração por pacotes/audit. Pacote local recompilado tem proveniência e não é declarado byte a byte idêntico ao pacote público. Nenhum deploy.
