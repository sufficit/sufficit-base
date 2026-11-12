# Serviços auxiliares, numeração e ledger da API

Versão **1.26.1112.1543** publicada e conferida nos três hosts de produção.

## Implementação

VoiceSupportRuntime, EndPointCreationRuntime e a política de senhas saíram da API
para Standard. ContractCheckoutService, BillingCheckoutService, assinatura de
links, opções, política de direitos e métodos de pagamento também ficam em
Standard. Base contém os DTOs compartilhados. EFData encapsula consultas de voz,
criação e contexto/gravações/transações/retry dos checkouts. Preservados contratos
HTTP/JSON, assinaturas HMAC, snapshots emitidos, credenciais e histórico comercial.
Não houve alteração de contrato nem operação de pagamento como teste.

Criação física/virtual usa uma escrita InnoDB por cliente, com revisão aleatória,
antes da primeira consulta e na mesma transação ReadCommitted. Migração aditiva
aplicada em dbvoiprt, sem alterar aliases. O ledger mantém os mesmos cinco claims
e o mesmo digest calculado sobre todos os seus campos.

Conflito de RequestId retorna HTTP 409. Consulta e conciliação do ledger são
filtradas/autorizadas por contexto e agente; somente sending de pelo menos
15 minutos pode virar uncertain. Estados finais permanecem; nunca há reset,
rediscagem ou afirmação de atendimento/áudio.

## Validação realizada

- 347 regressões contra as DLLs candidatas da API.
- 71 testes isolados de pré-pagos; 66 testes de boletos contra o Standard candidato.
- 88 testes Asaas e 52 EFI contra os gateways candidatos.
- Dois testes de concorrência com sessões MariaDB 11.8 isoladas, incluindo criação
  física contra virtual. Baseline sem lock falhou por duas criações do mesmo número;
  com coordenação, somente uma criou. Não foi usado banco de produção para corridas.
- Regressão HTTP 409 vermelha antes; 19 testes de ledger verdes após a correção.
- Builds Standard net7 e netstandard2.0; 18 testes de DI/arquitetura/Markdown e
  oito testes Markdown de EFData. Trinta guardas de deploy aprovados.
  Documentação final da API: oito testes Markdown aprovados após o fechamento.
- Closure sem referências ausentes e 2678 tipos da API carregados no contexto candidato.
- Catálogo candidato e leitura final: 25 itens, 19 grupos e seis vínculos ProductId
  explícitos preservados no JSON. Hashes dos quatro módulos correspondem ao candidato.

## Publicação e reconciliação

Fonte exportada de 31 commits publicados, sem incluir alterações locais paralelas.
O primeiro candidato foi promovido no Eveo; o preflight de Castrum detectou DLLs
Asaas/EFI alteradas e recusou a promoção antes de parar ou alterar esse host.
Reexportado e revalidado o candidato final com Asaas ea61eb0 e EFI 751d248,
preservando as correções concorrentes de datas. A versão final foi promovida em
Eveo, Castrum e Apoint, pelo deploy.py guardado. Nenhuma DLL externa mudou.

| Host | Serviço/HTTPS | Arquivos conferidos | Rotas protegidas |
| --- | --- | --- | --- |
| eveo-apps | ativo / Healthy, TLS válido | 175, sem divergências | HTTP 401/403, incluindo status e conciliação |
| castrum-apps | ativo / Healthy, TLS válido | 175, sem divergências | HTTP 401/403, incluindo status e conciliação |
| apoint-apps | ativo / Healthy, TLS válido | 175, sem divergências | HTTP 401/403, incluindo status e conciliação |

Helpers presentes, configuração persistente preservada e retenção de três backups
por host pelo fluxo padrão. Não foi necessário rollback. Artefatos e fontes
exportadas próprios foram removidos após a confirmação, preservando logs e manifests.

## Fonte e entrega

- sufficit-base: `3611a234fe008d5972e7aca4da28a95f81bf79bf` (código em main e origin/main).
- sufficit-efdata: `9c798d744200d6e74416f12d75635276481ff744` (código em main e origin/main).
- sufficit-standard: `12e0a0a74bd96fced79d60f6eb3850a9539ddeae` (código em main e origin/main).
- sufficit-endpoints: `0169a620c17162796a3ee1774f51e8c4cff91f18` (código em main e origin/main).

## Limitações e checkpoint pendente

Escritores legados externos aos runtimes migrados precisam adotar a coordenação;
não existe unicidade cega sobre aliases legados. Não foi executado teste entre
nós de um cluster Galera. Não houve chamada real de voz: falta identificar o
cliente/contexto, o agente e o destino autorizado. O plano permanece aberto
exclusivamente por esse checkpoint; implementação, validação e publicação acima
estão comprovadas.
