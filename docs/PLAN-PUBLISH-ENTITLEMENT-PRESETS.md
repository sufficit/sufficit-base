# Publicação integrada dos presets e alterações pendentes

Autorização: usuário solicitou em 07/10/2026 merge de tudo pendente na main em todos os projetos envolvidos e deploy para teste. Inclui as alterações locais já presentes nesses sete projetos; o app público sufficit-identity permanece fora da publicação de modelos de negócio.

## Checkpoints (ordem de execução)

1. CONCLUÍDO — Inventariar branches/PRs e alterações, conferir regras e scripts oficiais, resolver dependências de publicação.
2. CONCLUÍDO — Consolidar o conjunto autorizado na main local; branches conciliadas e backups dos checkouts preservados. API: 763 testes; pré-pago: 29; Blazor focados: 53.
3. CONCLUÍDO — Integrar Standard/API na main remota para publicar pelas fontes já validadas. Base/Identity.Core/EFData/Client já têm o código remoto; indexação de pacotes acompanha o checkpoint 5.
4. CONCLUÍDO — Aplicar migração de presets com backup, executar deploy oficial da API, integrar Blazor na main remota e executar deploy oficial do Blazor.
5. CONCLUÍDO — Verificar saúde/versões e catálogo; concluir CI/publicação NuGet após indexação, registrar entrega e concluir planos anteriores.

## Evidência de aceitação

Main remota com commits integrados, dependências disponíveis, tabelas e dois presets com balanceview, serviços saudáveis e versão correspondente ao artefato publicado. Não remover trabalho nem branches com alterações não enviadas. Preservar claims existentes. Revalidar o build completo antes do deploy.

Checkpoint de validação: build API 33 projetos e Blazor Server 22 projetos aprovados; 763 testes API, 719 EFData, 417 Standard, 41 Identity.Core, 29 pré-pago/roteamento e 53 Blazor focados. Blazor completo: 873 aprovados, 23 ignorados e três falhas estáticas preexistentes (assets SUI transitivos, botão monitor e wrapper de seção em representantes). Arquivos dessa condição não alterados pelo lote. Backup real intranet: /root/sufficit-migration-audit/20261007-before-entitlement-presets-root.sql.gz (111031238 bytes, 0600, gzip válido). Tentativa via usuário padrão do mysqldump não tinha acesso às tabelas; não é usada como backup. Publicação de pacotes aceita pelo NuGet, aguardando processamento/indexação antes de reexecutar consumidores.

Checkpoint de produção: SQL aplicado no intranet com backup completo; calls=3 itens e telephony=9 itens, ambos com balanceview. API saudável nos três nós (Eveo/Apoint/Castrum), SHA256 idêntico. EFData .1456 e Client .1445 indexados; mínimos reais fixados em Standard/API/Blazor. Blazor main 11d275e contém 01e585a; CI anterior substituído por novo push concorrente, sem reexecução do job cancelado. Checkout original agora limpo; deploy.py oficial do Blazor em execução no Eveo.

Blazor publicado oficialmente e validado nos três nós: Healthy 1.26.1007.1505+11d275e8dadb729971ee3b77496f97c2f7895d8d; SHA256 DLL 11eb156a82d96cd70c1db549cf37b260dcecdae20d2ccaf7436e74498fa9d0af. Saúde pública confirmada. CIs novos ainda executando; verificar antes de concluir estabilidade.

Bloqueio externo de registro remoto às 15:14 UTC: GitHub recusou pushes dos commits de documentação nas sete mains com Internal Server Error, por SSH e HTTPS; consulta remota confirmou que esses commits não foram aceitos. Código funcional já integrado e deploy saudável. CI final ainda em execução; checkpoint 5 continua em andamento. Commits de documentação preservados no branch release/all-pending-20261007.

## Resultado final — 07/10/2026, 15:26 UTC

Todos os commits do inventário inicial foram conferidos como ancestrais das mains integradas. App público Identity continua limpo. Commits de documentação enviados após recuperação do GitHub; erro interno transitório resolvido. Trabalho novo de outras tarefas em EFData/EndPoints/Blazor foi preservado, sem adicionar alterações em andamento ao lote.

CI final: Standard 37642087741 SUCCESS (117 principais + 14 áudio, 1 ignorado); EndPoints 37642093573 SUCCESS (763 API, 29 pré-pago, transação de deploy e TURN); Blazor Shared 37641816884 SUCCESS (pacote 1.26.1007.1517 publicado); Blazor Server 37641817155 SUCCESS (regressões de UI, 20 fila, 12 transporte autenticado e deploy nos três nós). Base/Identity.Core/EFData/Client já tinham CI de publicação SUCCESS e pacotes indexados.

Após deploy.py oficial manual, CI Blazor substituiu o artefato pela mesma revisão 11d275e em build Packing. Conferência após CI nos três nós: serviço active, Healthy 1.26.1007.1519+11d275e8dadb729971ee3b77496f97c2f7895d8d, SHA256 d622bc2591214dad351bab2b573ac3835b750b6c6e07c06858ac76bc7062b858. Nenhum CI posterior de código pendente no fechamento; commits finais são somente documentação com skip ci. Página guiada pública redireciona para autenticação (302).

API: todos os nós active/Healthy e catálogo protegido (401 anônimo). Apoint/Castrum mantêm 1.26.1007.1443+9a06ccb. Uma publicação concorrente posterior no Eveo instalou 1.26.1007.1501+5fd4897 e hash 28000c5e9c14d5118050bc807609a8d7344fe9839e5304a9f99269d3cab229dc; não foi sobrescrita. Esse SHA de fonte não está no Git deste lote/remoto. Conferido o controlador instalado e comparados seus 41 corpos de método IL com resolução de referências de metadados: nenhuma diferença nos presets. Standard instalado tem SHA256 f81660d0078a60f3ddaaf6f12dd214fc03a132dc1cb312dcbfa36307e779f312 e EFData 31f6648bb5b0bdccabdcb323b3394ebc3f9594f555df8ca48168aaddc9f96ef6, ambos iguais ao artefato deste lote. Esta evidência é específica dos presets; não certifica outras mudanças daquela publicação concorrente.

Teste do usuário: https://blazor.sufficit.com.br/pages/identity/policies-guided. Reaplicar perfil ao cliente/contexto afetado e renovar login para materializar balanceview. Não houve concessão retroativa de claims. Fluxo autenticado em produção será exercitado pelo usuário; testes HTTP e transporte autenticado passaram.
