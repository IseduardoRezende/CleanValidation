using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Validators
{
    /// <summary>
    /// Provides an abstract base class for validating objects of type <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>
    /// This class defines a contract for implementing validation logic for objects of type
    /// <typeparamref name="T"/>. Derived classes must implement specific validation rules. 
    /// The validation process supports asynchronous execution and localized <see cref="Errors.Error.Message"/>.
    /// </remarks>
    /// <typeparam name="T">The type of object to be validated.</typeparam>
    public abstract class Validator<T> : IValidator<T>
    {
        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <remarks>
        /// This method checks the provided value against validation rules and logics.
        /// </remarks>
        /// <param name="value">The value to validate. This must conform to the expected format or constraints for validation.</param>
        /// <param name="cultureName">The name of the culture to use for message, specified as a culture identifier (e.g., "en-US"). Defaults
        /// to "en-US" if not provided.</param>
        /// <returns>A <see cref="IResult"/>
        /// object indicating whether the validation succeeded or failed.</returns>
        public virtual IResult Validate(T value, string cultureName = "en-US")
        {
            return Guard.Create(cultureName).AgainstNull(value).GetResult();
        }

        /// <summary>
        /// Validates the specified value asynchronously.
        /// </summary>
        /// <remarks>
        /// This method checks the provided value against validation rules and logics. 
        /// </remarks>
        /// <param name="value">The value to validate. This must conform to the expected format or constraints for validation.</param>
        /// <param name="cultureName">The name of the culture to use for message, specified as a culture identifier (e.g., "en-US"). Defaults
        /// to "en-US" if not provided.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests. If the operation is canceled, the task will complete with a
        /// canceled state.</param>
        /// <returns>A task that represents the asynchronous validation operation. The result contains a <see cref="IResult"/>
        /// object indicating whether the validation succeeded or failed.</returns>
        public virtual Task<IResult> ValidateAsync(
            T value, 
            string cultureName = "en-US", 
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Validate(value));
        }
    }
}
