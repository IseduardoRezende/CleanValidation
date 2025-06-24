using CleanValidation.Core.Exceptions;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    /// <summary>
    /// Provides a mechanism for validating input values and throwing <see cref="CleanValidationException"/> when validation fails.
    /// </summary>
    /// <remarks>
    /// The <see cref="GuardThrow"/> class is designed to facilitate input validation in a fluent
    /// manner. It allows chaining multiple validation methods, such as <see cref="AgainstNullOrWhiteSpace(string,
    /// string?)"/> and <see cref="AgainstNull(object?, string?)"/>.
    /// </remarks>
    public class GuardThrow
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
        /// Ensures that the specified value is not null or white space.
        /// </summary> 
        /// <remarks>
        /// If <paramref name="value"/> is null or white space, an <see cref="CleanValidationException.ThrowIfNullOrWhiteSpace(string, string?)"/>
        /// is throwned.
        /// </remarks>
        /// <param name="value">The value to validate.</param>
        /// <param name="paramName">The name of <paramref name="value"/> captured by expression or manually.</param>
        /// <returns>The current <see cref="GuardThrow"/> instance, allowing for method chaining.</returns>
        public GuardThrow AgainstNullOrWhiteSpace(string value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            CleanValidationException.ThrowIfNullOrWhiteSpace(value, paramName);
            return this;
        }

        /// <summary>
        /// Ensures that the specified value is not null.
        /// </summary>
        /// <remarks>
        /// If <paramref name="value"/> is null, an <see cref="CleanValidationException.ThrowIfNull(object?, string?)"/>
        /// is throwned.
        /// </remarks>
        /// <param name="value">The value to validate.</param>
        /// <param name="paramName">The name of <paramref name="value"/> captured by expression or manually.</param>
        /// <returns>The current <see cref="GuardThrow"/> instance, allowing for method chaining.</returns>
        public GuardThrow AgainstNull(object? value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            CleanValidationException.ThrowIfNull(value, paramName);
            return this;
        }
    }
}
