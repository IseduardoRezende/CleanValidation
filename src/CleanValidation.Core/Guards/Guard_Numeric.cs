using System.Numerics;
using System.Linq.Expressions;
using CleanValidation.Core.Errors;
using System.Runtime.CompilerServices;
using CleanValidation.Core.Extensions;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstLessThan<T>(
            T? value,
            T? min,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where T : IComparisonOperators<T, T, bool>
        {
            if (!Continue || value is null || min is null)
                return this;

            if (value < min)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstLessThan), paramName, [min], CultureName), message));

            return this;
        }

        public Guard AgainstGreaterThan<T>(
            T? value,
            T? max,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where T : IComparisonOperators<T, T, bool>
        {
            if (!Continue || value is null || max is null)
                return this;

            if (value > max)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstGreaterThan), paramName, [max], CultureName), message));

            return this;
        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstLessThan<TValue>(
            TValue? value,
            TValue? min,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where TValue : IComparisonOperators<TValue, TValue, bool>
        {
            if (!Continue || value is null || min is null)
                return this;

            if (value < min)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstLessThan), paramName, [min], CultureName), message));

            return this;
        }

        public Guard<T> AgainstLessThan<TProperty>(
            Expression<Func<T, TProperty?>> property,
            TProperty? min,
            string? message = null)
                where TProperty : IComparisonOperators<TProperty, TProperty, bool>
        {
            if (!Continue || property is null || min is null)
                return this;

            TProperty? value = property.GetValue(Value);

            if (value is null)
                return this;

            if (value < min)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstLessThan), property.GetName(), [min], CultureName), message));

            return this;
        }

        new public Guard<T> AgainstGreaterThan<TValue>(
            TValue? value,
            TValue? max,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
                where TValue : IComparisonOperators<TValue, TValue, bool>
        {
            if (!Continue || value is null || max is null)
                return this;

            if (value > max)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstGreaterThan), paramName, [max], CultureName), message));

            return this;
        }

        public Guard<T> AgainstGreaterThan<TProperty>(
            Expression<Func<T, TProperty?>> property,
            TProperty? max,
            string? message = null)
                where TProperty : IComparisonOperators<TProperty, TProperty, bool>
        {
            if (!Continue || property is null || max is null)
                return this;

            TProperty? value = property.GetValue(Value);

            if (value is null)
                return this;

            if (value > max)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstGreaterThan), property.GetName(), [max], CultureName), message));

            return this;
        }
    }
}
