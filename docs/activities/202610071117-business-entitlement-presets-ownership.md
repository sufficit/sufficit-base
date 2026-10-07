# Presets de entitlements: correção de propriedade do domínio

## Correção solicitada

Presets são modelos de negócio Sufficit; regras em sufficit-standard, persistência em sufficit-efdata e API em sufficit-endpoints. O app público sufficit-identity deve permanecer genérico, replicável e agnóstico desses modelos.

Retirada integralmente a implementação anterior do app identity desta sessão: controller/serviço/contratos, entidades/mapeamento, registro DI, migração/snapshot, testes e documentos de presets. Checkout do app voltou a ficar limpo (git status --porcelain sem mudanças). Core genérico recompilado: 2 projetos, zero erros/avisos. Nenhuma migração/publicação anterior foi feita em produção.

## Implementação final

- Base: contratos portáteis de receita/item/versão e IEntitlementPresetStore; evita dependência de clientes no Standard.
- Standard: Access/EntitlementPresetRuntime, regras de negócio/limites/duplicatas; DI das receitas. Compila também em netstandard2.0 (runtime portátil; DI com EF apenas net7/net10).
- EFData: EFEntitlementPresetDBContext/Provider, registro da conexão Default com banco intranet. Versão do perfil protege todas as operações, inclusive itens; FK/cascade e SaveChanges atômico.
- Endpoints: Access/EntitlementPresets, CRUD de perfis e itens, autenticação/roles manager ou administrator conforme padrão de gestão Sufficit. Logs de alteração na API. Não toca userclaims.
- Client: APIClient.Access.EntitlementPresets, transporte autenticado com CRUD completo e validação do catálogo.
- Blazor: consome endpoints de negócio via APIClient; IdentityManagementClient trata somente claims genéricas. Nenhum catálogo/allowlist fixa de diretivas. Claims paginadas/desconhecidas/globais, versão relida antes de aplicar e usuário/contexto revisados. IA somente leitura informa catálogo/versão/itens pendentes. AGENTS.md registra propriedade de domínio.

SQL efdata/migrations/sql/Access/20261007_entitlement_presets.sql cria receitas no intranet, com telephony/calls e balanceview em ambos. Seed com transação após DDL; reexecução não sobrescreve perfil nem recria itens removidos. Rollback separado remove somente tabelas de receitas. Nenhuma tabela/seed/API desta mudança no banco/app genérico identity.

Contrato final: sufficit-endpoints/docs/USAGE-ENTITLEMENT-PRESETS.md. Documentação do runtime e persistência nos respectivos repositórios. Registro histórico da implementação incorreta no Blazor marcado SUPERADO.

## Validação

- Standard: build net10 e build completo (netstandard2.0/net7.0/net10.0) aprovados, com avisos existentes.
- Endpoints: build inicial aprovado (33 projetos) e 5 testes iniciais com controller/runtime/provider reais passaram.
- Blazor/Client: 21 testes focados passaram; recompilação aprovada. Catálogo dinâmico/remoção, transporte autenticado de negócio, erro não tratado como catálogo vazio, item com versão, paginação/claims desconhecidas/contexto/global.
- Rodada seguinte do grafo completo endpoints bloqueada pela dependência externa sufficit-ai/runtime→EFData 1.26.1007.1355 indisponível e ativos duplicados Base. Não alterada essa dependência. Projeto focado test/EntitlementPresetsContract usa os mesmos arquivos reais do controller/runtime e provider EFData, conforme padrão já existente dos testes de contrato.
- 7 testes focados aprovados: CRUD/ordem, versões antigas 409, itens individuais, validação, recusa sem role/autenticação, chamadas HTTP reais em TestServer e edição concorrente tardia com rollback integral dos itens. Dois avisos de depreciação do harness WebHostBuilder/TestServer.
- MariaDB 10.4.34 isolado: SQL final no intranet criou 2 perfis/12 itens (9/3, balanceview em ambos); edição/remoção preservadas após reexecução; rollback/reaplicação restauraram 2/12. Contêiner de validação removido.
- git diff --check aprovado em base/client/standard/efdata/endpoints/Blazor; app público identity limpo.

## Entrega e pendência

Sem commit/push/merge/deploy e sem alterações em banco de produção. Preservadas alterações alheias de todos os checkouts. Publicação segue pendente da decisão já solicitada sobre dependências locais sujas. Ordem: bibliotecas compartilhadas antes de consumidores, SQL intranet/endpoints antes de Blazor; NÃO migrar/publicar o app identity por causa deste recurso. Editar receita não modifica claims já concedidas; concessão continua autorizada pelo endpoint genérico de claims.
