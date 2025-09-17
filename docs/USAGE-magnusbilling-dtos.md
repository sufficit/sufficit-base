# MagnusBilling Gateway - Base DTOs Documentation

## Overview

This document describes the MagnusBilling-compatible Data Transfer Objects (DTOs) and models in Sufficit.Base. All DTOs must provide 100% compatibility with MagnusBilling v7 data structures and JSON serialization.

## Architecture Principles

### DTO Design Rules
- **Multi-Target Compatible**: Support .NET Standard 2.0, .NET 6, 7, 8, 9
- **JSON Serialization**: Use System.Text.Json with proper attributes
- **MagnusBilling Field Names**: Exact field naming as in MagnusBilling database
- **String-Based IDs**: All ID fields as strings for JSON compatibility
- **No Business Logic**: Pure data structures without methods

### Serialization Standards
- Use `JsonPropertyName` for field mapping
- Use `JsonPropertyOrder` for consistent field ordering
- Use `JsonIgnore` for internal-only properties
- String format for all numeric IDs
- Date format: `yyyy-MM-dd HH:mm:ss`
- Decimal fields as strings with 4 decimal places

## Entity Categories

### Core Entities
Located in `/src/Gateway/MagnusBilling/Entities/`

#### 1. User Management
- `MagnusBillingUser.cs` - User accounts (pkg_user table)
- `MagnusBillingUserGroup.cs` - User groups (pkg_group_user table)
- `MagnusBillingUserPermission.cs` - User permissions

#### 2. Billing System
- `MagnusBillingPlan.cs` - Billing plans (pkg_plan table)
- `MagnusBillingRate.cs` - Tariff rates (pkg_rate table)
- `MagnusBillingPrefix.cs` - Destination prefixes (pkg_prefix table)

#### 3. Call Records
- `MagnusBillingCall.cs` - Call detail records (pkg_call table)
- `MagnusBillingCallSummary.cs` - Call aggregations
- `MagnusBillingCallDst.cs` - Call destinations

#### 4. Financial
- `MagnusBillingRefill.cs` - Account refills (pkg_refill table)
- `MagnusBillingInvoice.cs` - Generated invoices
- `MagnusBillingPayment.cs` - Payment records

### Authentication Entities
Located in `/src/Gateway/MagnusBilling/Authentication/`

#### 1. API Authentication
- `MagnusBillingApiKey.cs` - API key/secret pairs
- `MagnusBillingApiKeyContext.cs` - API key contexts and permissions

#### 2. Entity Mapping
- `MagnusBillingEntityMapping.cs` - ID mapping between systems

### Search Parameters
Located in `/src/Gateway/MagnusBilling/SearchParameters/`

#### 1. Entity Search Parameters
- `MagnusBillingUserSearchParameters.cs`
- `MagnusBillingCallSearchParameters.cs`
- `MagnusBillingPlanSearchParameters.cs`
- `MagnusBillingRateSearchParameters.cs`

#### 2. Authentication Search
- `MagnusBillingApiKeySearchParameters.cs`

### Request/Response DTOs
Located in `/src/Gateway/MagnusBilling/Requests/` and `/src/Gateway/MagnusBilling/Responses/`

#### 1. API Requests
- `MagnusBillingGetUsersRequest.cs`
- `MagnusBillingGetCallsRequest.cs`
- `MagnusBillingCreateUserRequest.cs`
- `MagnusBillingUpdateUserRequest.cs`

#### 2. API Responses
- `MagnusBillingResponse.cs` - Base response structure
- `MagnusBillingUsersResponse.cs`
- `MagnusBillingCallsResponse.cs`
- `MagnusBillingErrorResponse.cs`

## Field Naming Conventions

### MagnusBilling Standard Fields
Must match MagnusBilling database exactly:

```csharp
[JsonPropertyName("id")]
public string Id { get; set; } = string.Empty;

[JsonPropertyName("username")]
public string Username { get; set; } = string.Empty;

[JsonPropertyName("firstname")]
public string FirstName { get; set; } = string.Empty;

[JsonPropertyName("lastname")]
public string LastName { get; set; } = string.Empty;

[JsonPropertyName("creationdate")]
public string CreationDate { get; set; } = string.Empty;
```

### Date Format Standard
All dates as strings in `yyyy-MM-dd HH:mm:ss` format:

```csharp
[JsonPropertyName("creationdate")]
public string CreationDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
```

### Decimal Format Standard
Decimal values as strings with 4 decimal places:

```csharp
[JsonPropertyName("credit")]
public string Credit { get; set; } = "0.0000";

[JsonPropertyName("cost")]
public string Cost { get; set; } = "0.0000";
```

### Boolean Format Standard
Boolean values as strings "0" or "1":

```csharp
[JsonPropertyName("active")]
public string Active { get; set; } = "1";
```

## Entity Structure Examples

### User Entity Structure
```csharp
public class MagnusBillingUser
{
    [JsonPropertyOrder(1)]
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyOrder(2)]
    [JsonPropertyName("id_group")]
    public string IdGroup { get; set; } = "1";

    [JsonPropertyOrder(3)]
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    
    // Additional properties following same pattern
}
```

### Call Entity Structure
```csharp
public class MagnusBillingCall
{
    [JsonPropertyOrder(1)]
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyOrder(2)]
    [JsonPropertyName("id_user")]
    public string IdUser { get; set; } = string.Empty;

    [JsonPropertyOrder(3)]
    [JsonPropertyName("calledstation")]
    public string CalledStation { get; set; } = string.Empty;
    
    // Additional call-specific properties
}
```

## Response Wrapper Structures

### Standard Success Response
```csharp
public class MagnusBillingResponse<T>
{
    [JsonPropertyOrder(1)]
    [JsonPropertyName("success")]
    public bool Success { get; set; } = true;

    [JsonPropertyOrder(2)]
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyOrder(3)]
    [JsonPropertyName("rows")]
    public T[] Rows { get; set; } = Array.Empty<T>();
}
```

### Error Response Structure
```csharp
public class MagnusBillingErrorResponse
{
    [JsonPropertyOrder(1)]
    [JsonPropertyName("success")]
    public bool Success { get; set; } = false;

    [JsonPropertyOrder(2)]
    [JsonPropertyName("errors")]
    public string Errors { get; set; } = string.Empty;

    [JsonPropertyOrder(3)]
    [JsonPropertyName("msg")]
    public string Message { get; set; } = string.Empty;
}
```

## Search Parameters Pattern

### Base Search Parameters
All search parameters inherit from `SearchParameters`:

```csharp
public class MagnusBillingUserSearchParameters : SearchParameters
{
    // MagnusBilling specific filters
    public string? Id { get; set; }
    public string? Username { get; set; }
    public string? IdGroup { get; set; }
    
    // Standard Sufficit filters
    public TextFilter? FirstNameFilter { get; set; }
    public TextFilter? EmailFilter { get; set; }
    public DateTimeRangeNew? CreationDateRange { get; set; }
    public NumericRange? CreditRange { get; set; }
}
```

## Validation Patterns

### Required Field Validation
```csharp
[JsonPropertyName("username")]
[Required(ErrorMessage = "Username is required")]
[StringLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
public string Username { get; set; } = string.Empty;
```

### Format Validation
```csharp
[JsonPropertyName("email")]
[EmailAddress(ErrorMessage = "Invalid email format")]
public string Email { get; set; } = string.Empty;
```

## Multi-Target Framework Support

### Conditional Compilation
For framework-specific features:

```csharp
#if NET6_0_OR_GREATER
    [JsonPropertyName("modern_feature")]
    public string ModernFeature { get; set; } = string.Empty;
#endif
```

### Compatible Serialization
Ensure compatibility across all target frameworks:

```csharp
// Use compatible JsonPropertyName instead of JsonPropertyName with options
[JsonPropertyName("creation_date")]
public string CreationDate { get; set; } = string.Empty;
```

## File Organization

### Directory Structure
```
src/Gateway/MagnusBilling/
├── Entities/
│   ├── MagnusBillingUser.cs
│   ├── MagnusBillingCall.cs
│   ├── MagnusBillingPlan.cs
│   └── MagnusBillingRate.cs
├── Authentication/
│   ├── MagnusBillingApiKey.cs
│   └── MagnusBillingEntityMapping.cs
├── SearchParameters/
│   ├── MagnusBillingUserSearchParameters.cs
│   └── MagnusBillingCallSearchParameters.cs
├── Requests/
│   ├── MagnusBillingGetUsersRequest.cs
│   └── MagnusBillingCreateUserRequest.cs
└── Responses/
    ├── MagnusBillingResponse.cs
    └── MagnusBillingErrorResponse.cs
```

### Naming Conventions
- One class per file
- File name matches class name exactly
- Namespace reflects folder structure
- PascalCase for class and property names
- MagnusBilling prefix for all classes

## Testing Considerations

### Serialization Testing
- Test JSON serialization/deserialization
- Verify field names match MagnusBilling exactly
- Validate date format consistency
- Test multi-target framework compatibility

### Validation Testing
- Test required field validation
- Test format validation (email, phone)
- Test string length limits
- Test numeric range validation

## Implementation Checklist

### DTO Requirements
- [ ] Inherits appropriate base class if needed
- [ ] All properties have JsonPropertyName attributes
- [ ] JsonPropertyOrder for consistent serialization
- [ ] String-based ID fields
- [ ] Proper date format handling
- [ ] Decimal fields as strings
- [ ] Boolean fields as "0"/"1" strings
- [ ] Multi-target framework compatible

### Search Parameter Requirements
- [ ] Inherits from SearchParameters
- [ ] Includes MagnusBilling-specific filters
- [ ] Uses Sufficit standard filter types
- [ ] Proper JSON serialization attributes
- [ ] Nullable types for optional filters

### Response DTO Requirements
- [ ] Follows MagnusBilling response structure
- [ ] Proper success/error format
- [ ] Consistent field ordering
- [ ] Generic type support for data arrays

## Dependencies

### Required Packages
- System.Text.Json
- System.ComponentModel.DataAnnotations
- Sufficit.Base (for base classes)

### Framework Targets
- .NET Standard 2.0
- .NET 6.0
- .NET 7.0  
- .NET 8.0
- .NET 9.0