# Gateway ReceitaWS

## Descrição

O Gateway ReceitaWS é um componente de integração com a API externa ReceitaWS (receitaws.com.br), que permite consultar informações públicas sobre empresas brasileiras através do CNPJ. Fornece dados como nome da empresa, endereço, atividades econômicas e situação cadastral, facilitando validações e preenchimento automático em formulários e assistentes do sistema Sufficit.

## Funcionalidades

- Consulta de informações básicas de empresas por CNPJ
- Mapeamento completo dos campos da API ReceitaWS
- Integração com ASP.NET Core via HttpClient
- Tratamento de erros e logging
- Extensões para conversão de dados para formato Person padronizado
- Suporte a cancelamento de operações assíncronas

## Arquitetura

### Componentes Principais

- **ReceitaWSService**: Serviço principal para consultas na API ReceitaWS
- **ReceitaWSServiceExtensions**: Métodos de extensão para conversão de dados
- **ReceitaWSController**: Controller da API para endpoints públicos

### Fluxo de Dados

```
Cliente → ReceitaWSController → ReceitaWSService → API ReceitaWS
                                      ↓
                         ReceitaWSServiceExtensions → Person (formato padronizado)
```

## Como Usar

### Endpoint da API

```
GET /Gateway/ReceitaWS/{cnpj}
```

**Exemplo:**
```
GET /Gateway/ReceitaWS/13151997000122
```

### Resposta

Retorna um objeto `JsonElement` com os dados brutos da empresa da API ReceitaWS.

### Autorização

Requer política "ManagerOnly" (roles: Manager ou Administrator).

## Estrutura de Arquivos

- `sufficit-standard/src/Gateway/ReceitaWS/ReceitaWSService.cs`: Serviço principal
- `sufficit-standard/src/Gateway/ReceitaWS/ReceitaWSServiceExtensions.cs`: Extensões para conversão
- `sufficit-standard/src/Gateway/ReceitaWS/ServiceCollectionExtensions.cs`: Configuração DI
- `sufficit-endpoints/src/Controllers/Gateway/ReceitaWSController.cs`: Controller da API
- `README.md`: Esta documentação

## Dependências

- `System.Text.Json` para serialização
- `System.Net.Http` para chamadas HTTP
- `Microsoft.Extensions.Logging` para logging
- `Microsoft.Extensions.Http` para HttpClient factory
- ASP.NET Core para endpoints

## Exemplo de Uso no Código

### Consulta Básica

```csharp
// Injeção de dependência
private readonly ReceitaWSService _receitaWSService;

public MyService(ReceitaWSService receitaWSService)
{
    _receitaWSService = receitaWSService;
}

// Consulta de dados brutos
var dadosEmpresa = await _receitaWSService.GetCompanyInfoAsync("13151997000122");
```

### Conversão para Person

```csharp
// Usando extensão para obter dados no formato Person
var pessoa = await _receitaWSService.GetPersonAsync("13151997000122");

if (pessoa != null)
{
    Console.WriteLine($"Empresa: {pessoa.Name}");
    Console.WriteLine($"Endereço: {pessoa.Address?.Street}, {pessoa.Address?.City}");
}
```

## Tratamento de Erros

- **400 Bad Request**: CNPJ inválido ou mal formatado
- **404 Not Found**: Empresa não encontrada
- **429 Too Many Requests**: Limite de requisições excedido
- **500 Internal Server Error**: Erro interno da API ReceitaWS

## Configuração

O serviço é registrado como singleton no container de DI:

```csharp
services.AddReceitaWSService(); // Registra ReceitaWSService como singleton
```

## Limitações da API

- Rate limiting: A API ReceitaWS possui limites de requisições
- Dados públicos: Apenas informações cadastrais públicas
- Atualização: Dados podem não estar 100% atualizados em tempo real