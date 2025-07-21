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
            var user = new User(1, "User1", 20);

            var result = await _userValidator.ValidateAsync(user);

            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public async Task ValidateAsync_InvalidUserName_ReturnsInvalidResult()
        {
            var user = new User(1, "", 40);

            var result = await _userValidator.ValidateAsync(user);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public async Task ValidateAsync_NullUser_ReturnsInvalidResult()
        {
            User? user = null;

            var result = await _userValidator.ValidateAsync(user);

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.IsType<InvalidResult>(result);
        }
    }
}
