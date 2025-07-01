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
            foreach (var field in fields)
            {
                yield return InvalidParameter(cultureName, field);
            }
        }
    }
}
