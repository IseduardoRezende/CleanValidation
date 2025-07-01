using CleanValidation.Core.Exceptions;
using CleanValidation.Core.GuardThrows;

namespace CleanValidation.Core.Tests.Guards
{
    public class GuardThrowTest
    {
        [Fact]
        public void AgainstNull_NullUser_ThrowsCleanValidationException()
        {
            User? user = null;
                        
            Assert.Throws<CleanValidationException>(() =>
            {
                GuardThrow guardThrow = GuardThrow.Create()
                .AgainstNull(user);
            });
        }

        [Fact]
        public void AgainstNull_ValidUser_ThrowsNothing()
        {
            var user = new User("Parker", 77, "Gentleman");

            GuardThrow guardThrow = GuardThrow.Create()
                .AgainstNull(user)
                .AgainstWhiteSpace(user.Name);

            Assert.NotNull(guardThrow);            
        }
    }
}
