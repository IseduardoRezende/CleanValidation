using CleanValidation.Core.Guards;
using CleanValidation.Core.Options;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Guards
{
    public class Guard_SecurityTest
    {
        [Fact]
        public void AgainstWeakPassword_WeakPassword_ReturnsInvalidResult()
        {
            string password = "abc@123";

            Guard guard = Guard.Create().AgainstWeakPassword(password, PasswordOptions.Default);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstWeakPassword_ValidPassword_ReturnsSuccessResult()
        {
            string password = "Edu@132Z&";

            Guard guard = Guard.Create().AgainstWeakPassword(password, PasswordOptions.Default);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstInvalidEmailAddress_InvalidEmailAddress_ReturnsInvalidResult()
        {
            string emailAddress = "@test.yoo0711@gmail.com";

            Guard guard = Guard.Create().AgainstInvalidEmailAddress(emailAddress);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstInvalidEmailAddress_ValidEmailAddress_ReturnsSuccessResult()
        {
            string emailAddress = "test.yoo0711@gmail.com";

            Guard guard = Guard.Create().AgainstInvalidEmailAddress(emailAddress);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstInvalidPhone_InvalidPhone_ReturnsInvalidResult()
        {
            string phone = "+1-abc-123-4567";

            Guard guard = Guard.Create().AgainstInvalidPhone(phone);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstInvalidPhone_ValidPhone_ReturnsSuccessResult()
        {
            string phone = "+1-415-555-0132";

            Guard guard = Guard.Create().AgainstInvalidPhone(phone);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }
    }
}
