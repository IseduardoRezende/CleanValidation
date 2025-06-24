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
