namespace CleanValidation.Core.Results
{
    /// <summary>
    /// Represents a result that indicates success.
    /// </summary>
    /// <remarks>This class is used to encapsulate successful operations. 
    /// Instances of <see cref="SuccessResult"/> are always considered
    /// successful.</remarks>
    public class SuccessResult : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessResult"/> class.
        /// </summary>
        protected SuccessResult() { }

        /// <summary>
        /// Boolean indicating the operation status.
        /// </summary>
        public bool Success { get { return true; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessResult"/> class.
        /// </summary>
        /// <returns></returns>
        public static SuccessResult Create()
        {
            return new SuccessResult();
        }
    }

    /// <summary>
    /// Represents a result that indicates success, containing a value.
    /// </summary>
    /// <remarks>This class is used to encapsulate successful operations. 
    /// Instances of <see cref="SuccessResult{T}"/> are always considered
    /// successful.</remarks>
    /// <typeparam name="T">The type of the value associated with the result, if applicable.</typeparam>
    public class SuccessResult<T> : SuccessResult, IResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessResult{T}"/> class.
        /// </summary>
        /// <param name="value">The value of type <typeparamref name="T"/>.</param>
        protected SuccessResult(T? value)
        {
            Value = value;
        }

        /// <summary>
        /// The value of type <typeparamref name="T"/>.
        /// </summary>
        public T? Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessResult{T}"/> class.
        /// </summary>
        /// <param name="value">The value of type <typeparamref name="T"/>.</param>
        public static SuccessResult<T> Create(T? value)
        {
            return new SuccessResult<T>(value);
        } 
    }
}
