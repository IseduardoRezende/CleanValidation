using CleanValidation.Core.Errors;

namespace CleanValidation.Core.Results
{
    /// <summary>
    /// Represents a result that indicates a failure, containing error details.
    /// </summary>
    /// <remarks>This class is used to encapsulate error information when an operation fails. It provides a
    /// collection of errors that describe the failure. Instances of <see cref="ErrorResult"/> are always considered
    /// unsuccessful.</remarks>
    public class ErrorResult : IResult
    {
        protected ErrorResult(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        protected ErrorResult(Error error) : this([error]) { }

        /// <summary>
        /// The errors associated with the current instance.
        /// </summary>
        public IEnumerable<Error> Errors { get; }

        public bool Success { get { return false; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        /// <returns>The <see cref="ErrorResult"/> instance.</returns>
        public static ErrorResult Create(IEnumerable<Error> errors)
        {
            return new ErrorResult(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        /// <returns>The <see cref="ErrorResult"/> instance.</returns>
        public static ErrorResult Create(Error error)
        {
            return new ErrorResult(error);
        }
    }

    /// <summary>
    /// Represents a result that indicates a failure, containing error details.
    /// </summary>
    /// <remarks>This class is used to encapsulate error information when an operation fails. It provides a
    /// collection of errors that describe the failure. Instances of <see cref="ErrorResult{T}"/> are always considered
    /// unsuccessful.</remarks>
    /// <typeparam name="T">The type of the value associated with the result, if applicable.</typeparam>
    public class ErrorResult<T> : ErrorResult, IResult<T>
    {
        protected ErrorResult(IEnumerable<Error> errors) : base(errors) { }

        protected ErrorResult(Error error) : base(error) { }

        public T? Value { get { return default; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult{T}"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        /// <returns>The <see cref="ErrorResult{T}"/> instance.</returns>
        new public static ErrorResult<T> Create(IEnumerable<Error> errors)
        {
            return new ErrorResult<T>(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult{T}"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        /// <returns>The <see cref="ErrorResult{T}"/> instance.</returns>
        new public static ErrorResult<T> Create(Error error)
        {
            return new ErrorResult<T>(error);
        }
    }
}
