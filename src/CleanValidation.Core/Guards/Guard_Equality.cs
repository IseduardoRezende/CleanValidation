using System.Numerics;
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
            if (Continue && (value is not null || comparison is not null) && (!value?.Equals(comparison) ?? true))
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

        public Guard AgainstOutOfRange<T>(T? value, T min, T max, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparisonOperators<T, T, bool>
        {
            if (Continue && (value is null || value < min || value > max))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstOutOfRange(DateOnly? date, DateOnly min, DateOnly max, string? message = null, [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (Continue && (date is null || date.Value < min || date.Value > max))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstOutOfRange(TimeOnly? time, TimeOnly min, TimeOnly max, string? message = null, [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (Continue && (time is null || time.Value < min || time.Value > max))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstOutOfRange(DateTime? dateTime, DateTime min, DateTime max, string? message = null, [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (Continue && (dateTime is null || dateTime.Value < min || dateTime.Value > max))
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
            if (Continue && (value is not null || comparison is not null) && (!value?.Equals(comparison) ?? true))
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

        new public Guard<T> AgainstOutOfRange<TValue>(TValue? value, TValue min, TValue max, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where TValue : IComparisonOperators<TValue, TValue, bool>
        {
            if (Continue && (value is null || value < min || value > max))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstOutOfRange(DateOnly? date, DateOnly min, DateOnly max, string? message = null, [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (Continue && (date is null || date.Value < min || date.Value > max))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstOutOfRange(TimeOnly? time, TimeOnly min, TimeOnly max, string? message = null, [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (Continue && (time is null || time.Value < min || time.Value > max))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstOutOfRange(DateTime? dateTime, DateTime min, DateTime max, string? message = null, [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (Continue && (dateTime is null || dateTime.Value < min || dateTime.Value > max))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }
}
