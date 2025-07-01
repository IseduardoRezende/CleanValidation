using CleanValidation.Core.Exceptions;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.GuardThrows
{
    /// <summary>
    /// Provides a mechanism for validating input values and throwing <see cref="CleanValidationException"/> when validation fails.
    /// </summary>
    /// <remarks>
    /// The <see cref="GuardThrow"/> class is designed to facilitate input validation in a fluent
    /// manner. It allows chaining multiple validation methods, such as <see cref="AgainstWhiteSpace(string,
    /// string?, string?)"/> and <see cref="AgainstNull(object?, string?,  string?)"/>.
    /// </remarks>
    public partial class GuardThrow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuardThrow"/> class.
        /// </summary>
        protected GuardThrow() { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GuardThrow"/> class.
        /// </summary>
        /// <returns></returns>
        public static GuardThrow Create()
        {
            return new GuardThrow();
        }

        /// <summary>
        /// Adds <paramref name="paramName"/> into the error message.
        /// </summary>
        /// <param name="paramName">The paramter name.</param>
        /// <returns></returns>
        protected static string AddParamNameMessage(string? paramName)
        {
            return paramName is not null ? $"\nParameter Name: {paramName}" : string.Empty;
        }

        /// <summary>
        /// Ensures that the specified value is not null or white space.
        /// </summary> 
        /// <remarks>
        /// If <paramref name="value"/> is null or white space, an <see cref="CleanValidationException"/>
        /// is throwned.
        /// </remarks>
        /// <param name="value">The value to validate.</param>
        /// <param name="message">Optional descriptive message error.</param>
        /// <param name="paramName">The name of <paramref name="value"/> captured by expression or manually.</param>
        /// <returns>The current <see cref="GuardThrow"/> instance, allowing for method chaining.</returns>
        public GuardThrow AgainstWhiteSpace(string value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new CleanValidationException($"Argument is null or white space. {AddParamNameMessage(paramName)}");

            return this;
        }

        /// <summary>
        /// Ensures that the specified value is not null.
        /// </summary>
        /// <remarks>
        /// If <paramref name="value"/> is null, an <see cref="CleanValidationException"/>
        /// is throwned.
        /// </remarks>
        /// <param name="value">The value to validate.</param>
        /// <param name="message">Optional descriptive message error.</param>
        /// <param name="paramName">The name of <paramref name="value"/> captured by expression or manually.</param>
        /// <returns>The current <see cref="GuardThrow"/> instance, allowing for method chaining.</returns>
        public GuardThrow AgainstNull(object? value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (value is null)
                throw new CleanValidationException($"Argument is null. {AddParamNameMessage(paramName)}");

            return this;
        }
    }
}
