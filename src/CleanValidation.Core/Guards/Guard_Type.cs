using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstNotAssignableTo<TBase>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || !value.GetType().IsAssignableTo(typeof(TBase))))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstNotAssignableFrom<TBase>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || !value.GetType().IsAssignableFrom(typeof(TBase))))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstNotTypeOf<TExpected>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || !value.GetType().Equals(typeof(TExpected))))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstAssignableTo<TBase>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || value.GetType().IsAssignableTo(typeof(TBase))))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstAssignableFrom<TBase>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || value.GetType().IsAssignableFrom(typeof(TBase))))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstTypeOf<TExpected>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || value.GetType().Equals(typeof(TExpected))))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstInvalidEnum<TEnum>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where TEnum : Enum
        {
            if (Continue && (value is null || !Enum.IsDefined(typeof(TEnum), value)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstNotAssignableTo<TBase>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || !value.GetType().IsAssignableTo(typeof(TBase))))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstNotAssignableFrom<TBase>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || !value.GetType().IsAssignableFrom(typeof(TBase))))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstNotTypeOf<TExpected>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || !value.GetType().Equals(typeof(TExpected))))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstAssignableTo<TBase>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || value.GetType().IsAssignableTo(typeof(TBase))))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstAssignableFrom<TBase>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || value.GetType().IsAssignableFrom(typeof(TBase))))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstTypeOf<TExpected>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || value.GetType().Equals(typeof(TExpected))))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstInvalidEnum<TEnum>(
            object? value, 
            string? message = null, 
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where TEnum : Enum
        {
            if (Continue && (value is null || !Enum.IsDefined(typeof(TEnum), value)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }
}
