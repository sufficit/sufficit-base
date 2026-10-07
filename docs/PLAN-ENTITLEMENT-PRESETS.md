# Presets de entitlements: modelo de negócio Sufficit

Objetivo: presets no standard (regras), efdata (persistência intranet), endpoints (API). App público sufficit-identity agnóstico, sem alterações. Contrato compartilhado em base e transporte em client para consumo Blazor sem referência a Standard.

1. [concluído] Retirar a implementação equivocada do app identity e definir contrato.
2. [concluído] Runtime standard, provider/context efdata e CRUD endpoints.
3. [concluído] Integrar API client/Blazor e atualizar testes.
4. [concluído] Validar SQL MariaDB, API/persistência/consumidor e estado limpo do app identity; registrar entrega.
5. [concluído] Mains integradas após autorização explícita; SQL e deploy API/Blazor concluídos nos três nós. CI final acompanhado em PLAN-PUBLISH-ENTITLEMENT-PRESETS.md.

Aceite: dois perfis seed com balanceview; API permite editar itens/perfis; segurança de concessão segue no endpoint de claims; nenhuma dependência de presets Sufficit no app público de identidade. Preservar trabalho alheio em todos os checkouts.

Validação concluída: 7 testes focados (incluindo HTTP real e concorrência), 21 testes Blazor/cliente, Standard nos três TFMs, SQL MariaDB avanço/reexecução preservando edições/rollback/reaplicação e app identity limpo/recompilado. Publicação concluída em 07/10/2026; detalhes no registro de publicação. Registro: docs/activities/202610071117-business-entitlement-presets-ownership.md

Registro de publicação: docs/activities/202610071210-publish-business-entitlement-presets.md.
