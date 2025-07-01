using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstMinLength(string? value, int minLength, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (string.IsNullOrEmpty(value) || value.Length < minLength))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstMaxLength(string? value, int maxLength, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (string.IsNullOrEmpty(value) || value.Length > maxLength))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstLength(string? value, int exactLength, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (string.IsNullOrEmpty(value) || !value.Length.Equals(exactLength)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstMinLength<T>(IEnumerable<T>? values, int minLength, string? message = null, [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (Continue && (values is null || values.Count() < minLength))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstMaxLength<T>(IEnumerable<T>? values, int maxLength, string? message = null, [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (Continue && (values is null || values.Count() > maxLength))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstLength<T>(IEnumerable<T>? values, int exactLength, string? message = null, [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (Continue && (values is null || !values.Count().Equals(exactLength)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstMinLength(string? value, int minLength, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (string.IsNullOrEmpty(value) || value.Length < minLength))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstMaxLength(string? value, int maxLength, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (string.IsNullOrEmpty(value) || value.Length > maxLength))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstLength(string? value, int exactLength, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (string.IsNullOrEmpty(value) || !value.Length.Equals(exactLength)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstMinLength<TValue>(IEnumerable<TValue>? values, int minLength, string? message = null, [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (Continue && (values is null || values.Count() < minLength))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstMaxLength<TValue>(IEnumerable<TValue>? values, int maxLength, string? message = null, [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (Continue && (values is null || values.Count() > maxLength))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstLength<TValue>(IEnumerable<TValue>? values, int exactLength, string? message = null, [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (Continue && (values is null || !values.Count().Equals(exactLength)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }
}
