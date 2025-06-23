using CleanValidation.Core.Errors;

namespace CleanValidation.Core.Results
{
    /// <summary>
    /// Represents a result that indicates a problem, containing error details.
    /// </summary>
    /// <remarks>This class is used to encapsulate error information when an operation has a problem. It provides a
    /// collection of errors that describe the problem. Instances of <see cref="ProblemResult"/> are always considered
    /// unsuccessful.</remarks>
    public class ProblemResult : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemResult"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        protected ProblemResult(IEnumerable<Error> errors)
        {
            Errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemResult"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        protected ProblemResult(Error error) : this([error]) { }

        /// <summary>
        /// The errors associated with the current instance.
        /// </summary>
        public IEnumerable<Error> Errors { get; }

        /// <summary>
        /// Boolean indicating the operation status.
        /// </summary>
        public bool Success { get { return false; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemResult"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        /// <returns>The <see cref="ProblemResult"/> instance.</returns>
        public static ProblemResult Create(IEnumerable<Error> errors)
        {
            return new ProblemResult(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemResult"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        /// <returns>The <see cref="ProblemResult"/> instance.</returns>
        public static ProblemResult Create(Error error)
        {
            return new ProblemResult(error);
        }
    }

    /// <summary>
    /// Represents a result that indicates a problem, containing error details.
    /// </summary>
    /// <remarks>This class is used to encapsulate error information when an operation has a problem. It provides a
    /// collection of errors that describe the problem. Instances of <see cref="ProblemResult{T}"/> are always considered
    /// unsuccessful.</remarks>
    public class ProblemResult<T> : ProblemResult, IResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemResult{T}"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        protected ProblemResult(IEnumerable<Error> errors) : base(errors) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemResult{T}"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        protected ProblemResult(Error error) : base(error) { }

        /// <summary>
        /// The value of type <typeparamref name="T"/>.
        /// </summary>
        public T? Value { get { return default; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemResult{T}"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        /// <returns>The <see cref="ProblemResult{T}"/> instance.</returns>
        new public static ProblemResult<T> Create(IEnumerable<Error> errors)
        {
            return new ProblemResult<T>(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemResult{T}"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        /// <returns>The <see cref="ProblemResult{T}"/> instance.</returns>
        new public static ProblemResult<T> Create(Error error)
        {
            return new ProblemResult<T>(error);
        }
    }
}
