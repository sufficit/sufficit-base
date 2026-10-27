# Suporte empresarial → Suporte técnico e assessoria em TI (27/10/2026)

Decisão do dono: o item de suporte não é obrigatoriamente mensal; um único item cobre suporte recorrente e avulso.

- `Constants.SERVICE_BUSINESS_SUPPORT` passou de `SUPORTE EMPRESARIAL` para `SUPORTE TECNICO E ASSESSORIA EM TI` (ASCII maiúsculo, como os demais nomes legados).
- Catálogo em produção (`intranet.sals_service_catalog`, id `23673016A22511F1824EF26E44C3A574`) renomeado, descrição atualizada e `fiscal_profile_code = 01.07.01` (LC 116 item 1.07, CNAE 6209-1/00, presente no CNPJ). Status (rascunho) e modalidade não alterados. Migration: `sufficit-efdata/migrations/sql/Sales/202610271200-business-support-rename.sql`.
- Antes da troca: 0 contratos (`sals_contracts.title`) e 0 linhas em `sals_contract_history` com o nome antigo — sem migração de dados.
- O nome é comparado por texto no web legado (`Vendas/Controle.Commercial.cs`, `Controle.aspx.cs`) e no Blazor (ícone/lista de tipos). Eles passam a usar o nome novo quando forem recompilados com esta versão do `Sufficit.Base`; até lá, o legado ainda oferece o nome antigo no seletor.
- `fiscal_profile_code` ainda não é lido por nenhum emissor: a NFS-e continua usando o serviço configurado no painel do Asaas (padrão 01.03.01). Cobranças deste item precisam do serviço 01.07.01 no Asaas.
