# Contrato de configurações globais de áudio e anúncios

`Sufficit.Telephony.Runtime.NativeTelephonySettings` é uma política global única,
identificada pela seção `native-telephony`. Audio e Announcements são gravados e
capturados juntos. Não contém financeiro, credenciais, endereços de conexão ou
opções de DID testing/outbound.

A política exige as duas seções completas. Parse rejeita propriedades desconhecidas, GUIDs
vazios/duplicados, prefixos não canônicos e descoberta automática fora do escopo
de anúncios. Áudio habilitado exige
contextos, nós de cobertura e prefixo. Announcements habilitado exige Audio habilitado.
No modo `Announcements.CustomerControlsOnly`, basta informar
`{"Enabled":true,"CustomerControlsOnly":true}` na seção Announcements. As listas
do piloto devem ser omitidas ou vazias. A habilitação explícita por cliente
define o escopo e apenas cadastros nativos ativos podem tocar. A versão anterior
do documento continua aceita para leitura durante a troca dos consumidores.
`Audio.AudioIds` mantém o escopo existente dos consumidores de áudio.

Document valida e serializa a política completa; Parse limita tamanho e profundidade.
A captura de runtime retorna cópia para impedir que consumidores mutem o snapshot.
A seleção/gravação das versões pertence à persistência, não ao contrato.

Validação desta entrega: contrato exercitado por RuntimeSettingsTests de EFData e
EndPoints e build Release nos três TFMs de Standard/Base. Não comprova instalação.

Audio.ContextIds restringe consumidores legados; anúncios têm escopo independente.
Não ampliar o primeiro para cadastrar um contexto somente de anúncios. A resolução
de mídia continua exigindo propriedade/compartilhamento e recibos das centrais.
