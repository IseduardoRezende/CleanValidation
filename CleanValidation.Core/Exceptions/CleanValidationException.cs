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
        protected CleanValidationException(string message) : base(message) { }

        /// <summary>
        /// Adds <paramref name="paramName"/> into the <see cref="CleanValidationException"/> message.
        /// </summary>
        /// <param name="paramName">The paramter name being throwned.</param>
        /// <returns></returns>
        protected static string AddParamNameMessage(string? paramName)
        {            
            return paramName is not null ? $"\nParameter Name: {paramName}" : string.Empty;
        }

        /// <summary>
        /// Throws an exception if <paramref name="argument"/> is <see langword="null"/> or white space.
        /// </summary>
        /// <param name="argument">The value to validate.</param>
        /// <param name="paramName">The name of <paramref name="argument"/>.</param>
        /// <exception cref="CleanValidationException">Thrown if <paramref name="argument"/> is <see langword="null"/> or
        /// white space.</exception>
        public static void ThrowIfNullOrWhiteSpace(string argument, string? paramName = null)
        {
            if (string.IsNullOrWhiteSpace(argument))
                throw new CleanValidationException($"Argument is null or white space. {AddParamNameMessage(paramName)}");
        }

        /// <summary>
        /// Throws an exception if <paramref name="argument"/> is <see langword="null"/>.
        /// </summary>
        /// <param name="argument">The value to validate.</param>
        /// <param name="paramName">The name of <paramref name="argument"/>.</param>
        /// <exception cref="CleanValidationException">Thrown if <paramref name="argument"/> is <see langword="null"/>.</exception>
        public static void ThrowIfNull(object? argument, string? paramName = null)
        {
            if (argument is null)
                throw new CleanValidationException($"Argument is null. {AddParamNameMessage(paramName)}");
        }
    }
}
