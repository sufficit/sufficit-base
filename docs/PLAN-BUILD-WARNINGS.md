# Warnings dos contratos compartilhados

Objetivo: corrigir nullability dos contratos de checkout e XML/compatibilidade sem alterar a representação em runtime.

1. [concluído] Anotar como opcionais os campos de checkout que já permitem ausência em runtime; documentar parâmetro cadence e API netstandard antiga.
2. [concluído] Build Release dos três frameworks e regressões do consumidor em checkout isolado.
3. [concluído] Registrar atividade, revisar e fazer commit/push na main.

Campos sem inicialização continuam null; não mudar o payload para objetos vazios fictícios. Não mudar assinatura binária dos contratos.

Builds Release dos três frameworks passaram no checkout isolado. Consumidor: 131 testes NUnit, 113 regressões xUnit focadas e 35 de coleções passaram; quatro testes de banco foram explicitamente ignorados. Sem warnings de nullability/XML dos contratos Base.
