# Separação de negócio e persistência da API

## Alterações

Contratos compartilhados de agentes (incluindo snapshot com JSON equivalente à entidade anterior), filas, preferências de vencimento, resultados de suporte e projeção de compromissos financeiros. Sem dependências da API ou EFData. Contratos anteriormente internos da API agora vivem em Sufficit.Telephony/Sales; consumidores HTTP mantêm rotas/JSON.

## Validação

- API net10: 143 regressões dos fluxos afetados aprovadas.
- Standard: 31 testes CallCreditCommitment aprovados.
- DI: os seis runtimes resolvem em escopo com ValidateScopes, sem abrir conexões.
- Testes agentes/fronteira: 21 aprovados; duas falhas globais preexistentes em AudioController.Details (EFData) e PanelController (gateway WhatsApp). Esses arquivos permanecem idênticos à HEAD; os limites não foram ampliados. O teto legado de BillingController.CommitmentPreference foi removido após zerar as referências.
- Standard netstandard2.0 compilado com 0 erros; grafo net7 bloqueado por CS1705 em Communication/Statistics (Microsoft.Extensions 7/8), sem alterações nesses projetos.
- MarkdownCoverage: Endpoints 8, EFData 8 e Standard 8 aprovados. O checker Standard usou configuração temporária para resolver o Pomelo 10 do cache local; configurações do repositório não foram alteradas.
- Nenhuma chamada real, migração, deploy ou publicação NuGet foi realizada. Publicação futura exige Base/EFData/Standard/Endpoints coordenados e schema do ledger pré-existente ou migração aditiva, sem apagar claims.

## Decisões e limites

Fluxos migrados são os nomeados na revisão; a varredura de 49 arquivos com DbContexts não constitui afirmação de remoção de todas as dependências EFData da API. Composição, workers e outros domínios não foram movidos mecanicamente.
As superfícies originadas da API permanecem net10. As fachadas estáticas legadas de compromisso preservam assinaturas e agora delegam a persistência.

## Entrega

Commit direto na main autorizado pelo mantenedor; referências finais da entrega coordenada serão registradas na atividade de Endpoints. Commit/push não comprovam deploy.
