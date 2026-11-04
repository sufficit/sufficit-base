# Política de renovação por cliente — implementação parcial

Decisão do mantenedor: gerar ciclo na periodicidade contratada, manter serviço ativo e registrar dívida por padrão. Exceção por cliente exige pagamento para a próxima cobertura. Preservar preço, periodicidade, histórico e início após vencimento; compromisso de recarga não gera recebível pelo valor faltante.

Implementado: modelo e alteração auditada com revisão/idempotência, API com autorização por contexto, botão com confirmação e tratamento de erro, leitura técnica antiga condicionada ao pagamento, opt-in de ciclos pré-pagos adotados sem retroatividade. Migração SQL aditiva preparada, não aplicada.

Validação: PrepaidContract 68 aprovados; recorrência/financeiro EFData 24 aprovados mais regressão nova do débito pré-pago (suíte NativeLegacyBalancePosting com 11 aprovados). Blazor 46 testes relacionados e 14 testes do painel/botão aprovados; builds API e Blazor sem erros. Navegador em fixture isolada com componentes reais: cancelar/confirmar, estado salvo, 1440/768/390px sem overflow ou erros JS. Não é evidência de produção.

Bloqueio de publicação: SalesCoverageEventCapture e os consumidores do inbox ainda não transportam/aplicam a política. O writer FreePBXInboundDelivery não remove uma rota já aplicada por falta de cobertura; CheckUpDIDExpiration apenas notifica. É necessário um comando operacional auditado e reversível de suspensão/restauração, vinculado ao cliente/contrato/DID confirmado, com proteção contra edições de gestores e recibos de aplicação. Não ativar a flag Sufficit:Sales:CustomerRenewalPolicyEnabled na API/Blazor até resolver e validar todos os consumidores. A flag está desligada por ausência de configuração.

Nenhuma publicação, mudança de política em produção, cobrança, suspensão, renovação real ou ativação da Torres foi executada nesta entrega. Trabalho restante registrado no plano de EndPoints.

Verificação final Blazor: 41 testes passaram; 1 falhou no verificador global de documentação por planos e fixtures preexistentes sem links (fora desta alteração). Não corrigidos nesta tarefa. Alterações paralelas de IVR foram preservadas.
