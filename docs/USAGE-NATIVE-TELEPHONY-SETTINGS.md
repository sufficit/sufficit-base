# Contrato de configurações globais de áudio e anúncios

`Sufficit.Telephony.Runtime.NativeTelephonySettings` é uma política global única,
identificada pela seção `native-telephony`. Audio e Announcements são gravados e
capturados juntos. Não contém financeiro, credenciais, endereços de conexão ou
opções de DID testing/outbound.

Todos os campos são obrigatórios. Parse rejeita propriedades desconhecidas, GUIDs
vazios/duplicados, prefixos não canônicos, escopos de anúncios fora dos contextos de
áudio e descoberta automática fora do escopo de anúncios. Áudio habilitado exige
contextos, nós de cobertura e prefixo. Announcements habilitado exige Audio habilitado.
Arrays vazios de AudioIds/AnnouncementIds mantêm a semântica existente de ausência
de seleção de piloto; não representam acesso livre a áudios de outros clientes.

Document valida e serializa a política completa; Parse limita tamanho e profundidade.
A captura de runtime retorna cópia para impedir que consumidores mutem o snapshot.
A seleção/gravação das versões pertence à persistência, não ao contrato.

Validação desta entrega: contrato exercitado por RuntimeSettingsTests de EFData e
EndPoints e build Release nos três TFMs de Standard/Base. Não comprova instalação.
