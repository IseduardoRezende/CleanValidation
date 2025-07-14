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
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstNull_ValidUser_ReturnsSuccessResultType() 
        {
            var user = new User(1, "Parker", 77);

            IResult result = Guard.Create().AgainstNull(user).GetResult();

            Assert.NotNull(result);
            Assert.IsType<SuccessResult>(result);
        }
    }
}
