using CleanValidation.Core.Errors;

namespace CleanValidation.Core.Results
{
    /// <summary>
    /// Represents a result that indicates a invalidity, containing error details.
    /// </summary>
    /// <remarks>This class is used to encapsulate error information when an operation is invalid. It provides a
    /// collection of errors that describe the invalidity. Instances of <see cref="InvalidResult"/> are always considered
    /// unsuccessful.</remarks>
    public class InvalidResult : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidResult"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        protected InvalidResult(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidResult"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        protected InvalidResult(Error error) : this([error]) { }

        /// <summary>
        /// The errors associated with the current instance.
        /// </summary>
        public IEnumerable<Error> Errors { get; }

        /// <summary>
        /// Boolean indicating the operation status.
        /// </summary>
        public bool Success { get { return false; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidResult"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        /// <returns>The <see cref="InvalidResult"/> instance.</returns>
        public static InvalidResult Create(IEnumerable<Error> errors)
        {
            return new InvalidResult(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidResult"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        /// <returns>The <see cref="InvalidResult"/> instance.</returns>
        public static InvalidResult Create(Error error)
        {
            return new InvalidResult(error);
        }
    }

    /// <summary>
    /// Represents a result that indicates a invalidity, containing error details.
    /// </summary>
    /// <remarks>This class is used to encapsulate error information when an operation is invalid. It provides a
    /// collection of errors that describe the invalidity. Instances of <see cref="InvalidResult{T}"/> are always considered
    /// unsuccessful.</remarks>
    public class InvalidResult<T> : InvalidResult, IResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidResult{T}"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        protected InvalidResult(IEnumerable<Error> errors) : base(errors) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidResult{T}"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        protected InvalidResult(Error error) : base(error) { }

        /// <summary>
        /// The value of type <typeparamref name="T"/>.
        /// </summary>
        public T? Value { get { return default; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidResult{T}"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        /// <returns>The <see cref="InvalidResult{T}"/> instance.</returns>
        new public static InvalidResult<T> Create(IEnumerable<Error> errors)
        {
            return new InvalidResult<T>(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidResult{T}"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        /// <returns>The <see cref="InvalidResult{T}"/> instance.</returns>
        new public static InvalidResult<T> Create(Error error)
        {
            return new InvalidResult<T>(error);
        }
    }
}
