using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Guards
{
    public class Guard_CustomTest
    {
        [Fact]
        public void AgainstTrue_NullCondition_ReturnsInvalidResult()
        {
            bool? condition = null;
            
            Guard guard = Guard.Create().AgainstTrue(condition);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstTrue_NullCondition_ReturnsInvalidResultType()
        {
            bool? condition = null;

            Guard<bool> guard = Guard<bool>.Create().AgainstTrue(condition);

            IResult<bool> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<bool>>(result);
        }

        [Fact]
        public void AgainstTrue_TrueCondition_ReturnsInvalidResult()
        {
            Guard guard = Guard.Create().AgainstTrue(10 % 2 == 0);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstTrue_FalseCondition_ReturnsSuccessResult()
        {
            Guard guard = Guard.Create().AgainstTrue(10 % 2 != 0);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstTrue_TrueLambda_ReturnsInvalidResult()
        {
            int number = 15;
            Guard guard = Guard.Create().AgainstTrue(number, n => n % 2 != 0);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstTrue_FalseLambda_ReturnsSuccessResult()
        {
            int number = 15;
            Guard guard = Guard.Create().AgainstTrue(number, n => n % 2 == 0);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public async Task AgainstTrueAsync_TrueLambda_ReturnsInvalidResult()
        {
            string value = "Hello World";
            
            Guard guard = await Guard.Create()
                .AgainstTrueAsync(value, async v => await Task.FromResult(v.Contains("World")));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public async Task AgainstTrueAsync_FalseLambda_ReturnsSuccessResult()
        {
            string value = "Hello World";

            Guard guard = await Guard.Create()
                .AgainstTrueAsync(value, async v => await Task.FromResult(v.Contains("Hey")));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstTrue_TrueCondition_ReturnsInvalidResultType()
        {
            Guard<int> guard = Guard<int>.Create().AgainstTrue(10 % 2 == 0);

            IResult<int> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<int>>(result);
        }

        [Fact]
        public void AgainstTrue_FalseCondition_ReturnsSuccessResultType()
        {
            Guard<int> guard = Guard<int>.Create().AgainstTrue(10 % 2 != 0);

            IResult<int> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<int>>(result);
        }

        [Fact]
        public void AgainstTrue_TrueLambda_ReturnsInvalidResultType()
        {
            int number = 15;
            Guard<int> guard = Guard<int>.Create().AgainstTrue(number, n => n % 2 != 0);

            IResult<int> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<int>>(result);
        }

        [Fact]
        public void AgainstTrue_FalseLambda_ReturnsSuccessResultType()
        {
            int number = 15;
            Guard<int> guard = Guard<int>.Create().AgainstTrue(number, n => n % 2 == 0);

            IResult<int> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<int>>(result);
        }

        [Fact]
        public async Task AgainstTrueAsync_TrueLambda_ReturnsInvalidResultType()
        {
            string value = "Hello World";
            
            Guard<string> guard = await Guard<string>.Create()
                .AgainstTrueAsync(value, async v => await Task.FromResult(v.Contains("World")));

            IResult<string> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<string>>(result);
        }

        [Fact]
        public async Task AgainstTrueAsync_FalseLambda_ReturnsSuccessResultType()
        {
            string value = "Hello World";

            Guard<string> guard = await Guard<string>.Create()
                .AgainstTrueAsync(value, async v => await Task.FromResult(v.Contains("Foo")));

            IResult<string> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<string>>(result);
        }

        [Fact]
        public void AgainstFalse_NullCondition_ReturnsInvalidResult()
        {
            bool? condition = null;

            Guard guard = Guard.Create().AgainstFalse(condition);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstFalse_NullCondition_ReturnsInvalidResultType()
        {
            bool? condition = null;

            Guard<bool> guard = Guard<bool>.Create().AgainstFalse(condition);

            IResult<bool> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<bool>>(result);
        }

        [Fact]
        public void AgainstFalse_FalseCondition_ReturnsInvalidResult()
        {
            Guard guard = Guard.Create().AgainstFalse(10 % 2 != 0);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstFalse_TrueCondition_ReturnsSuccessResult()
        {
            Guard guard = Guard.Create().AgainstFalse(10 % 2 == 0);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstFalse_FalseLambda_ReturnsInvalidResult()
        {
            int number = 15;
            Guard guard = Guard.Create().AgainstFalse(number, n => n % 2 == 0);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstFalse_TrueLambda_ReturnsSuccessResult()
        {
            int number = 15;
            Guard guard = Guard.Create().AgainstFalse(number, n => n % 2 != 0);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public async Task AgainstFalseAsync_FalseLambda_ReturnsInvalidResult()
        {
            string value = "Hello World";

            Guard guard = await Guard.Create()
                .AgainstFalseAsync(value, async v => await Task.FromResult(v.Contains("Hi")));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public async Task AgainstFalseAsync_TrueLambda_ReturnsSuccessResult()
        {
            string value = "Hello World";

            Guard guard = await Guard.Create()
                .AgainstFalseAsync(value, async v => await Task.FromResult(v.Contains("Hello")));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstFalse_FalseCondition_ReturnsInvalidResultType()
        {
            Guard<int> guard = Guard<int>.Create().AgainstFalse(10 % 2 != 0);

            IResult<int> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<int>>(result);
        }

        [Fact]
        public void AgainstFalse_TrueCondition_ReturnsSuccessResultType()
        {
            Guard<int> guard = Guard<int>.Create().AgainstFalse(10 % 2 == 0);

            IResult<int> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<int>>(result);
        }

        [Fact]
        public void AgainstFalse_FalseLambda_ReturnsInvalidResultType()
        {
            int number = 15;
            Guard<int> guard = Guard<int>.Create().AgainstFalse(number, n => n % 2 == 0);

            IResult<int> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<int>>(result);
        }

        [Fact]
        public void AgainstFalse_TrueLambda_ReturnsSuccessResultType()
        {
            int number = 15;
            Guard<int> guard = Guard<int>.Create().AgainstFalse(number, n => n % 2 != 0);

            IResult<int> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<int>>(result);
        }

        [Fact]
        public async Task AgainstFalseAsync_FalseLambda_ReturnsInvalidResultType()
        {
            string value = "Hello World";

            Guard<string> guard = await Guard<string>.Create()
                .AgainstFalseAsync(value, async v => await Task.FromResult(v.Contains("Hey")));

            IResult<string> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<string>>(result);
        }

        [Fact]
        public async Task AgainstFalseAsync_TrueLambda_ReturnsSuccessResultType()
        {
            string value = "Hello World";

            Guard<string> guard = await Guard<string>.Create()
                .AgainstFalseAsync(value, async v => await Task.FromResult(v.Contains("World")));

            IResult<string> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<string>>(result);
        }
    }
}
