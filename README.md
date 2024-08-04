# .NET Core API Exercises

## Exercise 1: Building a Multi-Layer .NET Core 7.0 API from Zero

In this exercise, we’ll build a multi-layer .NET Core API from scratch using .NET Core 3.0. We will follow best practices and leverage the latest framework features and patterns.

### Overview

- **Objective**: Develop a multi-layered .NET Core API.
- **Framework**: .NET Core 7.0.0
- **Patterns**: Repository Pattern, Unit of Work Pattern, Code First with Entity Framework.

### Key Concepts

- **Multi-Layer Architecture**: Learn to separate the API into multiple modules to reduce dependencies on a single technology.
- **Core Design**: Understand the core structure of an application, and how to apply the Repository and Unit of Work patterns to abstract ORM usage.
- **ORM and Code First**: Utilize Entity Framework with Code First database design, ensuring a well-structured approach.
- **Business Layer**: Implement a Business Layer decoupled from any specific ORM.
- **API Layer**: Use Resources to avoid exposing models, employ AutoMapper for mapping, validate inputs with FluentValidation, and simplify API documentation with Swagger.

- For more details, refer to the original exercise code by Andre Vitor Lopes, which uses .NET Core 3.0, [here](https://github.com/alopes2/Medium-MyMusic). Note that this example uses .NET 7.0.

## Exercise 2: .NET Core Authentication and Authorization

In this exercise, we will secure a .NET Core 3+ API using Identity and JSON Web Tokens (JWT). The goal is to make the API more secure and manage user authentication and authorization effectively.

### Overview

- **Objective**: Secure a .NET Core API using Identity and JWT.
- **Tools**: .NET Core Identity, JSON Web Tokens.
- **Features**: Sign-up, Sign-in, Role Management, JWT Generation and Validation, Route Protection.

### Key Concepts

- **Microsoft Identity**: Learn how to integrate Microsoft Identity into a multi-layered project and structure the database and entities appropriately.
- **User Management**: Implement user sign-up, sign-in, and role management.
- **JSON Web Tokens (JWT)**: Understand JWT creation, validation, and usage for securing API endpoints.

- For more details, refer to the original exercise code by Andre Vitor Lopes, which uses .NET Core 3.0, [here](https://github.com/alopes2/Medium-MyMusic-Identity). Note that this example uses .NET 7.0.

For more details, refer to the original author Andre Vitor Lopes [here](https://blog.andrevitorlopes.com/).
