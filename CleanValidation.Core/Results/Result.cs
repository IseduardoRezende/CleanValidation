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
    public abstract class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="success">Boolean indicating the operation status.</param>
        protected Result(bool success)
        {
            Success = success;
        }

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
    public abstract class Result<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        /// <param name="value">The value of type <typeparamref name="T"/>.</param>
        /// <param name="success">Boolean indicating the operation status.</param>
        protected Result(T? value, bool success)
        {
            Value = value;
            Success = success;
        }

        /// <summary>
        /// The value of type <typeparamref name="T"/>.
        /// </summary>
        public T? Value { get; }

        /// <summary>
        /// Boolean indicating the operation status.
        /// </summary>
        public bool Success { get; }                
    }
}
