using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Guards
{
    public class GuardTest
    {
        [Fact]
        public void AgainstNull_NullUser_ReturnsInvalidResultType()
        {
            User? user = null;
            Guard guard = Guard.Create();

            IResult result = guard.AgainstNull(user).GetResult();
        
            Assert.NotNull(result);
            Assert.IsType<ErrorResult>(result);
        }

        [Fact]
        public void AgainstNull_ValidUser_ReturnsSuccessResultType() 
        {
            var user = new User("Parker", 77, "Gentleman");

            IResult result = Guard.Create().AgainstNull(user).GetResult();

            Assert.NotNull(result);
            Assert.IsType<SuccessResult>(result);
        }
    }
}
