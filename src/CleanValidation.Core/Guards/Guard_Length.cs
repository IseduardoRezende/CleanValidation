using System.Linq.Expressions;
using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using CleanValidation.Core.Extensions;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstMinLength<T>(
            IEnumerable<T>? values,
            int minLength,
            string? message = null,
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (values.Count() < minLength)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstMinLength), paramName, [minLength],
                    CultureName), message));

            return this;
        }

        public Guard AgainstMaxLength<T>(
            IEnumerable<T>? values,
            int maxLength,
            string? message = null,
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (values.Count() > maxLength)
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstMaxLength), paramName, [maxLength],
                    CultureName), message));

            return this;
        }

        public Guard AgainstNotExactLength<T>(
            IEnumerable<T>? values,
            int exactLength,
            string? message = null,
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (!values.Count().Equals(exactLength))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNotExactLength), paramName, [exactLength],
                    CultureName), message));

            return this;
        }

        public Guard AgainstExactLength<T>(
            IEnumerable<T>? values,
            int exactLength,
            string? message = null,
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (values.Count().Equals(exactLength))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstExactLength), paramName, [exactLength],
                    CultureName), message));

            return this;
        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstMinLength<TValue>(
            IEnumerable<TValue>? values,
            int minLength,
            string? message = null,
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (values.Count() < minLength)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstMinLength), paramName, [minLength],
                    CultureName), message));

            return this;
        }

        public Guard<T> AgainstMinLength<TProperty>(
            Expression<Func<T, IEnumerable<TProperty?>?>> property,
            int minLength,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            IEnumerable<TProperty?>? values = property.GetValue(Result.Value);

            if (values is null)
                return this;

            if (values.Count() < minLength)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstMinLength), property.GetName(), [minLength],
                    CultureName), message));

            return this;
        }

        new public Guard<T> AgainstMaxLength<TValue>(
            IEnumerable<TValue>? values,
            int maxLength,
            string? message = null,
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (values.Count() > maxLength)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstMaxLength), paramName, [maxLength],
                    CultureName), message));

            return this;
        }

        public Guard<T> AgainstMaxLength<TProperty>(
            Expression<Func<T, IEnumerable<TProperty?>?>> property,
            int maxLength,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            IEnumerable<TProperty?>? values = property.GetValue(Result.Value);

            if (values is null)
                return this;

            if (values.Count() > maxLength)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstMaxLength), property.GetName(), [maxLength],
                    CultureName), message));

            return this;
        }

        new public Guard<T> AgainstNotExactLength<TValue>(
            IEnumerable<TValue>? values,
            int exactLength,
            string? message = null,
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (!values.Count().Equals(exactLength))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNotExactLength), paramName, [exactLength],
                    CultureName), message));

            return this;
        }

        public Guard<T> AgainstNotExactLength<TProperty>(
            Expression<Func<T, IEnumerable<TProperty?>?>> property,
            int exactLength,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            IEnumerable<TProperty?>? values = property.GetValue(Result.Value);

            if (values is null)
                return this;

            if (!values.Count().Equals(exactLength))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNotExactLength), property.GetName(), [exactLength],
                    CultureName), message));

            return this;
        }

        new public Guard<T> AgainstExactLength<TValue>(
            IEnumerable<TValue>? values,
            int exactLength,
            string? message = null,
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (!Continue || values is null)
                return this;

            if (values.Count().Equals(exactLength))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstExactLength), paramName, [exactLength],
                    CultureName), message));

            return this;
        }

        public Guard<T> AgainstExactLength<TProperty>(
            Expression<Func<T, IEnumerable<TProperty?>?>> property,
            int exactLength,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            IEnumerable<TProperty?>? values = property.GetValue(Result.Value);

            if (values is null)
                return this;

            if (values.Count().Equals(exactLength))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstExactLength), property.GetName(), [exactLength],
                    CultureName), message));

            return this;
        }
    }
}
