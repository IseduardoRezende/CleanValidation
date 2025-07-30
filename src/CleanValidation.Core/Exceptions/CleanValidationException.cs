using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Exceptions
{
    /// <summary>
    /// Represents clean validation errors that occur during application execution. 
    /// </summary>
    public class CleanValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CleanValidationException"/> class.
        /// </summary>
        /// <param name="message">Descriptive message.</param>
        public CleanValidationException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CleanValidationException"/> class.
        /// </summary>
        /// <param name="message">Descriptive message.</param>
        /// <param name="innerException">The inner exception.</param>
        public CleanValidationException(string message, Exception? innerException)
            : base(message, innerException) { }

        public static void ThrowIfNull(
            object? obj,
            [CallerArgumentExpression(nameof(obj))] string? paramName = null)
        {
            if (obj is null)
                throw new CleanValidationException($"{paramName} can't be null.");
        }
    }
}
