# Renovação mensal administrativa — 02/10/2026

POST Sales/Contract/RenewMonthly recebe LegacyMonthlyRenewalRequest com contrato
e snapshot original. Gestor/administrador identificado é obrigatório. API rejeita
entrada vazia ou acima de 16 KiB antes de resolver o provedor; traduz snapshot
inválido e conflitos sem chamar renovação MSSQL ou executar telefonia.

RequestLegacyMonthlyRenewal persiste RequestedBy no recibo imutável e reutiliza a
transação já existente. Repetição pelo mesmo predecessor devolve o mesmo sucessor,
inclusive por outro gestor autorizado; não reescreve o ator original. O SDK expõe
Sales.RenewMonthly. A primitiva interna anterior permanece compatível, ator null.

Validação: 4 testes transacionais EFData passaram (rollback, replay, ator original,
ator obrigatório e coorte padrão recusada); 3 testes API passaram; SDK net10 compilou
com zero avisos/erros. Logs privados tmp/monthly-manager-*.log.

Antes de qualquer publicação do novo modelo: verificar information_schema.columns
e aplicar uma vez migrations/sql/20261002_monthly_renewal_actor.sql. Se a tabela
base ainda não existir, instalar primeiro o DDL mensal existente. Nunca atualizar
atores dos recibos anteriores para inventar autoria histórica. Esta etapa não
executou DDL nem publicação e não habilitou clientes ou catálogos de corte.

Ainda falta a entrada visual e substituir o botão legado; renovação comum não
substitui tarifado nem tronco compartilhado, cujas regras são próprias. Recibo não
confirma pagamento ou entrega de efeitos. O corte global permanece no plano principal.
