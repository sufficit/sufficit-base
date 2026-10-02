# Comparação inbound a partir da cobertura recebida

Adicionada referência pública opcional ao evento (Key/Source/atributos permitidos),
sem copiar texto livre ou parâmetros internos. Inbox valida campos explícitos da
referência e oferece leitura local verificada contra recibo/hash. Comparador de
DIDs lê essa projeção, devolve EventId/Version e preserva a comparação existente.

Verificado:21 testes Standard e19 EFData passaram; diff --check sem erros em
Base/EFData/Standard. Cobertos quatro tipos de entrada, dia inclusivo legado,
interrupção, referência histórica ausente, proteção de parâmetros privados e estado
local divergente do recibo.

Sem DDL adicional/deploy/efeito em clientes. Executor de vínculos, destinos,
recibos e demais efeitos ainda pendente. Não confundir comparação com provisionamento.
