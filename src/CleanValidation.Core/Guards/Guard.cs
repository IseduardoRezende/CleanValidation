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
    /// validation succeeded. If validation fails, the <see cref="IResult"/> property is updated with an error
    /// result.
    /// </remarks>
    public partial class Guard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Guard"/> class.
        /// </summary>
        /// <param name="result">The initial result.</param>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        protected Guard(IResult result, string cultureName)
        {
            Result = result;
            CultureName = cultureName;
        }

        /// <summary>
        /// The result associated with the validations
        /// </summary>
        protected IResult Result { get; set; }

        /// <summary>
        /// The name of the culture to use for message.
        /// </summary>
        public string CultureName { get; }

        /// <summary>
        /// Determines wheter chaining validation may continue.
        /// </summary>
        protected bool Continue { get { return Result.Success; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guard"/> class with <see cref="Result"/> property 
        /// being <see cref="SuccessResult"/>.
        /// </summary>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        /// <returns>The <see cref="Guard"/> instance, allowing for method chaining.</returns>
        public static Guard Create(string cultureName = "en-US")
        {
            return new Guard(result: SuccessResult.Create(), cultureName);
        }

        /// <summary>
        /// Gets the <see cref="Result"/> property.
        /// </summary>
        /// <returns>The result of chaining validations.</returns>
        public IResult GetResult()
        {
            return Result;
        }                          
    }

    /// <summary>
    /// Provides a mechanism for validating input values and generating error results when validation fails.
    /// </summary>
    /// <remarks>
    /// The <see cref="Guard{T}"/> class is designed to facilitate input validation in a fluent
    /// manner. It allows chaining multiple validation methods, such as <see cref="AgainstWhiteSpace(string,
    /// string?, string?)"/> and <see cref="AgainstNull(object?, string?, string?)"/>, while maintaining a result that indicates whether
    /// validation succeeded. If validation fails, the <see cref="Result"/> property is updated with an error
    /// result.
    /// </remarks>
    /// <typeparam name="T">The type associated with the validation result.</typeparam>
    public partial class Guard<T> : Guard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Guard{T}"/> class.
        /// </summary>
        /// <param name="result">The initial result.</param>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        protected Guard(IResult<T> result, string cultureName) : base(result, cultureName)
        {
            Result = result;
        }

        /// <summary>
        /// The result associated with the validations
        /// </summary>
        new protected IResult<T> Result { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Guard{T}"/> class with <see cref="Result"/> property 
        /// being <see cref="SuccessResult{T}"/>.
        /// </summary>
        /// <param name="cultureName">The name of the culture to use for message.</param>
        /// <returns>The <see cref="Guard{T}"/> instance, allowing for method chaining.</returns>
        new public static Guard<T> Create(string cultureName = "en-US")
        {
            return new Guard<T>(result: SuccessResult<T>.Create(default), cultureName);
        }

        /// <summary>
        /// Gets the <see cref="Result"/> property.
        /// </summary>
        /// <returns>The result of chaining validations.</returns>
        new public IResult<T> GetResult()
        {
            return Result;
        }        
    }
}
