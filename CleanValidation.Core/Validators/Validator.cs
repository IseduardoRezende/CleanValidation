using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Validators
{
    public abstract class Validator<T> : IValidator<T>
    {
        public virtual Task<Result<T>> ValidateAsync(
            T value, 
            string cultureName = "en-US", 
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Guard<T>.Create(cultureName).AgainstNull(value).Result);
        }
    }
}
