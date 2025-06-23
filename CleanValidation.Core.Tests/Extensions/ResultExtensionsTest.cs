using CleanValidation.Core.Extensions;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Extensions
{
    public class ResultExtensionsTest
    {
        [Fact]
        public void Test1()
        {
            var result = ErrorResult<bool>.Create(error: new("User Error", field: null));

            var map = result.ErrorsTo<User>();

            Assert.NotNull(map);
            Assert.IsType<ErrorResult<User>>(map);
        }

        [Fact]
        public void Test2()
        {
            var result = ErrorResult<bool>.Create(error: new("User Error", field: null));

            var mapResult = result.ErrorsTo<User>();

            var mapResultError = mapResult as ErrorResult<User>;

            Assert.NotNull(mapResultError);
            Assert.NotEmpty(mapResultError.Errors);            
        }

        [Fact]
        public void Test3()
        {
            var result = ErrorResult.Create(error: new("User Error", field: null));

            var map = result.ErrorsTo<User>();

            Assert.NotNull(map);
            Assert.IsType<ErrorResult<User>>(map);
        }

        [Fact]
        public void Test4()
        {
            var result = ErrorResult.Create(error: new("User Error", field: null));

            var mapResult = result.ErrorsTo<User>();

            var mapResultError = mapResult as ErrorResult<User>;

            Assert.NotNull(mapResultError);
            Assert.NotEmpty(mapResultError.Errors);
        }
    }
}
