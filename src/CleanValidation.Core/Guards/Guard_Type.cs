using System.Linq.Expressions;
using CleanValidation.Core.Errors;
using CleanValidation.Core.Extensions;
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
            if (!Continue || value is null)
                return this;

            if (!value.GetType().IsAssignableTo(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstNotAssignableTo), paramName, [typeof(TBase).Name], CultureName), message));

            return this;
        }

        public Guard AgainstNotAssignableFrom<TBase>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null)
                return this;

            if (!value.GetType().IsAssignableFrom(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstNotAssignableFrom), paramName, [typeof(TBase).Name], CultureName), message));

            return this;
        }

        public Guard AgainstNotTypeOf<TExpected>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null)
                return this;

            if (!value.GetType().Equals(typeof(TExpected)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstNotTypeOf), paramName, [typeof(TExpected).Name], CultureName), message));

            return this;
        }

        public Guard AgainstAssignableTo<TBase>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null)
                return this;

            if (value.GetType().IsAssignableTo(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstAssignableTo), paramName, [typeof(TBase).Name], CultureName), message));

            return this;
        }

        public Guard AgainstAssignableFrom<TBase>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null)
                return this;

            if (value.GetType().IsAssignableFrom(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstAssignableFrom), paramName, [typeof(TBase).Name], CultureName), message));

            return this;
        }

        public Guard AgainstTypeOf<TExpected>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null)
                return this;

            if (value.GetType().Equals(typeof(TExpected)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstTypeOf), paramName, [typeof(TExpected).Name], CultureName), message));

            return this;
        }

        public Guard AgainstInvalidEnum<TEnum>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where TEnum : Enum
        {
            if (!Continue || value is null)
                return this;

            if (!Enum.IsDefined(typeof(TEnum), value))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidEnum), paramName, cultureName: CultureName), message));

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
            if (!Continue || value is null)
                return this;

            if (!value.GetType().IsAssignableTo(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstNotAssignableTo), paramName, [typeof(TBase).Name], CultureName), message));

            return this;
        }

        public Guard<T> AgainstNotAssignableTo<TBase>(
            Expression<Func<T, object?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            object? value = property.GetValue(Value);

            if (value is null)
                return this;

            if (!value.GetType().IsAssignableTo(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstNotAssignableTo), property.GetName(), [typeof(TBase).Name], CultureName), message));

            return this;
        }

        new public Guard<T> AgainstNotAssignableFrom<TBase>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null)
                return this;

            if (!value.GetType().IsAssignableFrom(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstNotAssignableFrom), paramName, [typeof(TBase).Name], CultureName), message));

            return this;
        }

        public Guard<T> AgainstNotAssignableFrom<TBase>(
            Expression<Func<T, object?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            object? value = property.GetValue(Value);

            if (value is null)
                return this;

            if (!value.GetType().IsAssignableFrom(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstNotAssignableFrom), property.GetName(), [typeof(TBase).Name], CultureName), message));

            return this;
        }

        new public Guard<T> AgainstNotTypeOf<TExpected>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null)
                return this;

            if (!value.GetType().Equals(typeof(TExpected)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstNotTypeOf), paramName, [typeof(TExpected).Name], CultureName), message));

            return this;
        }

        public Guard<T> AgainstNotTypeOf<TExpected>(
            Expression<Func<T, object?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            object? value = property.GetValue(Value);

            if (value is null)
                return this;

            if (!value.GetType().Equals(typeof(TExpected)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstNotTypeOf), property.GetName(), [typeof(TExpected).Name], CultureName), message));

            return this;
        }

        new public Guard<T> AgainstAssignableTo<TBase>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null)
                return this;

            if (value.GetType().IsAssignableTo(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstAssignableTo), paramName, [typeof(TBase).Name], CultureName), message));

            return this;
        }

        public Guard<T> AgainstAssignableTo<TBase>(
            Expression<Func<T, object?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            object? value = property.GetValue(Value);

            if (value is null)
                return this;

            if (value.GetType().IsAssignableTo(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstAssignableTo), property.GetName(), [typeof(TBase).Name], CultureName), message));

            return this;
        }

        new public Guard<T> AgainstAssignableFrom<TBase>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null)
                return this;

            if (value.GetType().IsAssignableFrom(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstAssignableFrom), paramName, [typeof(TBase).Name], CultureName), message));

            return this;
        }

        public Guard<T> AgainstAssignableFrom<TBase>(
            Expression<Func<T, object?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            object? value = property.GetValue(Value);

            if (value is null)
                return this;

            if (value.GetType().IsAssignableFrom(typeof(TBase)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstAssignableFrom), property.GetName(), [typeof(TBase).Name], CultureName), message));

            return this;
        }

        new public Guard<T> AgainstTypeOf<TExpected>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null)
                return this;

            if (value.GetType().Equals(typeof(TExpected)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstTypeOf), paramName, [typeof(TExpected).Name], CultureName), message));

            return this;
        }

        public Guard<T> AgainstTypeOf<TExpected>(
            Expression<Func<T, object?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            object? value = property.GetValue(Value);

            if (value is null)
                return this;

            if (value.GetType().Equals(typeof(TExpected)))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstTypeOf), property.GetName(), [typeof(TExpected).Name], CultureName), message));

            return this;
        }

        new public Guard<T> AgainstInvalidEnum<TEnum>(
            object? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where TEnum : Enum
        {
            if (!Continue || value is null)
                return this;

            if (!Enum.IsDefined(typeof(TEnum), value))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidEnum), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstInvalidEnum<TEnum>(
            Expression<Func<T, object?>> property,
            string? message = null)
                where TEnum : Enum
        {
            if (!Continue || property is null)
                return this;

            object? value = property.GetValue(Value);

            if (value is null)
                return this;

            if (!Enum.IsDefined(typeof(TEnum), value))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidEnum), property.GetName(), cultureName: CultureName), message));

            return this;
        }
    }
}
