> Migrated from sufficit-project-management/docs/202508181430-contact-priority-validation-fix.md on 2026-10-24.

# Contact Priority Field Validation Fix

**Data:** 18/08/2025 14:30
**Autor:** GitHub Copilot
**Tipo:** Bug Fix

## Problema Identificado

O endpoint `/notification/contact` estava retornando o erro:
```
"The field of type System.Int32 must be a string, array or ICollection type."
```

## Causa Raiz

O problema estava na propriedade `Priority` da classe `Contact` em `sufficit-base/src/Notification/Contact.cs`:

```csharp
[JsonPropertyName("priority")]
[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
[MaxLength(11)]  // <- PROBLEMA AQUI
public int? Priority { get; set; }
```

O atributo `[MaxLength(11)]` não é válido para tipos numéricos como `int?`. Este atributo é usado apenas para:
- `string`
- Arrays (`T[]`)
- Coleções que implementam `ICollection`

## Solução Implementada

Removido o atributo `[MaxLength(11)]` incorreto:

```csharp
[JsonPropertyName("priority")]
[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
public int? Priority { get; set; }
```

## Validação da Solução

A validação do tamanho do campo `Priority` já é feita corretamente no Entity Framework através da configuração em `ModelBuilderHelper.cs`:

```csharp
entity.Property(a => a.Priority)
    .HasColumnName("prio")
    .HasColumnType("INT(11)");
```

## Arquivos Alterados

- `sufficit-base/src/Notification/Contact.cs`

## Teste

Após a correção, o seguinte JSON deve ser processado sem erros:

```json
{
    "id": "f7b62927-8aea-41d0-b077-635cb801c8d1",
    "contextid": "d21cfb04-9d37-473b-837c-67591a26feed",
    "channel": "WEBHOOK",
    "priority": 1,
    "destination": "http://187.108.193.40:5678/webhook/chatwoot/voip",
    "timestamp": "2025-06-02T16:51:58Z"
}
```

## Lições Aprendidas

- Atributos de validação devem ser apropriados para o tipo de dados
- `[MaxLength]` não deve ser usado em tipos numéricos
- Para campos numéricos, use `[Range]` se necessário validar limites
