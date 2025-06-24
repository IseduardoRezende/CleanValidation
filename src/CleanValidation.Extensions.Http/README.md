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

## 🛁 CleanValidation Ecosystem

| Package                               | Description                                |
| ------------------------------------- | ------------------------------------------ |
| `CleanValidation.Core`                | Fluent validation with Guard + Result<T>   |
| `CleanValidation.Extensions.Http`     | HTTP mapping of results to `IActionResult` |
| `CleanValidation.DependencyInjection` | Registers `IValidator<T>` via Scrutor      |

---
