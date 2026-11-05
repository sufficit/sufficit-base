# Nome canônico do tronco flexível

Implementação autorizada pelo mantenedor: mesmo serviço/GUID, sem alteração de preço, canais, cobertura ou saldo. Plano coordenador: sufficit-endpoints/docs/PLAN-FLEX-CANONICAL-NAME.md.

Validação local: 53 testes comerciais e 18 de catálogo (sobreposição de casos), 27 de cobertura/saída, 192 da API; build Standard netstandard2.0 e Blazor sem erros. Fixture de ativação em 1280/390 passou. O teste de colisão falhou nas três combinações de nomes antes da correção; o teste de renomeação de serviço já renovado também falhou antes do ajuste restrito de replay.

Esta revisão prepara código para a virada coordenada. Não comprova publicação nem migração de dados. Asterisk/FastAGI não serão reiniciados; as permissões operacionais devem permanecer iguais ao baseline. Histórico original e aliases de leitura mantêm compatibilidade sem oferecer outro produto.
