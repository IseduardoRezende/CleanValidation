using CleanValidation.Core.Results;

namespace CleanValidation.Core.Extensions
{
    public static class ResultExtensions
    {
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
