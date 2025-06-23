using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Results
{
    public class ResultTest
    {
        [Fact]
        public void SuccessResult_ReturnsSuccess()
        {
            var result = SuccessResult.Create();

            Assert.True(result.Success);
        }

        [Fact]
        public void ErrorResult_ReturnsFalseSuccess()
        {
            var errorMessage = "Error Message";
            var result = ErrorResult.Create(new Error(errorMessage, field: null));

            Assert.False(result.Success);
            Assert.Equal(errorMessage, result.Errors.First().Message);
        }
    }
}