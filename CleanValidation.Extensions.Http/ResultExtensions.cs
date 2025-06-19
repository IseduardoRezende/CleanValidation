using CleanValidation.Core.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanValidation.Extensions.Http
{    
    public static class ResultExtensions
    {       
        public static IActionResult ToActionResult<T>(this Result<T> result)
        {
            return result switch
            {
                SuccessResult<T>  => new OkObjectResult(result),
                ConflictResult<T> => new ConflictObjectResult(result),
                NotFoundResult<T> => new NotFoundObjectResult(result),
                ErrorResult<T>    => new BadRequestObjectResult(result),
                ProblemResult<T>  => new ObjectResult(result) 
                { 
                    StatusCode = StatusCodes.Status500InternalServerError
                },
                InvalidResult<T>  => new UnprocessableEntityObjectResult(result),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
            };
        }              
    }
}
