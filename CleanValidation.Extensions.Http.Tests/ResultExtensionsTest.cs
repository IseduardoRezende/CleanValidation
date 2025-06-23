using CleanValidation.Core.Results;
using Microsoft.AspNetCore.Mvc;

namespace CleanValidation.Extensions.Http.Tests
{
    public class ResultExtensionsTest
    {
        [Fact]
        public void ToActionResult_SucessResult_ReturnsOkObjectResult()
        {
            User user = new("Lívia", 21, "Lady");
            IResult<User> result = SuccessResult<User>.Create(user);

            IActionResult actionResult = result.ToActionResult();

            Assert.NotNull(actionResult);
            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public void ToActionResult_SucessResultType_ReturnsOkObjectResult()
        {
            User user = new("Eduardo", 19, "Gentleman");
            IResult<User> result = SuccessResult<User>.Create(user);

            IActionResult actionResult = result.ToActionResult();

            OkObjectResult okObject = (actionResult as OkObjectResult)!;

            Assert.NotNull(okObject);
            Assert.NotNull(okObject.Value);
        }
    }
}
