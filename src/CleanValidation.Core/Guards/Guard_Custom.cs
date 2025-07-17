using System.Linq.Expressions;
using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;
using CleanValidation.Core.Extensions;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstTrue(
            bool? condition,
            string? message = null,
            [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (!Continue || condition is null)
                return this;

            if (condition is true)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTrue), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstTrue<T>(
            T? value,
            Func<T, bool> func,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null || func is null)
                return this;

            if (func.Invoke(value))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTrue), paramName, cultureName: CultureName), message));

            return this;
        }

        public async Task<Guard> AgainstTrueAsync<T>(
            T? value,
            Func<T, Task<bool>> func,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null || func is null)
                return this;

            if (await func.Invoke(value))
                Result = InvalidResult.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTrue), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstFalse(
            bool? condition,
            string? message = null,
            [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (!Continue || condition is null)
                return this;

            if (condition is false)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstFalse), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstFalse<T>(
            T? value,
            Func<T, bool> func,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null || func is null)
                return this;

            if (!func.Invoke(value))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstFalse), paramName, cultureName: CultureName), message));

            return this;
        }

        public async Task<Guard> AgainstFalseAsync<T>(
            T? value,
            Func<T, Task<bool>> func,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null || func is null)
                return this;

            if (!await func.Invoke(value))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstFalse), paramName, cultureName: CultureName), message));

            return this;
        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstTrue(
            bool? condition,
            string? message = null,
            [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (!Continue || condition is null)
                return this;

            if (condition is true)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTrue), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstTrue<TProperty>(
            Expression<Func<T, TProperty?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            if (property.GetValue(Result.Value) is true)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTrue), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstTrue<TProperty>(
            Expression<Func<T, TProperty?>> property,
            bool? condition,
            string? message = null)                
        {
            if (!Continue || property is null || condition is null)
                return this;

            if (condition is true)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTrue), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstTrue<TValue>(
            TValue? value,
            Func<TValue, bool> func,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null || func is null)
                return this;

            if (func.Invoke(value))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTrue), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstTrue<TProperty>(
            Expression<Func<T, TProperty?>> property,
            Func<TProperty?, bool> func,
            string? message = null)
        {
            if (!Continue || property is null || func is null)
                return this;

            if (func.Invoke(property.GetValue(Result.Value)))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTrue), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public async Task<Guard<T>> AgainstTrueAsync<TValue>(
            TValue? value,
            Func<TValue, Task<bool>> func,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null || func is null)
                return this;

            if (await func.Invoke(value))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTrue), paramName, cultureName: CultureName), message));

            return this;
        }

        public async Task<Guard<T>> AgainstTrueAsync<TProperty>(
            Expression<Func<T, TProperty?>> property,
            Func<TProperty?, Task<bool>> func,
            string? message = null)
        {
            if (!Continue || property is null || func is null)
                return this;

            if (await func.Invoke(property.GetValue(Result.Value)))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTrue), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstFalse(
            bool? condition,
            string? message = null,
            [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (!Continue || condition is null)
                return this;

            if (condition is false)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstFalse), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstFalse<TProperty>(
            Expression<Func<T, TProperty?>> property,
            string? message = null)                
        {
            if (!Continue || property is null)
                return this;

            if (property.GetValue(Result.Value) is false)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstFalse), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstFalse<TProperty>(
            Expression<Func<T, TProperty?>> property,
            bool? condition,
            string? message = null)
        {
            if (!Continue || property is null || condition is null)
                return this;

            if (condition is false)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstFalse), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstFalse<TValue>(
            TValue? value,
            Func<TValue, bool> func,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null || func is null)
                return this;

            if (!func.Invoke(value))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstFalse), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstFalse<TProperty>(
           Expression<Func<T, TProperty?>> property,
           Func<TProperty?, bool> func,
           string? message = null)
        {
            if (!Continue || property is null || func is null)
                return this;

            if (!func.Invoke(property.GetValue(Result.Value)))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstFalse), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public async Task<Guard<T>> AgainstFalseAsync<TValue>(
            TValue? value,
            Func<TValue, Task<bool>> func,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null || func is null)
                return this;

            if (!await func.Invoke(value))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstFalse), paramName, cultureName: CultureName), message));

            return this;
        }

        public async Task<Guard<T>> AgainstFalseAsync<TProperty>(
            Expression<Func<T, TProperty?>> property,
            Func<TProperty?, Task<bool>> func,
            string? message = null)
        {
            if (!Continue || property is null || func is null)
                return this;

            if (!await func.Invoke(property.GetValue(Result.Value)))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstFalse), property.GetName(), cultureName: CultureName), message));

            return this;
        }
    }
}
