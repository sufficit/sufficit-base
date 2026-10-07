# Publicação integrada dos presets e alterações pendentes

Autorização: usuário solicitou em 07/10/2026 merge de tudo pendente na main em todos os projetos envolvidos e deploy para teste. Inclui as alterações locais já presentes nesses sete projetos; o app público sufficit-identity permanece fora da publicação de modelos de negócio.

## Checkpoints (ordem de execução)

1. CONCLUÍDO — Inventariar branches/PRs e alterações, conferir regras e scripts oficiais, resolver dependências de publicação.
2. CONCLUÍDO — Consolidar o conjunto autorizado na main local; branches conciliadas e backups dos checkouts preservados. API: 763 testes; pré-pago: 29; Blazor focados: 53.
3. CONCLUÍDO — Integrar Standard/API na main remota para publicar pelas fontes já validadas. Base/Identity.Core/EFData/Client já têm o código remoto; indexação de pacotes acompanha o checkpoint 5.
4. EM ANDAMENTO — Aplicar migração de presets com backup, executar deploy oficial da API, integrar Blazor na main remota e executar deploy oficial do Blazor.
5. PENDENTE — Verificar saúde/versões e catálogo; concluir CI/publicação NuGet após indexação, registrar entrega e concluir planos anteriores.

## Evidência de aceitação

Main remota com commits integrados, dependências disponíveis, tabelas e dois presets com balanceview, serviços saudáveis e versão correspondente ao artefato publicado. Não remover trabalho nem branches com alterações não enviadas. Preservar claims existentes. Revalidar o build completo antes do deploy.

Checkpoint de validação: build API 33 projetos e Blazor Server 22 projetos aprovados; 763 testes API, 719 EFData, 417 Standard, 41 Identity.Core, 29 pré-pago/roteamento e 53 Blazor focados. Blazor completo: 873 aprovados, 23 ignorados e três falhas estáticas preexistentes (assets SUI transitivos, botão monitor e wrapper de seção em representantes). Arquivos dessa condição não alterados pelo lote. Backup real intranet: /root/sufficit-migration-audit/20261007-before-entitlement-presets-root.sql.gz (111031238 bytes, 0600, gzip válido). Tentativa via usuário padrão do mysqldump não tinha acesso às tabelas; não é usada como backup. Publicação de pacotes aceita pelo NuGet, aguardando processamento/indexação antes de reexecutar consumidores.
