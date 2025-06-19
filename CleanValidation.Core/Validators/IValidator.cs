using CleanValidation.Core.Results;

namespace CleanValidation.Core.Validators
{
    public interface IValidator<T>
    {
        Task<Result<T>> ValidateAsync(
            T value, 
            string cultureName = "en-US", 
            CancellationToken cancellationToken = default);
    }
}
