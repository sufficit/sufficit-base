# Total histórico de créditos recebidos

Adicionado `CreditOverview.TotalReceivedUnits`, decimal nullable em bilionésimos
de real, para o indicador percentual do Cloud Mobile. Soma recargas confirmadas
e vouchers monetários resgatados, inclusive os consumidos/expirados. Não inclui
descontos percentuais nem intenções de pagamento. Null distingue produtor antigo
que não fornece o total. Alteração aditiva, sem entidades persistidas ou migração.

Validação: consumidor Cloud com 764 testes .NET aprovados e 8 browser em fixture;
EFData com 155 testes aprovados em cópia isolada dos arquivos rastreados, incluindo
o grafo restaurado e binários compilados. O checkout EFData contém worktrees
aninhados que o teste de localização de migrations não ignora; nenhum foi alterado.
Acompanhamento integrado: sufficit-cloud-mobile/PLAN-creditos-indicador-circular.md
(enquanto ativo), depois atividade creditos-cabecalho de 17/09/2026.
