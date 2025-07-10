using CleanValidation.Core.Resources;

namespace CleanValidation.Core.Errors
{
    /// <summary>
    /// Provides utility methods for creating and managing error objects.
    /// </summary>
    /// <remarks>This class includes methods for generating errors related to invalid operations and invalid
    /// parameters. It is designed to simplify the creation of error objects with localized messages and optional field
    /// information.</remarks>
    public static class ErrorUtils
    {
        /// <summary>
        /// Creates a custom error based on the specified default error, optionally overriding its message.
        /// </summary>
        /// <param name="defaultError">The default error to use as a base. This parameter cannot be <see langword="null"/>.</param>
        /// <param name="message">An optional custom message for the error. If <see langword="null"/> or whitespace, the message of the
        /// <paramref name="defaultError"/> is used instead.</param>
        /// <returns>A new <see cref="Error"/> instance with the specified message or the <paramref
        /// name="defaultError"/> if no custom message is provided.</returns>
        public static Error Custom(in Error defaultError, string? message)
        {
            ArgumentNullException.ThrowIfNull(defaultError);

            if (string.IsNullOrWhiteSpace(message))
                return defaultError;

            return new Error(message, defaultError.Field);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Error"/> class with localized "Invalid Operation." message.
        /// </summary>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        /// <returns></returns>
        public static Error InvalidOperation(string cultureName)
        {
            return new Error(ResourceManager.GetString("ErrorUtils_InvalidOperation", cultureName), field: null);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Error"/> class with localized "Invalid Paramater." message.
        /// </summary>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        /// <param name="field">The name of the invalid field.</param>
        /// <returns></returns>
        public static Error InvalidParameter(string cultureName, string? field) 
        { 
            return new Error(ResourceManager.GetString("ErrorUtils_InvalidParameter", cultureName), field);
        }

        /// <summary>
        /// Creates new instances of the <see cref="Error"/> class with localized "Invalid Paramater." messages.
        /// </summary>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        /// <param name="fields">The name of the invalid fields.</param>
        /// <returns></returns>
        public static IEnumerable<Error> InvalidParameters(string cultureName, params IEnumerable<string> fields)
        {
            foreach (string? field in fields)
            {
                yield return InvalidParameter(cultureName, field);
            }
        }
    }
}
