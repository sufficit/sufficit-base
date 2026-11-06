# Políticas genéricas de ativação — 06/11/2026

Configuração por catálogo de permitir, impedir ou substituir sobreposição por cliente.
Validade efetiva mantida no lançamento; crédito tarifado continua com seis meses e poda
semanal auditada. Substituição não modifica recibos anteriores. Campos novos preservados
quando omitidos por consumidores antigos. Configuração tarifada existente migra para substituição.

Validação: 646 testes backend/documentação passaram (1 integração MySQL ignorada),
13 regressões finais passaram; 118 testes da interface passaram. Editor SUI conferido
no navegador a 1440, 768 e 390 px, sem gravação em produção. 276 testes da API passaram contra os binários candidatos (275 + regressão de validade).
A fixture Swagger exigiu deps.json do candidato e content root explícito; passou após ajustar a execução.
Builds Release da API e Blazor passaram. Publicação concluída: API 1.26.1106.2112 e Blazor 1.26.1106.2113 nos três apps.
Saúde Healthy e hashes conferidos (559 binários da API e 256 DLL/WASM da interface).
A migração aditiva foi aplicada; catálogo tarifado conferido com política 2.
Nenhuma recarga, débito ou manutenção de contrato de cliente executada nesta entrega.
O pacote da interface inclui a remoção da validação mínima, posteriormente registrada no commit efc1fea5.
A regra legada de exclusividade da família Flexível foi preservada; recursos emitidos exigem revisão.
