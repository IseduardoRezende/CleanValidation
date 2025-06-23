namespace CleanValidation.Core.Results
{
    /// <summary>
    /// Represents the result of an operation, encapsulating a success status.
    /// </summary>
    /// <remarks>
    /// This class is designed to provide a standardized way to represent the outcome of an
    /// operation. It includes a boolean indicating whether the operation
    /// was successful.
    /// </remarks>
    public interface IResult
    {        
        /// <summary>
        /// Boolean indicating the operation status.
        /// </summary>
        public bool Success { get; }
    }

    /// <summary>
    /// Represents the result of an operation, encapsulating a value and a success status.
    /// </summary>
    /// <remarks>
    /// This class is designed to provide a standardized way to represent the outcome of an
    /// operation. It includes a value of type <typeparamref name="T"/> and a boolean indicating whether the operation
    /// was successful.
    /// </remarks>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    public interface IResult<T> : IResult
    {        
        /// <summary>
        /// The value of type <typeparamref name="T"/>.
        /// </summary>
        public T? Value { get; }             
    }
}
