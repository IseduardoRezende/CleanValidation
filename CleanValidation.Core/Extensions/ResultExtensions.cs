using CleanValidation.Core.Results;

namespace CleanValidation.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for working with <see cref="Result"/> and <see cref="Result{T}"/> instances.
    /// </summary>
    /// <remarks>This class includes methods for transforming or mapping objects, such
    /// as converting errors from one result type to another. These methods are designed to simplify handling and
    /// propagating errors across different result types.</remarks>
    public static class ResultExtensions
    {
        /// <summary>
        /// Maps the errors from a <see cref="Result"/> instance to a new <see cref="Result{TDestination}"/> type.
        /// </summary>
        /// <typeparam name="T">The type of the destination result.</typeparam>
        /// <param name="result">The original result containing errors to be mapped.</param>
        /// <returns>A new <see cref="Result{TDestination}"/> instance containing the mapped errors. The specific type of the
        /// result (e.g., <see cref="ConflictResult{TDestination}"/>,  <see cref="NotFoundResult{TDestination}"/>, etc.)
        /// corresponds to the type of the original result.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="result"/> is not a recognized result type.</exception>
        public static Result<T> ErrorsTo<T>(this Result result)
        {
            return result switch
            {
                ConflictResult conflict => ConflictResult<T>.Create(conflict.Errors),
                NotFoundResult notFound => NotFoundResult<T>.Create(notFound.Errors),
                ErrorResult error       => ErrorResult<T>.Create(error.Errors),
                ProblemResult problem   => ProblemResult<T>.Create(problem.Errors),
                InvalidResult invalid   => InvalidResult<T>.Create(invalid.Errors),
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// Maps the errors from a <see cref="Result{T}"/> instance to a new <see cref="Result{TDestination}"/> type.
        /// </summary>
        /// <typeparam name="T">The type of the original result.</typeparam>
        /// <typeparam name="TDestination">The type of the destination result.</typeparam>
        /// <param name="result">The original result containing errors to be mapped.</param>
        /// <returns>A new <see cref="Result{TDestination}"/> instance containing the mapped errors. The specific type of the
        /// result (e.g., <see cref="ConflictResult{TDestination}"/>,  <see cref="NotFoundResult{TDestination}"/>, etc.)
        /// corresponds to the type of the original result.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="result"/> is not a recognized result type.</exception>
        public static Result<TDestination> ErrorsTo<T, TDestination>(this Result<T> result)
        {            
            return result switch
            {
                ConflictResult<T> conflict => ConflictResult<TDestination>.Create(conflict.Errors),
                NotFoundResult<T> notFound => NotFoundResult<TDestination>.Create(notFound.Errors),
                ErrorResult<T> error       => ErrorResult<TDestination>.Create(error.Errors),
                ProblemResult<T> problem   => ProblemResult<TDestination>.Create(problem.Errors),
                InvalidResult<T> invalid   => InvalidResult<TDestination>.Create(invalid.Errors),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
