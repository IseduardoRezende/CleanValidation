using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        /// <summary>
        /// Ensures that the specified value is not null.
        /// </summary>
        /// <remarks>
        /// If the <see cref="Continue"/> property is <see langword="true"/> and the
        /// provided value is null, the <see cref="Result"/> property is updated with an error result
        /// indicating an invalid parameter.
        /// </remarks>
        /// <param name="value">The value to validate.</param>
        /// <param name="message">Optional descriptive message error.</param>
        /// <param name="paramName">The name of <paramref name="value"/> captured by expression or manually.</param>
        /// <returns>The current <see cref="Guard"/> instance, allowing for method chaining.</returns>
        public Guard AgainstNull(object? value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && value is null)
                Result = ErrorResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstEqual<T>(T? value, T? comparison, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && ((value is null && comparison is null) || (value?.Equals(comparison) ?? false)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstNotEqual<T>(T? value, T? comparison, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && value is not null && comparison is not null && !value.Equals(comparison))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstDefault<TStruct>(TStruct value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where TStruct : struct
        {
            if (Continue && value.Equals(default(TStruct)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstEmpty(string? value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && string.IsNullOrEmpty(value))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstEmpty<T>(IEnumerable<T>? values, string? message = null, [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (Continue && (values is null || !values.Any()))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstWhiteSpace(string? value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && string.IsNullOrWhiteSpace(value))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstIn<T>(T? value, IEnumerable<T> values, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (values is null || values.Contains(value)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstNotIn<T>(T? value, IEnumerable<T> values, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (values is null || !values.Contains(value)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstNull(object? value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && value is null)
                Result = ErrorResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstEqual<TValue>(TValue? value, TValue? comparison, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && ((value is null && comparison is null) || (value?.Equals(comparison) ?? false)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstNotEqual<TValue>(TValue? value, TValue? comparison, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && value is not null && comparison is not null && !value.Equals(comparison))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstDefault<TStruct>(TStruct value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where TStruct : struct
        {
            if (Continue && value.Equals(default(TStruct)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstEmpty(string? value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && string.IsNullOrEmpty(value))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstEmpty<TValue>(IEnumerable<TValue>? values, string? message = null, [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (Continue && (values is null || !values.Any()))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstWhiteSpace(string? value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && string.IsNullOrWhiteSpace(value))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstIn<TValue>(TValue? value, IEnumerable<TValue> values, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (values is null || values.Contains(value)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstNotIn<TValue>(TValue? value, IEnumerable<TValue> values, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (values is null || !values.Contains(value)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }
}
