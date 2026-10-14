# Cobrança consolidada — implementação local (14/10/2026)

Entrega coordenada em Base, EFData, Client, EndPoints, Checkout e Blazor. Plano e evidências em `sufficit-endpoints/docs/PLAN-UNIFIED-CUSTOMER-CHECKOUT.md`.

Serviços usam cobrança unificada por padrão e podem ser avulsos; cada cobrança tem itens imutáveis e um pagamento. Gestão do link fica em Cobranças do cliente, acessível na lista de serviços. Cobranças antigas e competências reservadas são preservadas. PIX/boleto quitam o ciclo e cartão recorrente pode automatizar mensalidades fixas sem prazo final.

Validação: 10 testes EndPoints, 180 Checkout, Blazor compilado sem erros, migração MariaDB 11.4.13 executada duas vezes e quatro restrições verificadas. Fixture estática com CSS SUI sem overflow em 390/1280/1920; tela autenticada e produção não validadas.

Nenhuma transação real ou migração de produção feita. Feature flag desligada por padrão. Não publicar bibliotecas antes do schema aditivo. Publicação bloqueada pelo guard oficial de áudio em EndPoints, pendente de decisão específica do usuário. Autorizações existentes não são canceladas automaticamente e exigem encerramento/reconciliação assistida antes de alterar termos.
