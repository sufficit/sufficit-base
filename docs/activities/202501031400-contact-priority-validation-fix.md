> Migrated from sufficit-project-management/docs/202501031400-contact-priority-validation-fix.md on 2026-10-24.

# Correção do Erro de Validação do Campo Priority em Contact

**Data:** 03/01/2025  
**Versão:** 1.0  
**Autor:** GitHub Copilot  

## Problema Identificado

O endpoint `/notification/contact` estava retornando o seguinte erro ao tentar deserializar JSON:
```
The field of type System.Int32 must be a string, array or ICollection type.
```

## Causa Raiz

O campo `Priority` na classe `Contact` estava incorretamente anotado com `[MaxLength(11)]`:

```csharp
[MaxLength(11)]
public int? Priority { get; set; }
```

O atributo `MaxLength` só é válido para tipos string, arrays ou ICollection. Aplicá-lo a um tipo `int?` causava erro na validação do modelo durante a deserialização JSON.

## Solução Implementada

Removido o atributo `[MaxLength(11)]` do campo `Priority` na classe `Contact`:

### Arquivo: `sufficit-base/src/Notification/Contact.cs`

**Antes:**
```csharp
[JsonPropertyName("priority")]
[JsonPropertyOrder(4)]
[MaxLength(11)]
public int? Priority { get; set; }
```

**Depois:**
```csharp
[JsonPropertyName("priority")]
[JsonPropertyOrder(4)]
public int? Priority { get; set; }
```

## Arquivos Modificados

- `sufficit-base/src/Notification/Contact.cs` - Removido atributo `[MaxLength(11)]`

## Configuração do Banco de Dados

O mapeamento do Entity Framework já estava correto para limitar o campo a INT(11):
```csharp
// em sufficit-efdata/src/Notification/ModelBuilderHelper.cs
entity.Property(e => e.Priority)
    .HasColumnType("INT(11)")
    .HasColumnName("priority");
```

## Compilação e Deploy

- ✅ Compilação do projeto `sufficit-base`: Sucesso
- ✅ Compilação do projeto `sufficit-endpoints`: Sucesso  
- ✅ Publicação para produção: Concluída

## Teste Recomendado

Teste o endpoint `/notification/contact` com um payload JSON contendo campo priority:
```json
{
    "id": "123",
    "title": "Test Contact",
    "description": "Test Description",
    "priority": 5
}
```

## Lições Aprendidas

1. **Validação de Atributos:** O atributo `[MaxLength]` é específico para tipos string, arrays e ICollection
2. **Separação de Responsabilidades:** Validação de tamanho para campos numéricos deve ser feita no banco de dados (como já estava configurado)
3. **Teste de Validação:** Sempre testar endpoints após mudanças em modelos de dados

## Status

- [x] Problema identificado
- [x] Correção implementada
- [x] Código compilado
- [x] Deploy realizado
- [ ] Teste funcional do endpoint (pendente)
