using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    /// <summary>
    /// Provides a mechanism for validating input values and generating error results when validation fails.
    /// </summary>
    /// <remarks>
    /// The <see cref="Guard"/> class is designed to facilitate input validation in a fluent
    /// manner. It allows chaining multiple validation methods, such as <see cref="AgainstNullOrWhiteSpace(string,
    /// string?)"/> and <see cref="AgainstNull{TIn}(TIn)"/>, while maintaining a result that indicates whether
    /// validation succeeded. If validation fails, the <see cref="IResult"/> property is updated with an error
    /// result.
    /// </remarks>
    public class Guard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Guard"/> class.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="cultureName"></param>
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

        /// <summary>
        /// Ensures that the specified value is not null or white space.
        /// </summary>
        /// <remarks>
        /// If the <see cref="Continue"/> property is <see langword="true"/> and the
        /// provided value is null or white space, the <see cref="Result"/> property is updated with an error result
        /// indicating an invalid parameter.
        /// </remarks>
        /// <param name="value">The value to validate.</param>
        /// <param name="paramName">The name of <paramref name="value"/> captured by expression or manually.</param>
        /// <returns>The current <see cref="Guard"/> instance, allowing for method chaining.</returns>
        public Guard AgainstNullOrWhiteSpace(string value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && string.IsNullOrWhiteSpace(value))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        /// <summary>
        /// Ensures that the specified value is not null.
        /// </summary>
        /// <remarks>
        /// If the <see cref="Continue"/> property is <see langword="true"/> and the
        /// provided value is null, the <see cref="Result"/> property is updated with an error result
        /// indicating an invalid parameter.
        /// </remarks>
        /// <typeparam name="TIn">The type of the value being checked.</typeparam>
        /// <param name="value">The value to validate.</param>
        /// <returns>The current <see cref="Guard"/> instance, allowing for method chaining.</returns>
        public Guard AgainstNull<TIn>(TIn value)
        {
            if (Continue && value is null)
                Result = ErrorResult.Create(ErrorUtils.InvalidParameter(CultureName, field: null));

            return this;
        }
    }

    /// <summary>
    /// Provides a mechanism for validating input values and generating error results when validation fails.
    /// </summary>
    /// <remarks>
    /// The <see cref="Guard{T}"/> class is designed to facilitate input validation in a fluent
    /// manner. It allows chaining multiple validation methods, such as <see cref="AgainstNullOrWhiteSpace(string,
    /// string?)"/> and <see cref="AgainstNull{TIn}(TIn)"/>, while maintaining a result that indicates whether
    /// validation succeeded. If validation fails, the <see cref="Result"/> property is updated with an error
    /// result.
    /// </remarks>
    /// <typeparam name="T">The type associated with the validation result.</typeparam>
    public class Guard<T> : Guard
    {
        private Guard(IResult<T> result, string cultureName) : base(result, cultureName)
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

        /// <summary>
        /// Ensures that the specified value is not null or white space.
        /// </summary>
        /// <remarks>
        /// If the <see cref="Guard.Continue"/> property is <see langword="true"/> and the
        /// provided value is null or white space, the <see cref="Result"/> property is updated with an error result
        /// indicating an invalid parameter.
        /// </remarks>
        /// <param name="value">The value to validate.</param>
        /// <param name="paramName">The name of <paramref name="value"/> captured by expression or manually.</param>
        /// <returns>The current <see cref="Guard{T}"/> instance, allowing for method chaining.</returns>
        new public Guard<T> AgainstNullOrWhiteSpace(string value, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && string.IsNullOrWhiteSpace(value))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        /// <summary>
        /// Ensures that the specified value is not null.
        /// </summary>
        /// <remarks>
        /// If the <see cref="Guard.Continue"/> property is <see langword="true"/> and the
        /// provided value is null, the <see cref="Result"/> property is updated with an error result
        /// indicating an invalid parameter.
        /// </remarks>
        /// <typeparam name="TIn">The type of the value being checked.</typeparam>
        /// <param name="value">The value to validate.</param>
        /// <returns>The current <see cref="Guard{T}"/> instance, allowing for method chaining.</returns>
        new public Guard<T> AgainstNull<TIn>(TIn value)
        {
            if (Continue && value is null)
                Result = ErrorResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, field: null));

            return this;
        }        
    }
}
