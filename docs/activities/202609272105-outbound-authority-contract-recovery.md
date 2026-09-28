# Recuperação dos contratos de autorização outbound

## Objetivo

Publicar em `main` os contratos outbound necessários ao `sufficit-standard` e que estavam somente como arquivos locais não rastreados.

## Estado inicial

O CI de `sufficit-endpoints` no SHA `964a974` compilava `main` dos repositórios dependentes e não encontrava os contratos de autorização e concessão outbound. Os modelos e DTOs já estavam preparados no workspace, junto a alterações não relacionadas de Finance/Sales.

## Alterações

- Incluídos contratos de estado administrativo, snapshot, concessões comerciais, manifestos, agregação e concessões de rota.
- Atualizados catálogo, serviço do cliente e rota para carregar vigência, revisão e origem.
- Mantido fora deste escopo o trabalho staged de Sales e os arquivos locais de Finance/Sales.

## Validação

- Build local do `sufficit-endpoints` usando os projetos irmãos do workspace: 33 projetos, 0 erros, 284 avisos, após a correção complementar no Standard.
- A suíte de testes não foi executada.
- O CI remoto que falhou antes da publicação é o run `36360103285`; seu resultado não valida ainda esta recuperação.

## Limitações e acompanhamento

O CI do Endpoints deve ser executado novamente depois que Base, EFData e Standard estiverem sincronizados. O resultado remoto será registrado após a execução.
