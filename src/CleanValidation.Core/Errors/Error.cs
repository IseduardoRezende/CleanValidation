namespace CleanValidation.Core.Errors
{
    /// <summary>
    /// Represents an error that occurred during an operation, including a descriptive message and an optional field
    /// name.
    /// </summary>
    /// <remarks>This class is typically used to encapsulate error details for validation or processing
    /// failures. The <see cref="Field"/> property can be used to identify the specific field or parameter associated
    /// with the error, if applicable.</remarks>
    public class Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        /// <param name="message">Descriptive message.</param>
        /// <param name="field">Optional specific field or parameter associated.</param>
        public Error(string message, string? field)
        {
            Message = message;
            Field = field;
        }

        /// <summary>
        /// Descriptive message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Optional specific field or parameter associated.
        /// </summary>
        public string? Field { get; }
    }
}
