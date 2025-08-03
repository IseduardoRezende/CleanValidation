using CleanValidation.Core.Errors;
using CleanValidation.Core.Exceptions;

namespace CleanValidation.Core.Results
{
    /// <summary>
    /// Represents a result that indicates a conflict, containing error details.
    /// </summary>
    /// <remarks>This class is used to encapsulate error information when an operation conflicts. It provides a
    /// collection of errors that describe the conflict. Instances of <see cref="ConflictResult"/> are always considered
    /// unsuccessful.</remarks>
    public class ConflictResult : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        protected ConflictResult(IEnumerable<Error> errors)
        {
            CleanValidationException.ThrowIfEmpty(errors);

            Errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        protected ConflictResult(Error error) : this([error]) { }

        /// <summary>
        /// The errors associated with the current instance.
        /// </summary>
        public IEnumerable<Error> Errors { get; }

        /// <summary>
        /// Boolean indicating the operation status.
        /// </summary>
        public bool IsValid { get { return false; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        /// <returns>The <see cref="ConflictResult"/> instance.</returns>
        public static ConflictResult Create(IEnumerable<Error> errors)
        {
            return new ConflictResult(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        /// <returns>The <see cref="ConflictResult"/> instance.</returns>
        public static ConflictResult Create(Error error)
        {
            return new ConflictResult(error);
        }
    }

    /// <summary>
    /// Represents a result that indicates a conflict, containing error details.
    /// </summary>
    /// <remarks>This class is used to encapsulate error information when an operation conflicts. It provides a
    /// collection of errors that describe the conflict. Instances of <see cref="ConflictResult{T}"/> are always considered
    /// unsuccessful.</remarks>
    public class ConflictResult<T> : ConflictResult, IResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult{T}"/> class.
        /// </summary>
        /// <param name="value">The value of type <typeparamref name="T"/>.</param>
        /// <param name="errors">The entry errors.</param>
        protected ConflictResult(T? value, IEnumerable<Error> errors) : base(errors)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult{T}"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        protected ConflictResult(IEnumerable<Error> errors) : base(errors) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult{T}"/> class.
        /// </summary>
        /// <param name="value">The value of type <typeparamref name="T"/>.</param>
        /// <param name="error">The entry error.</param>
        protected ConflictResult(T? value, Error error) : base(error)
        {
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult{T}"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        protected ConflictResult(Error error) : base(error) { }

        /// <summary>
        /// The value of type <typeparamref name="T"/>.
        /// </summary>
        public T? Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult{T}"/> class.
        /// </summary>
        /// <param name="value">The value of type <typeparamref name="T"/>.</param>
        /// <param name="errors">The entry errors.</param>
        /// <returns>The <see cref="ConflictResult{T}"/> instance.</returns>
        public static ConflictResult<T> Create(T? value, IEnumerable<Error> errors)
        {
            return new ConflictResult<T>(value, errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult{T}"/> class.
        /// </summary>
        /// <param name="errors">The entry errors.</param>
        /// <returns>The <see cref="ConflictResult{T}"/> instance.</returns>
        new public static ConflictResult<T> Create(IEnumerable<Error> errors)
        {
            return new ConflictResult<T>(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult{T}"/> class.
        /// </summary>
        /// <param name="value">The value of type <typeparamref name="T"/>.</param>
        /// <param name="error">The entry error.</param>
        /// <returns>The <see cref="ConflictResult{T}"/> instance.</returns>
        public static ConflictResult<T> Create(T? value, Error error)
        {
            return new ConflictResult<T>(value, error);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConflictResult{T}"/> class.
        /// </summary>
        /// <param name="error">The entry error.</param>
        /// <returns>The <see cref="ConflictResult{T}"/> instance.</returns>
        new public static ConflictResult<T> Create(Error error)
        {
            return new ConflictResult<T>(error);
        }
    }
}
