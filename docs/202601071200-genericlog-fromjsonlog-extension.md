# 202601071200 - Nova Extensão GenericLog FromJsonLog

## Resumo
Adição de nova extensão `FromJsonLog<T>` na classe `GenericLogExtensions` em `Sufficit.Base`, permitindo conversão de `GenericLog<string>` para `GenericLog<T>` com desserialização automática do conteúdo JSON.

## Contexto
Durante investigação de duplicação de código no projeto `Sufficit.Client`, foi identificado que a lógica de conversão entre tipos `GenericLog` estava sendo implementada manualmente em múltiplos locais. Uma extensão similar já existia em `Sufficit.EFData`, mas não era acessível ao `Sufficit.Client` devido a dependências.

## Implementação
- **Namespace**: `Sufficit.Logging`
- **Classe**: `GenericLogExtensions`
- **Método**: `public static GenericLog<T> FromJsonLog<T>(this GenericLog<string> source, JsonSerializerOptions? options = null) where T : class`

## Funcionalidade
A extensão:
1. Verifica se o `source` já é do tipo `GenericLog<T>` (otimização)
2. Cria nova instância de `GenericLog<T>`
3. Copia todas as propriedades base (`ContextId`, `ClassName`, `Duration`, etc.)
4. Desserializa o campo `Content` de string JSON para objeto do tipo `T` usando `JsonSerializer.Deserialize`
5. Trata casos onde `Content` é null ou whitespace retornando `default(T)`

## Uso
```csharp
var stringLog = new GenericLog<string> { Content = "{\"name\":\"test\"}", /* outras propriedades */ };
var typedLog = stringLog.FromJsonLog<MyClass>(jsonOptions);
```

## Benefícios
- **Reutilização**: Elimina duplicação de código de conversão
- **Consistência**: Padrão uniforme para conversão de logs
- **Manutenibilidade**: Lógica centralizada em um local
- **Flexibilidade**: Suporte a opções customizadas de JSON

## Dependências
- `System.Text.Json` (já incluído em `Sufficit.Base`)
- Não requer dependências adicionais

## Compatibilidade
- Compatível com todas as plataformas alvo do projeto (.NET 7.0, 8.0, 9.0, netstandard2.0)
- Thread-safe (não mantém estado)