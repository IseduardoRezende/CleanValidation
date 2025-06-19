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
        public async Task Test1()
        {
            var user = new User("User1", 20, "First User!");

            var result = await _userValidator.ValidateAsync(user);

            Assert.NotNull(result);
            Assert.True(result.Sucess);
            Assert.IsType<SuccessResult<User>>(result);
        }

        [Fact]
        public async Task Test2()
        {
            var user = new User("", 40, "Empty User Name ?");

            var result = await _userValidator.ValidateAsync(user);

            Assert.NotNull(result);
            Assert.False(result.Sucess);
            Assert.IsType<InvalidResult<User>>(result);
        }

        [Fact]
        public async Task Test3()
        {
            User? user = null;

            var result = await _userValidator.ValidateAsync(user!);

            Assert.NotNull(result);
            Assert.False(result.Sucess);
            Assert.IsType<ErrorResult<User>>(result);
        }
    }
}
