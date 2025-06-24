# CleanValidation.Core 🐚

The `.NET` library for **fluent, expressive, and clean validation** using the best of multiple patterns: `Guard`, `Result<T>`, and extensible validators with localization support built-in.

---

## 🚀 Getting Started

### 1. Add the NuGet package:

https://www.nuget.org/packages/CleanValidation.Core

```bash
Install-Package CleanValidation.Core
```

## ✨ Key Features

* ✅ Fluent validation syntax using `Guard`
* ✅ Built-in `Result<T>` system: `SuccessResult`, `ErrorResult`, `InvalidResult`, `ConflictResult`, etc.
* ✅ Separate `Guard` and `GuardThrow` for result-based or exception-based flows
* ✅ Extensible `IValidator<T>` interface for custom validations
* ✅ Localization support via `cultureName`
* ✅ Fully composable, testable, and DI-ready

---

## ⚡ Quick Example

```csharp
public record User(long Id, string Name, byte Age, long UserTypeId, string Description);

public class UserValidator(IUserTypeRepository userTypeRepository) : Validator<User>
{
    private readonly IUserTypeRepository _userTypeRepository = userTypeRepository;

    public override async Task<IResult> ValidateAsync(
        User value,
        string cultureName = "en-US",
        CancellationToken cancellationToken = default)
    {
        var result = await base.ValidateAsync(value, cultureName, cancellationToken);

        if (!result.Success)
            return result;

        var exists = await _userTypeRepository.ExistsAsync(value.UserTypeId, cancellationToken);

        if (!exists)
            return NotFoundResult.Create(new Error(message: "Invalid user type id", field: nameof(user.UserTypeId)));

        return Guard.Create()
            .AgainstNullOrWhiteSpace(value.Name)
            .AgainstNullOrWhiteSpace(value.Description)
            .GetResult();
    }
}
```

---

## 🔨 Core Concepts

### Guard

Fluent and chainable validation that returns a `Result<T>`:

```csharp
Guard.Create()
    .AgainstNull(dto)
    .AgainstNullOrWhiteSpace(dto.Name)
    .GetResult();
```

### GuardThrow

Same as `Guard`, but throws exceptions instead:

```csharp
GuardThrow.Create()
    .AgainstNull(entity)
    .AgainstNullOrWhiteSpace(entity.Name);
```

### Result Types

All results implement `IResult` or `IResult<T>`:

* `SuccessResult<T>`
* `ErrorResult<T>`
* `InvalidResult<T>`
* `ConflictResult<T>`
* `NotFoundResult<T>`
* `ProblemResult<T>`

Each provides fluent creation with error details and optional field association.

---

## 🔍 Localization Support

All methods that return or create results accept a `cultureName` parameter, used internally with `.resx` resources to localize messages dynamically.

```csharp
Guard.Create("pt-BR")
    .AgainstNullOrWhiteSpace(dto.Descricao)
    .GetResult();
```

---

## ⚙ Structure Overview

* **Error** – Base error model with `Message` and `Field`
* **ErrorUtils** – Factory methods for consistent error creation
* **CleanValidationException** – Base exception with helper `ThrowIfNull`, `ThrowIfNullOrWhiteSpace`, etc.
* **Guard** – Fluent builder that returns results
* **GuardThrow** – Fluent builder that throws exceptions
* **IResult / IResult<T>** – Interfaces for all result types
* **Validator<T> / IValidator<T>** – Abstract class + interface for async or sync custom validation logic
* **ResultExtensions** – Helpful extensions like `ErrorsTo<T>()`

---

## 🌐 Goals & Philosophy

* Minimalism + Expressiveness
* Strong typing, fail-fast, and readability
* Plug-and-play usability
* Clear separation between structural validation and business rules
* Encouragement of clean architecture without forcing opinionated structures

---

## ✅ Next Steps

* Check out `CleanValidation.Extensions.Http` for ASP.NET Core integration
* Use `CleanValidation.DependencyInjection` to register all `IValidator<T>` via Scrutor

---

## 🪤 Inspiration

This library combines the clarity of `Guard` clauses, the safety of `Result<T>`, and the convenience of fluent interfaces — all wrapped with localization and extensibility in mind.

> **CleanValidation**: *The .NET library for Clean Validations with clarity, consistency, and control.* 🐚

---

# CleanValidation.Extensions.Http 🌐

**ASP.NET integration for CleanValidation.**

This package provides seamless mapping from `IResult` / `IResult<T>` (from `CleanValidation.Core`) into ASP.NET Core `IActionResult` types, enabling fluent and expressive return statements in your controller or endpoint layer.

---

## ✨ Features

* ✅ Maps `SuccessResult<T>` to `OkObjectResult`
* ✅ Maps `ErrorResult<T>` to `BadRequestObjectResult`
* ✅ Maps `InvalidResult<T>` to `UnprocessableEntityObjectResult`
* ✅ Supports `ConflictResult<T>`, `NotFoundResult<T>`, `ProblemResult<T>`
* ✅ Simple `.ToActionResult()` extension method for all `IResult`
* ✅ Consistent HTTP responses for clean architecture applications

---

## 🚀 Getting Started

### 1. Add the NuGet package:

https://www.nuget.org/packages/CleanValidation.Extensions.Http

```bash
Install-Package CleanValidation.Extensions.Http
```

### 2. Use in Controller or Minimal API:

```csharp
using CleanValidation.Extensions.Http;

User user = new("Lívia", 21, "Lady");
IResult<User> result = SuccessResult<User>.Create(user);

IActionResult actionResult = result.ToActionResult();
```

### 3. Example Mapping:

```csharp
return result.ToActionResult();
```

This will automatically return:

* `Ok(user)` if result is a `SuccessResult<T>`
* `BadRequest(...)` if result is an `ErrorResult<T>`
* `UnprocessableEntity(...)` if result is an `InvalidResult<T>`
* `Conflict(...)` if result is a `ConflictResult<T>`
* `NotFound(...)` if result is a `NotFoundResult<T>`
* `Problem(...)` if result is a `ProblemResult<T>`

---

## 🎡 Why Use It?

* Makes controllers and endpoints **cleaner and less error-prone**
* Eliminates repetitive response handling logic
* Promotes **consistency** across all HTTP layers
* Fits perfectly into **CQRS**, **Minimal APIs**, and **RESTful** patterns

---

## 🎓 Example Test

```csharp
User user = new("Lívia", 21, "Lady");
IResult<User> result = SuccessResult<User>.Create(user);

IActionResult actionResult = result.ToActionResult();

Assert.NotNull(actionResult);
Assert.IsType<OkObjectResult>(actionResult);
```

> *Use CleanValidation.Extensions.Http to make your ASP.NET Core apps fluent, expressive, and consistent from validation to response.*

---

# CleanValidation.DependencyInjection ⚙️

**Plug-and-play integration for CleanValidation with ASP.NET Dependency Injection**, using `Scrutor` under the hood to automatically register validators.

---

## ✨ Features

* ✅ Auto-registers all `IValidator<T>` implementations as `Scoped`
* ✅ Easy-to-use extension method: `AddCleanValidation(...)`
* ✅ Supports multiple assemblies or a single reference
* ✅ No configuration required — just plug and go

---

## 🚀 Getting Started

### 1. Install the package:

https://www.nuget.org/packages/CleanValidation.DependencyInjection

```bash
Install-Package CleanValidation.DependencyInjection
```

### 2. Register your validators in `Startup.cs` or `Program.cs`:

```csharp
using CleanValidation.DependencyInjection;

var services = new ServiceCollection();
services.AddCleanValidation(typeof(UserValidator).Assembly);
```

Or for multiple assemblies:

```csharp
services.AddCleanValidation(
    typeof(UserValidator).Assembly,
    typeof(OtherValidator).Assembly
);
```

---

## 🪤 How It Works

This extension method uses `Scrutor` to scan the specified assemblies and register all types that implement:

```csharp
IValidator<T>
```
---

## 🔍 Example

```csharp
public class UserValidator : Validator<User>
{
    public override Task<IResult> ValidateAsync(User value, string cultureName = "en-US", CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Guard.Create(cultureName)
            .AgainstNullOrWhiteSpace(value.Name)
            .AgainstNullOrWhiteSpace(value.Description)
            .GetResult());
    }
}
```

Then simply inject it:

```csharp
public class UserHandler
{
    private readonly IValidator<User> _validator;

    public UserHandler(IValidator<User> validator)
    {
        _validator = validator;
    }

    public async Task<IResult> HandleAsync(User user)
    {
        return await _validator.ValidateAsync(user);
    }
}
```

---

> *CleanValidation.DependencyInjection makes your validators discoverable, injectable, and production-ready — instantly.*

---

## 🛁 CleanValidation Ecosystem

| Package                               | Description                                |
| ------------------------------------- | ------------------------------------------ |
| `CleanValidation.Core`                | Fluent validation with Guard + Result<T>   |
| `CleanValidation.Extensions.Http`     | HTTP mapping of results to `IActionResult` |
| `CleanValidation.DependencyInjection` | Registers `IValidator<T>` via Scrutor      |

---
