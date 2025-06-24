using CleanValidation.Core.Results;

namespace CleanValidation.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for working with <see cref="IResult"/> instances.
    /// </summary>
    /// <remarks>This class includes methods for transforming or mapping objects, such
    /// as converting errors from one result type to another. These methods are designed to simplify handling and
    /// propagating errors across different result types.</remarks>
    public static class ResultExtensions
    {
        /// <summary>
        /// Maps the errors from a <see cref="IResult"/> instance to a new <see cref="IResult{T}"/> type.
        /// </summary>
        /// <typeparam name="T">The type of the destination result.</typeparam>
        /// <param name="result">The original result containing errors to be mapped.</param>
        /// <returns>A new <see cref="IResult{T}"/> instance containing the mapped errors. The specific type of the
        /// result (e.g., <see cref="ConflictResult{T}"/>, <see cref="NotFoundResult{T}"/>, etc.)
        /// corresponds to the type of the original result.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="result"/> is not a recognized result type.</exception>
        public static IResult<T> ErrorsTo<T>(this IResult result)
        {
            return result switch
            {
                ConflictResult conflict => ConflictResult<T>.Create(conflict.Errors),
                NotFoundResult notFound => NotFoundResult<T>.Create(notFound.Errors),
                ErrorResult error => ErrorResult<T>.Create(error.Errors),
                ProblemResult problem => ProblemResult<T>.Create(problem.Errors),
                InvalidResult invalid => InvalidResult<T>.Create(invalid.Errors),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
