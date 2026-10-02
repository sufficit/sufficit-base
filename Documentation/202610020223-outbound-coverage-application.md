# Consumidor de troncos de saída por eventos — 02/10/2026

## Alterações
- Evento comercial inclui LegacyOutboundChannels, normalizado da semântica legada,
  sem expor Extra ou outros textos privados. A identidade continua sendo o GUID.
- ContractOutboundCoverage preserva canais e datas inclusivas do legado. Eventos
  anteriores sem capacidade explícita não podem reduzir fixo/móvel a um canal.
- ReadForApplication exige recibo íntegro e ausência de lacunas conhecidas, em
  transação consistente e com a estratégia de retentativas do provedor.
- ApplyCoverage aplica os cinco tipos de tronco usando apenas a inbox local.
  Mantém proteção concorrente e as autorizações separadas de aplicação e remoção.
- Após commit no destino, registra auditoria outbound-trunks-applied vinculada a
  cliente, evento, versão e hash. Se falhar a auditoria, não confirma a entrega;
  a repetição recalcula a cobertura atual. Não confirma DID/PBX/crédito.
- SalesOutboundProjectionWriter seleciona esse caminho com
  Sufficit:CheckUp:OutboundProjectionSource=CoverageInbox. Ausência de configuração
  preserva Contracts. Valor desconhecido falha; não há fallback silencioso.

## Verificações
30 testes EFData e22 Standard passaram. MySQL8 isolado validou leitura com retries
habilitados e auditoria independente; demais cenários de eventos, renovação e
histórico vivo passaram. Container isolado removido. Build Release concluído.

## Limites operacionais
O modo CoverageInbox requer conexão explícita TelephonyCoverage, cobertura
recebida por eventos e transferência dos escritores antes de ativar as coortes.
Versões ainda não recebidas não são detectáveis por consulta local: essa
implementação não substitui o protocolo de transferência de autoridade.
Sessões reais MSSQL identificadas em EVEO-WEB/APOINT-WEB/CASTRUM-WEB. Não houve
retirada de banco, de agendamentos ou mudança de saldo de cliente.

## Publicação verificada
API EVEO1.26.1002.522 Healthy; Endpoints e Background active. Quatro DLLs verificadas
por SHA256 e sete configurações idênticas às anteriores. Rota administrativa sem
autenticação retornou401. Inclui também o histórico vivo implementado anteriormente.
Backup: /opt/sufficit-release-backups/coverage-live-20261002/endpoints-before.tar.gz
SHA256: ef2c0d189e68b33e2479dc3d4f7a6b21f0f6fc77272c1bcfcfe48ce07da93855.
Manifesto/resultado privado: tmp/coverage-release-verification.json.
Nenhuma coorte/flag foi habilitada; a instalação é compatível com os escritores
atuais. Retirada MSSQL permanece pendente das substituições descritas no plano.
