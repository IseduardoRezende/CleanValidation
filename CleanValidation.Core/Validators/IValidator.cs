using CleanValidation.Core.Results;

namespace CleanValidation.Core.Validators
{
    /// <summary>
    /// Defines a contract for validating objects of type <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>
    /// Implementations of this interface provide asynchronous validation logic for objects of type
    /// <typeparamref name="T"/>. Validation <see cref="Errors.Error.Message"/> may be influenced by culture-specific 
    /// name and can be canceled using a <see cref="CancellationToken"/>.
    /// </remarks>
    /// <typeparam name="T">The type of object to be validated.</typeparam>
    public interface IValidator<T>
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
        /// <returns>A <see cref="Result"/>
        /// object indicating whether the validation succeeded or failed.</returns>
        Result Validate(T value, string cultureName = "en-US");

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
        /// <returns>A task that represents the asynchronous validation operation. The result contains a <see cref="Result"/>
        /// object indicating whether the validation succeeded or failed.</returns>
        Task<Result> ValidateAsync(
            T value, 
            string cultureName = "en-US", 
            CancellationToken cancellationToken = default);
    }
}
