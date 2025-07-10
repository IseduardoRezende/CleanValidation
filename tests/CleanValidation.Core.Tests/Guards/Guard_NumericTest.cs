using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Guards
{
    public class Guard_NumericTest
    {
        [Fact]
        public void AgainstLessThan_ValueLessThan_ReturnsInvalidResult()
        {
            const double min = 5.5;
            double value = 4.7;

            Guard guard = Guard.Create().AgainstLessThan(value, min);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstLessThan_ValueGreaterThan_ReturnsSuccessResult()
        {
            const double min = 5.5;
            double value = 10;

            Guard guard = Guard.Create().AgainstLessThan(value, min);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstGreaterThan_ValueGreaterThan_ReturnsInvalidResult()
        {
            const double max = 5.5;
            double value = 7;

            Guard guard = Guard.Create().AgainstGreaterThan(value, max);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstGreaterThan_ValueLessThan_ReturnsSuccessResult()
        {
            const double max = 5.5;
            double value = 2.5;
            
            Guard guard = Guard.Create().AgainstGreaterThan(value, max);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }        
    }
}
