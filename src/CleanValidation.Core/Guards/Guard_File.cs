using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {        
        public Guard AgainstInvalidContentTypes(IEnumerable<byte>? bytes, IEnumerable<string> types, string? message = null, [CallerArgumentExpression(nameof(bytes))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (bytes is null || types is null)
            {
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));
                return this;
            }

            if (!IsValidContentType(bytes, types))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        protected static bool IsValidContentType(IEnumerable<byte> _, IEnumerable<string> __)
        {
            return false;
        }
    }

    public partial class Guard<T>
    {       
        new public Guard<T> AgainstInvalidContentTypes(IEnumerable<byte>? bytes, IEnumerable<string> types, string? message = null, [CallerArgumentExpression(nameof(bytes))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (bytes is null || types is null)
            {
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));
                return this;
            }

            if (!IsValidContentType(bytes, types))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }
}
