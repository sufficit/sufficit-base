# Publicação compatível e impedimentos ao corte MSSQL — 02/10/2026

## Produção verificada
API 1.26.1002.1308 publicada pelo deploy oficial em EVEO, APOINT e CASTRUM.
Doze hashes de DLLs e 21 configurações verificados contra artefatos/estado anterior;
três endpoints de saúde Healthy. Pacote inclui o consumidor Caller ID por inbox
validado na etapa anterior (27 testes Standard e 33 EFData).

Backup anterior de cada host preservado em
/opt/sufficit-release-backups/caller-inbox-20261002/endpoints-before.tar.gz.
Configurações próprias de cada host foram preservadas; não copiar configuração
EVEO para outros hosts. Em APOINT a primeira sondagem ocorreu antes da abertura
da porta; logs confirmaram inicialização, e a nova sondagem validou Healthy.
Nenhum novo restart ou nova publicação foi necessário para essa sondagem.

## Limite desta entrega
Publicação compatível: nenhuma coorte de corte habilitada, agendamento removido ou
MSSQL desligado. A implementação foi publicada a partir da árvore local, não de
um commit limpo; isso não comprova equivalência de futuros builds do CI.

Consulta atual de fonte confirma os três Webs conectados; tabela de autoridade e
trigger de bloqueio ausentes. Fluxos Web de edição/renovação/remoção, consultas
históricas/comissões via EFSalesDBContextMSSql, renovação genérica e coordenação
DID/PBX ainda impedem o corte. O consumidor Caller ID isolado não substitui esses
fluxos. Detalhes no plano principal, seção de evidência atual do impedimento.

Evidências privadas: tmp/caller-release-*-verification.json,
tmp/caller-release-deploy.log, tmp/caller-release-other-hosts.log,
tmp/caller-release-castrum.log, tmp/mssql-cutover-current.json.
