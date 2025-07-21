using System.Numerics;
using System.Linq.Expressions;
using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using CleanValidation.Core.Extensions;
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
        public Guard AgainstNull(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (value is null)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNull), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstEqual<T>(
            T? value,
            T? comparison,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if ((value is null && comparison is null) || (value?.Equals(comparison) ?? false))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstEqual), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstNotEqual<T>(
            T? value,
            T? comparison,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if ((value is not null || comparison is not null) && (!value?.Equals(comparison) ?? true))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNotEqual), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstDefault<TStruct>(
            TStruct value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where TStruct : struct
        {
            if (!Continue)
                return this;

            if (value.Equals(default(TStruct)))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDefault), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstEmpty<T>(
            IEnumerable<T>? values,
            string? message = null,
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (values is null || !values.Any())
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstEmpty), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstWhiteSpace(
            string? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (string.IsNullOrWhiteSpace(value))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstWhiteSpace), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstIn<T>(
            T? value,
            IEnumerable<T> values,
            IEqualityComparer<T?>? comparer = null,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (values.Contains(value, comparer))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstIn), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstNotIn<T>(
            T? value,
            IEnumerable<T> values,
            IEqualityComparer<T?>? comparer = null,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (!values.Contains(value, comparer))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNotIn), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstOutOfRange<T>(
            T? value,
            T? min,
            T? max,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where T : IComparisonOperators<T, T, bool>
        {
            if (!Continue || value is null || min is null || max is null)
                return this;

            if (value < min || value > max)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstOutOfRange(
            DateOnly? date,
            DateOnly? min,
            DateOnly? max,
            string? message = null,
            [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (!Continue || date is null || min is null || max is null)
                return this;

            if (date < min || date > max)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstOutOfRange(
            TimeOnly? time,
            TimeOnly? min,
            TimeOnly? max,
            string? message = null,
            [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (!Continue || time is null || min is null || max is null)
                return this;

            if (time < min || time > max)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstOutOfRange(
            DateTime? dateTime,
            DateTime? min,
            DateTime? max,
            string? message = null,
            [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (!Continue || dateTime is null || min is null || max is null)
                return this;

            if (dateTime < min || dateTime > max)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstRange<T>(
            T? value,
            T? min,
            T? max,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where T : IComparisonOperators<T, T, bool>
        {
            if (!Continue || value is null || min is null || max is null)
                return this;

            if (value >= min && value <= max)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstRange(
            DateOnly? date,
            DateOnly? min,
            DateOnly? max,
            string? message = null,
            [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (!Continue || date is null || min is null || max is null)
                return this;

            if (date >= min && date <= max)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstRange(
            TimeOnly? time,
            TimeOnly? min,
            TimeOnly? max,
            string? message = null,
            [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (!Continue || time is null || min is null || max is null)
                return this;

            if (time >= min && time <= max)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstRange(
            DateTime? dateTime,
            DateTime? min,
            DateTime? max,
            string? message = null,
            [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (!Continue || dateTime is null || min is null || max is null)
                return this;

            if (dateTime >= min && dateTime <= max)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), paramName, cultureName: CultureName), message));

            return this;
        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstNull(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (value is null)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNull), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstNull<TProperty>(
            Expression<Func<T, TProperty?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            if (property.GetValue(Result.Value) is null)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNull), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstEqual<TValue>(
            TValue? value,
            TValue? comparison,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if ((value is null && comparison is null) || (value?.Equals(comparison) ?? false))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstEqual), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstEqual<TProperty>(
            Expression<Func<T, TProperty?>> property,
            TProperty? comparison,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            TProperty? value = property.GetValue(Result.Value);

            if ((value is null && comparison is null) || (value?.Equals(comparison) ?? false))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstEqual), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstNotEqual<TValue>(
            TValue? value,
            TValue? comparison,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if ((value is not null || comparison is not null) && (!value?.Equals(comparison) ?? true))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNotEqual), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstNotEqual<TProperty>(
            Expression<Func<T, TProperty?>> property,
            TProperty? comparison,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            TProperty? value = property.GetValue(Result.Value);

            if ((value is not null || comparison is not null) && (!value?.Equals(comparison) ?? true))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNotEqual), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstDefault<TStruct>(
            TStruct value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where TStruct : struct
        {
            if (!Continue)
                return this;

            if (value.Equals(default(TStruct)))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDefault), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstDefault<TProperty>(
            Expression<Func<T, TProperty?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            TProperty? value = property.GetValue(Result.Value);

            if (value?.Equals(default(TProperty)) ?? true)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDefault), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstEmpty<TValue>(
            IEnumerable<TValue>? values,
            string? message = null,
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (values is null || !values.Any())
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstEmpty), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstEmpty<TProperty>(
            Expression<Func<T, IEnumerable<TProperty?>?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            IEnumerable<TProperty?>? values = property.GetValue(Result.Value);

            if (values is null || !values.Any())
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstEmpty), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstWhiteSpace(
            string? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (string.IsNullOrWhiteSpace(value))
                Result = InvalidResult<T>.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstWhiteSpace), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstWhiteSpace(
            Expression<Func<T, string?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            string? value = property.GetValue(Result.Value);

            if (string.IsNullOrWhiteSpace(value))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstWhiteSpace), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstIn<TValue>(
            TValue? value,
            IEnumerable<TValue> values,
            IEqualityComparer<TValue?>? comparer = null,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (values.Contains(value, comparer))
                Result = InvalidResult<T>.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstIn), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstIn<TProperty>(
            Expression<Func<T, TProperty?>> property,
            IEnumerable<TProperty?>? values,
            EqualityComparer<TProperty?>? comparer = null,
            string? message = null)
        {
            if (!Continue || property is null || values is null)
                return this;

            if (values.Contains(property.GetValue(Result.Value), comparer))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstIn), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstNotIn<TValue>(
            TValue? value,
            IEnumerable<TValue> values,
            IEqualityComparer<TValue?>? comparer = null,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (!values.Contains(value, comparer))
                Result = InvalidResult<T>.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNotIn), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstNotIn<TProperty>(
            Expression<Func<T, TProperty?>> property,
            IEnumerable<TProperty?>? values,
            EqualityComparer<TProperty?>? comparer = null,
            string? message = null)
        {
            if (!Continue || property is null || values is null)
                return this;

            if (!values.Contains(property.GetValue(Result.Value), comparer))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNotIn), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstOutOfRange<TValue>(
            TValue? value,
            TValue? min,
            TValue? max,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where TValue : IComparisonOperators<TValue, TValue, bool>
        {
            if (!Continue || value is null || min is null || max is null)
                return this;

            if (value < min || value > max)
                Result = InvalidResult<T>.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstOutOfRange<TProperty>(
            Expression<Func<T, TProperty?>> property,
            TProperty? min,
            TProperty? max,
            string? message = null)
                where TProperty : IComparisonOperators<TProperty, TProperty, bool>
        {
            if (!Continue || property is null || min is null || max is null)
                return this;

            TProperty? value = property.GetValue(Result.Value);

            if (value is null)
                return this;

            if (value < min || value > max)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstOutOfRange(
            DateOnly? date,
            DateOnly? min,
            DateOnly? max,
            string? message = null,
            [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (!Continue || date is null || min is null || max is null)
                return this;

            if (date < min || date > max)
                Result = InvalidResult<T>.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstOutOfRange(
            Expression<Func<T, DateOnly?>> property,
            DateOnly? min,
            DateOnly? max,
            string? message = null)
        {
            if (!Continue || property is null || min is null || max is null)
                return this;

            DateOnly? date = property.GetValue(Result.Value);

            if (date is null)
                return this;

            if (date < min || date > max)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstOutOfRange(
            TimeOnly? time,
            TimeOnly? min,
            TimeOnly? max,
            string? message = null,
            [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (!Continue || time is null || min is null || max is null)
                return this;

            if (time < min || time > max)
                Result = InvalidResult<T>.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstOutOfRange(
            Expression<Func<T, TimeOnly?>> property,
            TimeOnly? min,
            TimeOnly? max,
            string? message = null)
        {
            if (!Continue || property is null || min is null || max is null)
                return this;

            TimeOnly? time = property.GetValue(Result.Value);

            if (time is null)
                return this;

            if (time < min || time > max)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstOutOfRange(
            DateTime? dateTime,
            DateTime? min,
            DateTime? max,
            string? message = null,
            [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (!Continue || dateTime is null || min is null || max is null)
                return this;

            if (dateTime < min || dateTime > max)
                Result = InvalidResult<T>.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstOutOfRange(
            Expression<Func<T, DateTime?>> property,
            DateTime? min,
            DateTime? max,
            string? message = null)
        {
            if (!Continue || property is null || min is null || max is null)
                return this;

            DateTime? dateTime = property.GetValue(Result.Value);

            if (dateTime is null)
                return this;

            if (dateTime < min || dateTime > max)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstOutOfRange), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstRange<TValue>(
            TValue? value,
            TValue? min,
            TValue? max,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where TValue : IComparisonOperators<TValue, TValue, bool>
        {
            if (!Continue || value is null || min is null || max is null)
                return this;

            if (value >= min && value <= max)
                Result = InvalidResult<T>.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstRange<TProperty>(
            Expression<Func<T, TProperty?>> property,
            TProperty? min,
            TProperty? max,
            string? message = null)
                where TProperty : IComparisonOperators<TProperty, TProperty, bool>
        {
            if (!Continue || property is null || min is null || max is null)
                return this;

            TProperty? value = property.GetValue(Result.Value);

            if (value is null)
                return this;

            if (value >= min && value <= max)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstRange(
            DateOnly? date,
            DateOnly? min,
            DateOnly? max,
            string? message = null,
            [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (!Continue || date is null || min is null || max is null)
                return this;

            if (date >= min && date <= max)
                Result = InvalidResult<T>.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstRange(
            Expression<Func<T, DateOnly?>> property,
            DateOnly? min,
            DateOnly? max,
            string? message = null)
        {
            if (!Continue || property is null || min is null || max is null)
                return this;

            DateOnly? date = property.GetValue(Result.Value);

            if (date is null)
                return this;

            if (date >= min && date <= max)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstRange(
            TimeOnly? time,
            TimeOnly? min,
            TimeOnly? max,
            string? message = null,
            [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (!Continue || time is null || min is null || max is null)
                return this;

            if (time >= min && time <= max)
                Result = InvalidResult<T>.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstRange(
            Expression<Func<T, TimeOnly?>> property,
            TimeOnly? min,
            TimeOnly? max,
            string? message = null)
        {
            if (!Continue || property is null || min is null || max is null)
                return this;

            TimeOnly? time = property.GetValue(Result.Value);

            if (time is null)
                return this;

            if (time >= min && time <= max)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstRange(
            DateTime? dateTime,
            DateTime? min,
            DateTime? max,
            string? message = null,
            [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (!Continue || dateTime is null || min is null || max is null)
                return this;

            if (dateTime >= min && dateTime <= max)
                Result = InvalidResult<T>.Create(
                     ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstRange(
            Expression<Func<T, DateTime?>> property,
            DateTime? min,
            DateTime? max,
            string? message = null)
        {
            if (!Continue || property is null || min is null || max is null)
                return this;

            DateTime? dateTime = property.GetValue(Result.Value);

            if (dateTime is null)
                return this;

            if (dateTime >= min && dateTime <= max)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstRange), property.GetName(), cultureName: CultureName), message));

            return this;
        }
    }
}
