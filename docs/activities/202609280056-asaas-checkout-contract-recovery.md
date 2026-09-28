# Recuperação dos contratos da API Asaas Checkout

## Objetivo

Publicar em `main` os contratos de Checkout usados pelos controladores Asaas de `sufficit-endpoints` e ausentes da branch principal de Base.

## Estado inicial

O CI de Endpoints no SHA `447c1623f845a026b8363278a7a67864e447dad0` passou por checkout e Restore, mas falhou no Build com 18 diagnósticos CS0246. Faltavam tipos `CheckoutPayment*`, `CheckoutCardPay*`, `CheckoutAccountView` e `CheckoutWebhook*` definidos localmente em `src/Finance/CheckoutPaymentsContracts.cs`.

## Alterações

- Incluir somente `src/Finance/CheckoutPaymentsContracts.cs`, consumido pelos controladores `AsaasCheckoutPaymentsController` e `AsaasCheckoutPayersController` já presentes em Endpoints.
- Preservar fora do commit os arquivos staged e untracked de Sales e quaisquer outros trabalhos locais de Finance.

## Validação e acompanhamento

- CI Endpoints `36363228905`: Restore passou; Build falhou exclusivamente porque os tipos desse contrato ainda não estavam publicados em Base.
- `rtk dotnet restore ./src/Sufficit.Base.csproj` e `rtk dotnet build ./src/Sufficit.Base.csproj --no-restore --configuration Packing`: 3 projetos/frameworks, 0 erros, 33 avisos de nulabilidade.
- O CI de publicação de Base será disparado pelo push desta recuperação.
- O CI de Endpoints deve ser executado novamente quando os contratos estiverem disponíveis via `main`.
