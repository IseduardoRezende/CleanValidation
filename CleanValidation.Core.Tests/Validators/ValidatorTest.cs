using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Validators
{
    public class ValidatorTest
    {
        private readonly UserValidator _userValidator;

        public ValidatorTest()
        {
            _userValidator = new UserValidator();
        }

        [Fact]
        public async Task ValidateAsync_ValidUser_ReturnsSuccessResult()
        {
            var user = new User("User1", 20, "First User!");

            var result = await _userValidator.ValidateAsync(user);

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public async Task ValidateAsync_InvalidUserName_ReturnsInvalidResult()
        {
            var user = new User("", 40, "Empty User Name ?");

            var result = await _userValidator.ValidateAsync(user);

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public async Task ValidateAsync_NullUser_ReturnsErrorResult()
        {
            User? user = null;

            var result = await _userValidator.ValidateAsync(user!);

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<ErrorResult>(result);
        }
    }
}
