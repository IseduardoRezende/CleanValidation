using CleanValidation.Core.Errors;

namespace CleanValidation.Core.Results
{
    /// <summary>
    /// Represents a result that indicates not finding, containing error details.
    /// </summary>
    /// <remarks>This class is used to encapsulate error information when an operation is not found. It provides a
    /// collection of errors that describe the disappearance. Instances of <see cref="NotFoundResult"/> are always considered
    /// unsuccessful.</remarks>
    public class NotFoundResult : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundResult"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        protected NotFoundResult(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundResult"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        protected NotFoundResult(Error error) : this([error]) { }

        /// <summary>
        /// The errors associated with the current instance.
        /// </summary>
        public IEnumerable<Error> Errors { get; }

        /// <summary>
        /// Boolean indicating the operation status.
        /// </summary>
        public bool Success { get { return false; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundResult"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        /// <returns>The <see cref="NotFoundResult"/> instance.</returns>
        public static NotFoundResult Create(IEnumerable<Error> errors)
        {
            return new NotFoundResult(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundResult"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        /// <returns>The <see cref="NotFoundResult"/> instance.</returns>
        public static NotFoundResult Create(Error error)
        {
            return new NotFoundResult(error);
        }
    }

    /// <summary>
    /// Represents a result that indicates not finding, containing error details.
    /// </summary>
    /// <remarks>This class is used to encapsulate error information when an operation is not found. It provides a
    /// collection of errors that describe the disappearance. Instances of <see cref="NotFoundResult{T}"/> are always considered
    /// unsuccessful.</remarks>
    public class NotFoundResult<T> : NotFoundResult, IResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundResult{T}"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        protected NotFoundResult(IEnumerable<Error> errors) : base(errors) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundResult{T}"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        protected NotFoundResult(Error error) : base(error) { }

        /// <summary>
        /// The value of type <typeparamref name="T"/>.
        /// </summary>
        public T? Value { get { return default; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundResult{T}"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        /// <returns>The <see cref="NotFoundResult{T}"/> instance.</returns>
        new public static NotFoundResult<T> Create(IEnumerable<Error> errors)
        {
            return new NotFoundResult<T>(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundResult{T}"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        /// <returns>The <see cref="NotFoundResult{T}"/> instance.</returns>
        new public static NotFoundResult<T> Create(Error error)
        {
            return new NotFoundResult<T>(error);
        }       
    }
}
