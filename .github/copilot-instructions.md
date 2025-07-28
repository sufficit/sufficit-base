# Copilot Instructions
<!-- Version: 202507151230 -->

## Common Guidelines
* whenever you find a newer Copilot Instructions file, merge the Common Guidelines content and adjust the version;
* code comments should always be in English;
* response to user queries should be in IDE current language;
* avoid to change code that was not related to the query;
* when agent has to change a method and it change the async status, the agent should update the method callers too;
* for extensions methods use always "source" as default parameter name
* use one file for each class
* for #region tags: no blank lines between consecutive regions, but always add one blank line after region opening and one blank line before region closing
* do not try to build if you just changed the code comments or documentation files;
* **when making relevant code changes, always create or update internal documentation following the Internal Documentation Guidelines**;

## Public Documentation Guidelines
* for github repository readme.md files, use the following structure:
  - Title
  - About (description, etc.)
  - Features
  - Installation
  - Usage (always on separated readme file, one for each case; testing, etc.)
  - License
  - Support (development@sufficit.com.br, etc.)
  - Related (references, thanks, etc.)
	 
## Internal Documentation Guidelines
* **Directory**: `/Documentation`, use this directory to store internal documentation files;
* **File Name**: use the following format for internal documentation files: `YYYYMMDDHHMM-description.md`, like `202507151109-migration.md`;
* **Content**: include detailed information about the internal processes, architecture decisions, and other relevant information that can help developers understand the system better;
* **Trigger Events**: create documentation for the following relevant changes:
  - New API implementations or client implementations
  - Significant architecture changes or refactoring
  - Breaking changes or deprecation of methods
  - New features or service integrations
  - Complex bug fixes that require explanation
  - Performance optimizations or security improvements
  - Database schema changes or migration procedures

## Sufficit Workspace Architecture

### 🏗️ Modular Layer Architecture
The Sufficit workspace follows a **modular, multi-layered architecture** designed for maximum reusability, maintainability, and separation of concerns across multiple .NET target frameworks.

### 📁 Core Projects Structure

#### **Foundation Layer**
- **`Sufficit.Base`** - Core DTOs, interfaces, models, and shared contracts
  - Contains fundamental data structures like `CallSearchParameters`, `DateTimeRangeNew`
  - Platform-specific implementations like `AsteriskCallDetailsRecordSearchParametersNew`
  - Target frameworks: .NET Standard 2.0, .NET 6, 7, 8, 9
  - **Purpose**: Shared contracts and data models across the entire ecosystem

- **`Sufficit.Utils`** - Extension methods, utilities, and helper functions
  - Extension methods for core types (e.g., `DateTimeRangeNewExtensions`)
  - Common utilities and helper classes
  - **Rule**: No business logic in Base - all utility methods go here

#### **Data Access Layer**
- **`Sufficit.EFData`** - Entity Framework Core implementations
  - Database contexts, entity configurations
  - Data access patterns and repositories

#### **Business Logic Layer**
- **`Sufficit.Standard`** - Core business logic and services
  - Service implementations and business rules
  - Provider patterns and concrete implementations

#### **Platform-Specific Layers**
- **`Sufficit.Asterisk.*`** - Asterisk PBX specific implementations
  - `Sufficit.Asterisk.Core` - Core Asterisk functionality
  - `Sufficit.Asterisk.Manager` - Manager interface implementations
  - `Sufficit.Asterisk.Shared` - Shared Asterisk components
  - `Sufficit.Asterisk.API` - REST API implementations

- **`Sufficit.Telephony.*`** - Telephony system abstractions
  - `Sufficit.Telephony.EventsPanel.Core` - Events panel functionality

#### **Gateway Layer**
- **`Sufficit.Gateway.*`** - External service integrations
  - Gateway implementations for third-party services
  - Payment gateways, communication services, etc.

#### **Client & Communication Layer**
- **`Sufficit.Client`** - Client-side implementations
- **`Sufficit.Communication`** - Communication protocols and messaging
- **`Sufficit.Identity.*`** - Authentication and authorization
  - `Sufficit.Identity.Core` - Core identity functionality
  - `Sufficit.Identity.Client` - Client-side identity management

#### **API Layer**
- **`Sufficit.EndPoints`** - Web API endpoints and controllers

### 🔄 Architecture Principles

#### **Separation of Concerns**
- **Base**: Pure DTOs and contracts (no business logic)
- **Utils**: Utility methods and extensions
- **Standard**: Business logic and services
- **Platform-Specific**: Technology-specific implementations

#### **Dependency Flow**
```
EndPoints → Standard → Platform-Specific → Base
    ↓           ↓            ↓           ↑
  Utils ← ← ← ← ← ← ← ← ← ← Utils
```

#### **Multi-Target Framework Support**
- **Compatibility**: .NET Standard 2.0 for maximum compatibility
- **Modern Features**: .NET 6+ for latest language features
- **Conditional Compilation**: Framework-specific features using `#if` directives

### 📋 Design Patterns

#### **Parameter Objects Pattern**
- `CallSearchParameters` (generic)
- `AsteriskCallDetailsRecordSearchParametersNew` (platform-specific)
- Clean separation between generic and technology-specific parameters

#### **Extension Method Pattern**
- All utility functionality implemented as extension methods in `Sufficit.Utils`
- Keeps base classes clean and focused on data structure

#### **Provider Pattern**
- Abstract providers in Base/Standard
- Concrete implementations in platform-specific projects

### 🎯 File Organization Rules

#### **Class-per-File Rule**
- Each class in its own file
- File name matches class name exactly

#### **Namespace Organization**
- Reflects physical folder structure
- Platform-specific namespaces (e.g., `Sufficit.Telephony.Asterisk`)

#### **Region Formatting**
```csharp
#region Properties

    public string Name { get; set; }

#endregion
#region Methods

    public void DoSomething() { }

#endregion
```

### 🚀 Benefits of This Architecture

1. **Modularity**: Independent, reusable components
2. **Scalability**: Easy to add new platforms and features
3. **Maintainability**: Clear separation of responsibilities
4. **Testability**: Clean interfaces and dependency injection
5. **Framework Flexibility**: Support for multiple .NET versions
6. **Performance**: Minimal dependencies in base layers