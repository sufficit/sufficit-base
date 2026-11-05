# Reconciliação de autorização sem vencimento

A condição NoExpiration é explícita e independente de Expire. Quando verdadeira, Expire guarda a data histórica (ou o instante de ingresso em registros novos) e não limita autorização. Não há data futura fictícia. Contratos cancelados/futuros não concedem canais; cancelamento da projeção continua sujeito à autorização de remoção.

A migração aditiva no_expiration tem padrão false. Aplicada em 05/11/2026: 1.232 registros preservados integralmente e zero registros indefinidos. Ativar clientes somente depois de atualizar todos os leitores FastAGI. O campo anterior mantém sua assinatura e dados.

Projeção traduz End nulo; persistência mantém a data histórica, suporta retorno a prazo finito e replay idempotente. FastAGI usa a consulta ActiveAt (NoExpiration OU prazo vigente). Importadores preservam a condição indefinida. Reconciliador legado recusa reescrever esses contextos, que pertencem ao consumidor de cobertura.

Testes: 9 de persistência e 24 de projeção/importação passaram. Regressão comprovada: filtro antigo ignorou tronco indefinido cuja data histórica venceu (esperava 2 importados, obteve 1); filtro corrigido passou. Builds de FastAGI net7/net10, EndPoints e Background preparados. A implantação ainda requer troca coordenada dos processos. O runbook FastAGI determina janela de madrugada para Google, com trava AGI, aquecimento, teste sintético e rollback.

Escopo comercial confirmado continua em 112 clientes R & L; nenhuma nova alteração de End nem ativação do consumidor nesta preparação. Manter portabilidades/cancelados e exceções LE SAC/Tramontina separados. Plano principal: sufficit-standard/docs/PLAN-RL-SINGLE-20261105.md.
