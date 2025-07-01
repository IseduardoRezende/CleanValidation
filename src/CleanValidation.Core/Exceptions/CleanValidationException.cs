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
    }
}
