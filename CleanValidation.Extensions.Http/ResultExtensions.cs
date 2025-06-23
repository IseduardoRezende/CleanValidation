using CleanValidation.Core.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConflictResult = CleanValidation.Core.Results.ConflictResult;
using NotFoundResult = CleanValidation.Core.Results.NotFoundResult;

namespace CleanValidation.Extensions.Http
{    
    /// <summary>
    /// Provides extension methods for converting application-specific result types into HTTP responses.
    /// </summary>
    /// <remarks>This class contains methods that standardize the mapping of <see cref="IResult"/> instances
    /// to  <see cref="IActionResult"/> objects, enabling consistent handling of various result types in web
    /// applications.</remarks>
    public static class ResultExtensions
    {
        /// <summary>
        /// Converts a <see cref="IResult"/> instance into an appropriate <see cref="IActionResult"/>  based on the
        /// result type.
        /// </summary>
        /// <remarks>This method provides a standardized way to map application-specific result types to
        /// HTTP responses. It ensures that the appropriate status code and response body are returned based on the
        /// result type.</remarks>
        /// <param name="result">The <see cref="IResult"/> instance to convert. Cannot be null.</param>
        /// <returns>An <see cref="IActionResult"/> that corresponds to the type of the <paramref name="result"/>: <list
        /// type="bullet"> <item><description><see cref="SuccessResult"/> is converted to <see
        /// cref="OkObjectResult"/>.</description></item> <item><description><see cref="ConflictResult"/> is
        /// converted to <see cref="ConflictObjectResult"/>.</description></item> <item><description><see
        /// cref="NotFoundResult"/> is converted to <see cref="NotFoundObjectResult"/>.</description></item>
        /// <item><description><see cref="ErrorResult"/> is converted to <see
        /// cref="BadRequestObjectResult"/>.</description></item> <item><description><see cref="ProblemResult"/> is
        /// converted to <see cref="ObjectResult"/> with a status code of 500.</description></item>
        /// <item><description><see cref="InvalidResult"/> is converted to <see
        /// cref="UnprocessableEntityObjectResult"/>.</description></item> <item><description>Any other result type is
        /// converted to <see cref="StatusCodeResult"/> with a status code of 500.</description></item> </list></returns>
        public static IActionResult ToActionResult(this IResult result)
        {
            return result switch
            {
                SuccessResult => new OkObjectResult(result),
                ConflictResult => new ConflictObjectResult(result),
                NotFoundResult => new NotFoundObjectResult(result),
                ErrorResult => new BadRequestObjectResult(result),
                ProblemResult => new ObjectResult(result)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                },
                InvalidResult => new UnprocessableEntityObjectResult(result),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
            };
        }
    }
}
