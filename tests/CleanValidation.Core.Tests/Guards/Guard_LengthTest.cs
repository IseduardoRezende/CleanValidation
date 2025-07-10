using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Guards
{
    public class Guard_LengthTest
    {
        [Fact]
        public void AgainstMinLength_ValueShorterThanMinLength_ReturnsInvalidResult()
        {
            const int minLength = 5;

            Guard guard = Guard.Create().AgainstMinLength("Hey", minLength);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstMinLength_ValueLongerThanMinLength_ReturnsSuccessResult()
        {
            const int minLength = 3;

            Guard guard = Guard.Create().AgainstMinLength("Hello World", minLength);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstMaxLength_ValueLongerThanMaxLength_ReturnsInvalidResult()
        {
            const int maxLength = 10;

            Guard guard = Guard.Create().AgainstMaxLength("Hello World", maxLength);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstMaxLength_ValueShorterThanMaxLength_ReturnsSuccessResult()
        {
            const int maxLength = 10;

            Guard guard = Guard.Create().AgainstMaxLength("Hey!", maxLength);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstNotExactLength_NotExactLength_ReturnsInvalidResult()
        {
            const int length = 10;

            Guard guard = Guard.Create().AgainstNotExactLength("Hello World!", length);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstNotExactLength_ExactLength_ReturnsSuccessResult()
        {
            const int length = 3;

            Guard guard = Guard.Create().AgainstNotExactLength("Hey", length);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }        
    }
}
