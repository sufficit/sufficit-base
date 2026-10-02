# Critério de cumprimento do compromisso — decisão aplicada

## Regra confirmada
- Serviço não recorrente: ativação autorizada pelo gestor conta mesmo sem saldo financeiro ou pagamento prévio. O pagamento posterior não gera segunda contribuição.
- Serviço recorrente: pagamento confirmado conta; ativação isolada não conta.
- As duas origens podem participar do mesmo ciclo/aniversário. A opção do cliente continua controlando a participação do 0800.

## Código local
CallCreditContribution agora informa ServiceIsRecurring (nullable: desconhecido), Trigger e OccurredAtUtc. O evento é AuthorizedServiceActivation ou ConfirmedPayment. A origem comercial é Recharge/TollFreeCredit, separada da evidência de pagamento. Foram removidos os nomes locais PaidRecharge/PaidTollFreeCredit e CreditedAtUtc, ainda não publicados, pois não descreviam corretamente os serviços avulsos ativados a prazo.
Para pagamentos, Amount é a parcela confirmada atribuída ao crédito elegível, nunca o total indiscriminado de um boleto que inclui outros serviços. A data é a confirmação do pagamento; para ativação, a data do evento autorizado. Recorrência/evento desconhecidos deixam a avaliação inconclusiva. Duplicatas conflitantes incluem comparação desses novos campos.

## Validação
19 testes CallCreditCommitment aprovados em net10.0, incluindo seis novos casos para ativação sem pagamento, ausência de dupla contagem, pagamento parcial em outro ciclo, combinação com 0800 e evidência ausente/inválida. Log: /mnt/workspaces/sufficit/tmp/commitment-trigger-tests.log.

## Integração pendente
O checkout recorrente existente registra ConfirmedReceiptUtc e PaidAtUtc separadamente; Observe em EndPoints/Sales/ContractCheckoutService.cs valida o recebimento antes de preenchê-lo. Esse é um ponto de integração identificado, ainda não conectado ao avaliador. A recorrência por contratação e a classificação do crédito precisam de vínculo explícito; não deduzir pela descrição comercial nem pelo saldo disponível.
Continuam abertos os adaptadores das fontes reais, o vínculo ao contrato, a redefinição manual auditada e a publicação. Não houve migração de dados nem alteração de saldo/tarifa nesta etapa. A decisão comercial anterior deixou de ser bloqueio; as pendências agora são de implementação.
