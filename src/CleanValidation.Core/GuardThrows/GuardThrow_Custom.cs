using System.Linq.Expressions;
using CleanValidation.Core.Resources;
using CleanValidation.Core.Exceptions;
using CleanValidation.Core.Extensions;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.GuardThrows
{
    public partial class GuardThrow
    {
        public GuardThrow AgainstTrue(
            bool? condition,
            string? message = null,
            [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (condition is null)
                return this;

            if (condition is true)
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        public GuardThrow AgainstTrue<T>(
            T? value,
            Func<T, bool> func,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value is null || func is null)
                return this;

            if (func.Invoke(value))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        public async Task<GuardThrow> AgainstTrueAsync<T>(
            T? value,
            Func<T, CancellationToken, Task<bool>> func,
            CancellationToken cancellationToken = default,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value is null || func is null)
                return this;

            if (await func.Invoke(value, cancellationToken).ConfigureAwait(false))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        public GuardThrow AgainstFalse(
            bool? condition,
            string? message = null,
            [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (condition is null)
                return this;

            if (condition is false)
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }

        public GuardThrow AgainstFalse<T>(
           T? value,
           Func<T, bool> func,
           string? message = null,
           [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value is null || func is null)
                return this;

            if (!func.Invoke(value))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }

        public async Task<GuardThrow> AgainstFalseAsync<T>(
            T? value,
            Func<T, CancellationToken, Task<bool>> func,
            CancellationToken cancellationToken = default,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value is null || func is null)
                return this;

            if (!await func.Invoke(value, cancellationToken).ConfigureAwait(false))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }
    }

    public partial class GuardThrow<T>
    {
        new public GuardThrow<T> AgainstTrue(
            bool? condition,
            string? message = null,
            [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (condition is null)
                return this;

            if (condition is true)
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        public GuardThrow<T> AgainstTrue(
           Expression<Func<T, bool?>> property,
           string? message = null)
        {
            if (property is null)
                return this;

            if (property.GetValue(Value) is true)
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        public GuardThrow<T> AgainstTrue<TProperty>(
            Expression<Func<T, TProperty?>> property,
            bool? condition,
            string? message = null)
        {
            if (property is null || condition is null)
                return this;

            if (condition is true)
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        new public GuardThrow<T> AgainstTrue<TValue>(
            TValue? value,
            Func<TValue, bool> func,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value is null || func is null)
                return this;

            if (func.Invoke(value))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        public GuardThrow<T> AgainstTrue<TProperty>(
           Expression<Func<T, TProperty?>> property,
           Func<TProperty?, bool> func,
           string? message = null)
        {
            if (property is null || func is null)
                return this;

            if (func.Invoke(property.GetValue(Value)))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        public GuardThrow<T> AgainstTrue(
           Func<T?, bool> func,
           string? message = null)
        {
            if (func is null)
                return this;

            if (func.Invoke(Value))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        new public async Task<GuardThrow<T>> AgainstTrueAsync<TValue>(
            TValue? value,
            Func<TValue, CancellationToken, Task<bool>> func,
            CancellationToken cancellationToken = default,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value is null || func is null)
                return this;

            if (await func.Invoke(value, cancellationToken).ConfigureAwait(false))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        public async Task<GuardThrow<T>> AgainstTrueAsync<TProperty>(
            Expression<Func<T, TProperty?>> property,
            Func<TProperty?, CancellationToken, Task<bool>> func,
            CancellationToken cancellationToken = default,
            string? message = null)
        {
            if (property is null || func is null)
                return this;

            if (await func.Invoke(property.GetValue(Value), cancellationToken).ConfigureAwait(false))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        public async Task<GuardThrow<T>> AgainstTrueAsync(
            Func<T?, CancellationToken, Task<bool>> func,
            CancellationToken cancellationToken = default,
            string? message = null)
        {
            if (func is null)
                return this;

            if (await func.Invoke(Value, cancellationToken).ConfigureAwait(false))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstTrue), CultureName));

            return this;
        }

        new public GuardThrow<T> AgainstFalse(
            bool? condition,
            string? message = null,
            [CallerArgumentExpression(nameof(condition))] string? paramName = null)
        {
            if (condition is null)
                return this;

            if (condition is false)
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }

        public GuardThrow<T> AgainstFalse(
           Expression<Func<T, bool?>> property,
           string? message = null)
        {
            if (property is null)
                return this;

            if (property.GetValue(Value) is false)
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }

        public GuardThrow<T> AgainstFalse<TProperty>(
            Expression<Func<T, TProperty?>> property,
            bool? condition,
            string? message = null)
        {
            if (property is null || condition is null)
                return this;

            if (condition is false)
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }

        new public GuardThrow<T> AgainstFalse<TValue>(
            TValue? value,
            Func<TValue, bool> func,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value is null || func is null)
                return this;

            if (!func.Invoke(value))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }

        public GuardThrow<T> AgainstFalse<TProperty>(
           Expression<Func<T, TProperty?>> property,
           Func<TProperty?, bool> func,
           string? message = null)
        {
            if (property is null || func is null)
                return this;

            if (!func.Invoke(property.GetValue(Value)))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }

        public GuardThrow<T> AgainstFalse(
            Func<T?, bool> func,
            string? message = null)
        {
            if (func is null)
                return this;

            if (!func.Invoke(Value))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }

        new public async Task<GuardThrow<T>> AgainstFalseAsync<TValue>(
            TValue? value,
            Func<TValue, CancellationToken, Task<bool>> func,
            CancellationToken cancellationToken = default,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value is null || func is null)
                return this;

            if (!await func.Invoke(value, cancellationToken).ConfigureAwait(false))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }

        public async Task<GuardThrow<T>> AgainstFalseAsync<TProperty>(
            Expression<Func<T, TProperty?>> property,
            Func<TProperty?, CancellationToken, Task<bool>> func,
            CancellationToken cancellationToken = default,
            string? message = null)
        {
            if (property is null || func is null)
                return this;

            if (!await func.Invoke(property.GetValue(Value), cancellationToken).ConfigureAwait(false))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }

        public async Task<GuardThrow<T>> AgainstFalseAsync(
            Func<T?, CancellationToken, Task<bool>> func,
            CancellationToken cancellationToken = default,
            string? message = null)
        {
            if (func is null)
                return this;

            if (!await func.Invoke(Value, cancellationToken).ConfigureAwait(false))
                throw new CleanValidationException(message ?? CleanResourceManager.Create()
                    .GetString(nameof(AgainstFalse), CultureName));

            return this;
        }
    }
}
