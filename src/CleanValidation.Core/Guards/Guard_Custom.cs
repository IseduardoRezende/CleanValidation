using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstTrue(bool? condition, string? message = null, [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (Continue && (condition is null || !condition.Value))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstTrue<T>(T? value, Func<T, bool> func, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || !func.Invoke(value)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public async Task<Guard> AgainstTrueAsync<T>(T? value, Func<T, Task<bool>> func, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || !await func.Invoke(value)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstFalse(bool? condition, string? message = null, [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (Continue && (condition is null || condition.Value))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstFalse<T>(T? value, Func<T, bool> func, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || func.Invoke(value)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public async Task<Guard> AgainstFalseAsync<T>(T? value, Func<T, Task<bool>> func, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || await func.Invoke(value)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstTrue(bool? condition, string? message = null, [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (Continue && (condition is null || !condition.Value))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstTrue<TValue>(TValue? value, Func<TValue, bool> func, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || !func.Invoke(value)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public async Task<Guard<T>> AgainstTrueAsync<TValue>(TValue? value, Func<TValue, Task<bool>> func, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || !await func.Invoke(value)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstFalse(bool? condition, string? message = null, [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (Continue && (condition is null || condition.Value))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstFalse<TValue>(TValue? value, Func<TValue, bool> func, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || func.Invoke(value)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public async Task<Guard<T>> AgainstFalseAsync<TValue>(TValue? value, Func<TValue, Task<bool>> func, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || await func.Invoke(value)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }
}
