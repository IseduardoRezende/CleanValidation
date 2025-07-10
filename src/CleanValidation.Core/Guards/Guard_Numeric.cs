using System.Numerics;
using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {        
        public Guard AgainstLessThan<T>(T? value, T min, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparisonOperators<T, T, bool>
        {
            if (Continue && (value is null || value < min))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstGreaterThan<T>(T? value, T max, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where T : IComparisonOperators<T, T, bool>
        {
            if (Continue && (value is null || value > max))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }                      
    }

    public partial class Guard<T>
    {        
        new public Guard<T> AgainstLessThan<TValue>(TValue? value, TValue min, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where TValue : IComparisonOperators<TValue, TValue, bool>
        {
            if (Continue && (value is null || value < min))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstGreaterThan<TValue>(TValue? value, TValue max, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
            where TValue : IComparisonOperators<TValue, TValue, bool>
        {
            if (Continue && (value is null || value > max))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }                      
    }
}
