using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
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
            if (Continue && (values is null || values.Count() < minLength))
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
            if (Continue && (values is null || values.Count() > maxLength))
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
            if (Continue && (values is null || !values.Count().Equals(exactLength)))
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
            if (Continue && (values is null || values.Count().Equals(exactLength)))
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
            if (Continue && (values is null || values.Count() < minLength))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstMinLength), paramName, [minLength],
                    CultureName), message));

            return this;
        }

        new public Guard<T> AgainstMaxLength<TValue>(
            IEnumerable<TValue>? values, 
            int maxLength, 
            string? message = null, 
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (Continue && (values is null || values.Count() > maxLength))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstMaxLength), paramName, [maxLength],
                    CultureName), message));

            return this;
        }

        new public Guard<T> AgainstNotExactLength<TValue>(
            IEnumerable<TValue>? values, 
            int exactLength, 
            string? message = null, 
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (Continue && (values is null || !values.Count().Equals(exactLength)))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstNotExactLength), paramName, [exactLength],
                    CultureName), message));

            return this;
        }

        new public Guard<T> AgainstExactLength<TValue>(
            IEnumerable<TValue>? values, 
            int exactLength, 
            string? message = null, 
            [CallerArgumentExpression(nameof(values))] string? paramName = null)
        {
            if (Continue && (values is null || values.Count().Equals(exactLength)))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstExactLength), paramName, [exactLength],
                    CultureName), message));

            return this;
        }
    }
}
