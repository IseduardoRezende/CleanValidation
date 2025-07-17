using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {        
        public Guard AgainstInvalidContentTypes(
            IEnumerable<byte>? bytes, 
            IEnumerable<string> types,
            string? message = null, 
            [CallerArgumentExpression(nameof(bytes))] string? paramName = null)
        {
            if (Continue && !IsValidContentType(bytes, types))
                Result = InvalidResult.Create([]);
                
            return this;
        }

        protected static bool IsValidContentType(IEnumerable<byte>? bytes, IEnumerable<string> types)
        {
            return false;
        }
    }

    public partial class Guard<T>
    {       
        new public Guard<T> AgainstInvalidContentTypes(
            IEnumerable<byte>? bytes, 
            IEnumerable<string> types, 
            string? message = null, 
            [CallerArgumentExpression(nameof(bytes))] string? paramName = null)
        {
            if (Continue && !IsValidContentType(bytes, types))
                Result = InvalidResult<T>.Create([]);

            return this;
        }
    }
}
