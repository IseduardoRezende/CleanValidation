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
        /// Retrieves an <see cref="Error"/> object based on a specified resource key.
        /// </summary>
        /// <remarks>This method retrieves a localized error message from the specified resource file
        /// using the provided key and culture. If the key is not found in the resource file, the returned <see
        /// cref="Error"/> object will contain a <see cref="string.Empty"/> message.</remarks>
        /// <param name="messageKey">The key used to look up the error message in the resource file. Cannot be null or empty.</param>
        /// <param name="field">The name of the field associated with the error, or <see langword="null"/> if no field is specified.</param>
        /// <param name="cultureName">The culture name used to localize the error message. Defaults to "en-US" if not specified.</param>
        /// <param name="resourceBaseName">The base name of the resource file to use for the lookup. Defaults to the application's default resource
        /// base name.</param>
        /// <returns>An <see cref="Error"/> object containing the localized error message and the associated field.</returns>
        public static Error GetByKey(
            string messageKey,
            string? field,
            string cultureName = "en-US",
            string resourceBaseName = CleanResourceManager.DefaultBaseName)
        {
            return new Error(CleanResourceManager.Create(resourceBaseName)
                .GetString(messageKey, cultureName), field);
        }
    }
}
