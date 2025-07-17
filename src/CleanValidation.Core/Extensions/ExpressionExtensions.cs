using System.Reflection;
using System.Linq.Expressions;

namespace CleanValidation.Core.Extensions
{
    public static class ExpressionExtensions
    {
        public static string GetName<T, TProperty>(this Expression<Func<T, TProperty?>> propertyExpression)
        {
            if (propertyExpression is null || propertyExpression.Body is not MemberExpression memberExpression)
                return string.Empty;

            if (memberExpression.Member is not PropertyInfo propInfo)
                return string.Empty;

            if (!propInfo.ReflectedType!.IsAssignableFrom(typeof(T)))
                return string.Empty;

            return propInfo.Name;
        }

        public static TProperty? GetValue<T, TProperty>(
            this Expression<Func<T, TProperty?>> propertyExpression,
            T? value)
        {
            if (propertyExpression is null || value is null)
                return default;

            return propertyExpression.Compile().Invoke(value);
        }
    }
}
