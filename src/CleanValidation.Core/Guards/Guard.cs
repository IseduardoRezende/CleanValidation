using CleanValidation.Core.Errors;
using CleanValidation.Core.Options;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Guards
{
    /// <summary>
    /// Provides a mechanism for validating input values and generating error results when validation fails.
    /// </summary>
    /// <remarks>
    /// The <see cref="Guard"/> class is designed to facilitate input validation in a fluent
    /// manner. It allows chaining multiple validation methods, such as <see cref="AgainstWhiteSpace(string?,
    /// string?, string?)"/> and <see cref="AgainstNull(object?, string?, string?)"/>, while maintaining a result that indicates whether
    /// validation succeeded. If validation fails, the <see cref="GetResult"/> method is updated with an invalid
    /// result.
    /// </remarks>
    public partial class Guard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Guard"/> class.
        /// </summary>
        /// <param name="validationOption">The validation option used to configure the behavior of validation operations.</param>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        protected Guard(ValidationOptions validationOption, string cultureName)
        {
            ValidationOption = validationOption;
            CultureName = cultureName;

            ErrorBag = new ErrorBag();
        }

        /// <summary>
        /// Represents the collection of errors encountered during the validations.
        /// </summary>
        protected ErrorBag ErrorBag { get; }

        /// <summary>
        /// The name of the culture to use for message.
        /// </summary>
        protected string CultureName { get; }

        /// <summary>
        /// Determines wheter chaining validation may continue.
        /// </summary>
        protected bool Continue
        {
            get
            {
                return ValidationOption is ValidationOptions.ContinueOnFailure || ErrorBag.Count is 0;
            }
        }

        /// <summary>
        /// Gets the validation option used to configure the behavior of validation operations.
        /// </summary>
        protected ValidationOptions ValidationOption { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guard"/> class.
        /// </summary>
        /// <param name="validationOption">
        /// The validation option used to configure the behavior of validation operations.
        /// The default value is <see cref="ValidationOptions.ContinueOnFailure"/>.
        /// </param>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        /// <returns>The <see cref="Guard"/> instance, allowing for method chaining.</returns>
        public static Guard Create(
            ValidationOptions validationOption = ValidationOptions.ContinueOnFailure,
            string cultureName = "en-US")
        {
            return new Guard(validationOption, cultureName);
        }

        /// <summary>
        /// Retrieves the result of an operation, indicating success or failure.
        /// </summary>
        /// <remarks>If there are errors, the method returns an invalid result containing the error
        /// details. Otherwise, it returns a success result. Use this method to determine the outcome of the
        /// operation.</remarks>
        /// <returns>An <see cref="IResult"/> representing the outcome of the operation.  Returns an <see cref="InvalidResult"/>
        /// if errors are present, or a <see cref="SuccessResult"/> if the operation succeeded.</returns>
        public IResult GetResult()
        {
            return ErrorBag.Count is not 0
                ? InvalidResult.Create(ErrorBag.Errors)
                : SuccessResult.Create();
        }
    }

    /// <summary>
    /// Provides a mechanism for validating input values and generating error results when validation fails.
    /// </summary>
    /// <remarks>
    /// The <see cref="Guard{T}"/> class is designed to facilitate input validation in a fluent
    /// manner. It allows chaining multiple validation methods, such as <see cref="AgainstWhiteSpace(string,
    /// string?, string?)"/> and <see cref="AgainstNull(object?, string?, string?)"/>, while maintaining a result that indicates whether
    /// validation succeeded. If validation fails, the <see cref="GetResult"/> method is updated with an invalid
    /// result.
    /// </remarks>
    /// <typeparam name="T">The type associated with the validation result.</typeparam>
    public partial class Guard<T> : Guard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Guard{T}"/> class.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationOption">The validation option used to configure the behavior of validation operations.</param>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        protected Guard(T? value, ValidationOptions validationOption, string cultureName)
            : base(validationOption, cultureName)
        {
            Value = value;
        }

        /// <summary>
        /// The value to validate.
        /// </summary>
        protected T? Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guard{T}"/> class.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationOption">
        /// The validation option used to configure the behavior of validation operations.
        /// The default value is <see cref="ValidationOptions.ContinueOnFailure"/>.
        /// </param>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        /// <returns>The <see cref="Guard{T}"/> instance, allowing for method chaining.</returns>
        public static Guard<T> Create(
            T? value,
            ValidationOptions validationOption = ValidationOptions.ContinueOnFailure,
            string cultureName = "en-US")
        {
            return new Guard<T>(value, validationOption, cultureName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guard{T}"/> class.
        /// </summary>
        /// <param name="validationOption">
        /// The validation option used to configure the behavior of validation operations.
        /// The default value is <see cref="ValidationOptions.ContinueOnFailure"/>.
        /// </param>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        /// <returns>The <see cref="Guard{T}"/> instance, allowing for method chaining.</returns>
        new public static Guard<T> Create(
            ValidationOptions validationOption = ValidationOptions.ContinueOnFailure,
            string cultureName = "en-US")
        {
            return new Guard<T>(default, validationOption, cultureName);
        }

        /// <summary>
        /// Retrieves the result of an operation, indicating success or failure.
        /// </summary>
        /// <remarks>If there are errors, the method returns an invalid result containing the error
        /// details. Otherwise, it returns a success result. Use this method to determine the outcome of the
        /// operation.</remarks>
        /// <returns>An <see cref="IResult{T}"/> representing the outcome of the operation.  Returns an <see cref="InvalidResult{T}"/>
        /// if errors are present, or a <see cref="SuccessResult{T}"/> if the operation succeeded.</returns>
        new public IResult<T> GetResult()
        {
            return ErrorBag.Count is not 0
                 ? InvalidResult<T>.Create(Value, ErrorBag.Errors)
                 : SuccessResult<T>.Create(Value);
        }
    }
}
