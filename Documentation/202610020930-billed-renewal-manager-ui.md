# Entrada do gestor para renovação tarifada — 02/10/2026

## Entrega
API GET Sales/Contract/BilledRenewalAvailability informa disponibilidade conforme
catálogo e cliente autorizados, origem, estado e snapshot do contrato. A consulta
não concede autoridade: POST RenewBilled continua revalidando a transação.
SDK atualizado; editor Blazor de serviços contém painel de renovação com consulta,
confirmação, erro recuperável e sucesso. Salvar/remover/automação são bloqueados
enquanto a renovação está em andamento. O assistente da tela informa o caminho
explícito do gestor e não confunde recibo comercial com entrega do crédito.

BilledRenewalAttempt congela contrato/predecessor, serializa cliques concorrentes,
reenvia a mesma evidência após resposta perdida e guarda o recibo antes de atualizar
a tela. Não existe fallback para renovação MSSQL. A habilitação continua no servidor.

## Verificação
- Blazor compilou;4 testes da tentativa passaram (resposta perdida, concorrência,
  retorno ausente e GUID vazio).
- API:4 testes de autorização/validação passaram.
- Fixture local com componente real no navegador:1280 e390pixels;consulta
  indisponível, retentativa, sucesso, repetição bloqueada, mensagem vinculada e
  ausência de overflow verificados. Nenhuma chamada financeira real na fixture.
- Capturas privadas: tmp/billed-renewal-1280.png e billed-renewal-390.png.
- Teste reproduzível: validation/billed-renewal-preview/check.cjs; host temporário
  encerrado por seus PIDs explícitos após a validação.

## Publicação verificada
API EVEO 1.26.1002.1227 e Blazor EVEO 1.26.1002.1228 publicados e Healthy.
Endpoints, Background e Blazor ativos. Oito DLLs conferidas por SHA256 contra os
artefatos locais; sete configurações API e cinco Blazor idênticas às cópias locais
capturadas antes da publicação. Consulta anônima de disponibilidade retorna 401.
Evidência privada: tmp/billed-ui-release-verification.json.

O diretório remoto de backup citado durante a preparação não foi encontrado na
verificação final. Não considerar esse caminho um rollback disponível. As cópias
locais das configurações permitiram verificar sua preservação sem recriar um
manifesto a partir do estado posterior à publicação.

Nenhuma coorte ativada nem cliente renovado. Esta entrega completa a entrada de
renovação tarifada na tela nova; criação, edição, cancelamento, demais renovações
e efeitos operacionais restantes continuam no quadro vigente da migração.
Não representa retirada de uso do MSSQL. Publicação realizada a partir da árvore
local; commits/push e publicação equivalente nos demais hosts não foram verificados.
