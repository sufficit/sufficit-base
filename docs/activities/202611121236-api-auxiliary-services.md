# Serviços auxiliares, numeração e ledger da API

## Implementação
Voz e criação de ramais (incluindo política de senhas) migrados de Endpoints para
Standard, com DTOs em Base e consultas/gravações em EFData. ContractCheckoutService,
BillingCheckoutService e dependências comerciais necessárias migrados para
Standard; EFCheckoutSession encapsula contexto, transações, retry e gravações.
Preservados contratos HTTP/JSON, assinaturas HMAC, snapshots e histórico comercial.

Criação física/virtual compartilha lock transacional InnoDB por cliente, com revisão
aleatória antes de consultas de disponibilidade. Migração aditiva preparada; não
altera aliases ou credenciais existentes. Escritores externos não coordenados não
estão cobertos. Não foi testado um cluster Galera com dois nós.

Conflito de fingerprint retorna409. Consulta/reconciliação autorizada por cliente
mantém accepted/rejected/uncertain; somente sending de pelo menos15 minutos vira
uncertain. Nenhum reset/redial, nenhuma alegação de atendimento/áudio.

## Evidência realizada
- 347 regressões da API passaram (voz, criação, checkouts, direitos, segurança e arquitetura).
- 71 testes isolados de pré-pagos passaram.
- 19 testes de ledger passaram; a regressão HTTP409 falhou antes com InvalidOperationException.
- 2 testes com conexões MariaDB11.8 isoladas passaram. O baseline sem lock falhou
  por duas criações concorrentes do mesmo número. A proteção ReadCommitted
  passou; Serializable apresentou erro1020 na disputa por inserção da linha.
- Builds Standard net7 e netstandard2.0 passaram, incluindo dependências.
- 18 testes de DI/arquitetura/Markdown passaram.

## Entrega e limitações
Commit/push e candidato de publicação serão registrados após execução. Migração
nova ainda não aplicada em produção no momento deste registro. Falta contexto,
agente e destino autorizado para a chamada real. O plano permanece aberto por
esses checkpoints; nenhuma evidência de produção é inferida de testes locais.
