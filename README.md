# CleanValidation.Core 🐚

The `.NET` library for **fluent, expressive, and clean validation** using the best of multiple patterns: `Guard`, `Result<T>`, and extensible validators with localization support built-in.

---

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
