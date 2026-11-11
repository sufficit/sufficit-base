# Metadados para consumidores do conector corrigido

Ampliados para <9 os intervalos das quatro dependências Microsoft.Extensions do asset net7, mantendo a seleção/piso 7.x no build. Evita NU1608 ao consumir MySqlConnector 2.6.1 e a família Extensions 8 alinhada em EFData/Standard. Famílias System.* e demais targets não foram alterados.

Build isolado netstandard2.0/net7.0/net10.0 passou. A combinação Base 7.x com consumidor Extensions 8 já passou nas regressões do Standard; a alteração é nos limites declarados, preservando essa compatibilidade em pacotes. Nenhuma mudança de DTO/schema/comportamento de negócio.

[Plano](../PLAN-BUILD-WARNINGS.md). Commit/push na main aciona o workflow de publicação já existente.
