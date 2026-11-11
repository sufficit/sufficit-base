# Warnings dos contratos compartilhados

Anotados como nullable os 16 campos de checkout sem inicialização, preservando os valores null existentes no wire. Adicionado param XML de cadence. A assinatura operacional netstandard antiga de SearchAsync propaga a depreciação do tipo de compatibilidade que já utiliza; assinatura binária preservada.

Builds netstandard2.0/net7.0/net10.0 e regressões do Standard passaram em checkout isolado: 131 NUnit, 113 xUnit focados (quatro testes DB ignorados), 35 de coleções; planilhas, snapshots, métricas e simulação Python aprovados. Sem chamadas de negócio reais ou deploy.

[Plano](../PLAN-BUILD-WARNINGS.md). Commit/push na main seguem a instrução do mantenedor.
