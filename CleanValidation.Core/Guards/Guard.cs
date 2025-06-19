using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public class Guard<T>
    {
        private Guard(Result<T> result, string cultureName)
        {
            Result = result;
            CultureName = cultureName;
        }

        public Result<T> Result { get; private set; }

        public string CultureName { get; }

        private bool Continue { get { return Result.Sucess; } }
        
        public static Guard<T> Create(string cultureName)
        {
            return new Guard<T>(result: SuccessResult<T>.Create(default), cultureName);
        }

        public Guard<T> AgainstNullOrWhiteSpace(string value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && string.IsNullOrWhiteSpace(value))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard<T> AgainstNull<TIn>(TIn value)
        {
            if (Continue && value is null)
                Result = ErrorResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, field: null));

            return this;
        }        
    }
}
