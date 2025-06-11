<h1>
  Sufficit.Base
  <a href="https://github.com/sufficit"><img src="https://avatars.githubusercontent.com/u/66928451?s=200&v=4" alt="Sufficit Logo" width="80" align="right"></a>
</h1>

[![NuGet](https://img.shields.io/nuget/v/Sufficit.Base.svg)](https://www.nuget.org/packages/Sufficit.Base/)

## 📖 About the Project

`Sufficit.Base` is a foundational library for the entire Sufficit software ecosystem. It provides the most essential and widely-used components, including base classes, core interfaces, utility methods, and data transfer objects (DTOs) that serve as the building blocks for other Sufficit projects.

The goal of this library is to promote code reuse, consistency, and a common development standard across all our applications and services.

### ✨ Key Features

* Core interfaces and abstract base classes for common patterns (e.g., Services, Repositories).
* Commonly used data models and DTOs.
* A rich set of helper classes and extension methods.
* Shared constants, enumerations, and attributes used throughout the ecosystem.

## 🚀 Getting Started

This project is a class library. The recommended way to use it is by installing the NuGet package into your project.

### 📦 NuGet Package

You can install the package via the .NET CLI or the NuGet Package Manager Console.

**.NET CLI:**

    dotnet add package Sufficit.Base

**Package Manager Console:**

    Install-Package Sufficit.Base

## 🛠️ Usage

As a foundational library, `Sufficit.Base` is designed to be a dependency for nearly all other projects within the Sufficit ecosystem.

**Example of a base model usage:**

    using Sufficit.Base;
    
    public class User : IID
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }

**Example of an extension method:**

    using Sufficit.Base.Extensions;

    var text = " some text with extra spaces ";
    var cleanedText = text.TrimAndLower();
    // Result: "some text with extra spaces"
    
## 🤝 Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1.  Fork the Project.
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`).
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`).
4.  Push to the Branch (`git push origin feature/AmazingFeature`).
5.  Open a Pull Request.

## 📄 License

Distributed under the MIT License. See `LICENSE` for more information.

## 📧 Contact

Sufficit - [contato@sufficit.com.br](mailto:contato@sufficit.com.br)

Project Link: [https://github.com/sufficit/sufficit-base](https://github.com/sufficit/sufficit-base)