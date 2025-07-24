using CleanValidation.Core.Guards;
using CleanValidation.Core.Options;

namespace CleanValidation.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for working with <see cref="Guards.Guard{T}"/> instances.
    /// </summary>
    public static class GuardExtensions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Guards.Guard{T}"/> class.
        /// </summary>
        /// <typeparam name="T">The type associated with the validation result.</typeparam>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationOption">The validation option used to configure the behavior of validation operations.</param>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        /// <returns></returns>
        public static Guard<T> Guard<T>(
            this T? value,
            ValidationOptions validationOption = ValidationOptions.ContinueOnFailure,
            string cultureName = "en-US")
        {
            return Guards.Guard<T>.Create(value, validationOption, cultureName);
        }
    }
}
