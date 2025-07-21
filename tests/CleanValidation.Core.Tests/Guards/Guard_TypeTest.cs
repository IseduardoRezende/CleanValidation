using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Guards
{
    public class Guard_TypeTest
    {
        [Fact]
        public void AgainstNotAssignableTo_NotAssignable_ReturnsInvalidResult()
        {
            User user = new(1, "Eduardo", 19);

            Guard guard = Guard.Create().AgainstNotAssignableTo<Post>(user);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstNotAssignableTo_Assignable_ReturnsSuccessResult()
        {
            User user = new(1, "Eduardo", 19);

            Guard guard = Guard.Create().AgainstNotAssignableTo<Base>(user);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstAssignableTo_Assignable_ReturnsInvalidResult()
        {
            User user = new(1, "Eduardo", 19);

            Guard guard = Guard.Create().AgainstAssignableTo<Base>(user);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstAssignableTo_NotAssignable_ReturnsSuccessResult()
        {
            User user = new(1, "Eduardo", 19);

            Guard guard = Guard.Create().AgainstAssignableTo<Post>(user);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstNotAssignableFrom_NotAssignable_ReturnsInvalidResult()
        {
            User user = new(1, "Eduardo", 19);

            Guard guard = Guard.Create().AgainstNotAssignableFrom<Post>(user);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstNotAssignableFrom_Assignable_ReturnsSuccessResult()
        {
            object obj = new();

            Guard guard = Guard.Create().AgainstNotAssignableFrom<User>(obj);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstAssignableFrom_Assignable_ReturnsInvalidResult()
        {
            object obj = new();

            Guard guard = Guard.Create().AgainstAssignableFrom<User>(obj);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstAssignableFrom_NotAssignable_ReturnsSuccessResult()
        {
            User user = new(1, "Eduardo", 19);

            Guard guard = Guard.Create().AgainstAssignableFrom<Post>(user);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstNotTypeOf_NotTypeOf_ReturnsInvalidResult()
        {
            User user = new(1, "Eduardo", 19);

            Guard guard = Guard.Create().AgainstNotTypeOf<Base>(user);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstNotTypeOf_TypeOf_ReturnsSuccessResult()
        {
            User user = new(1, "Eduardo", 19);

            Guard guard = Guard.Create().AgainstNotTypeOf<User>(user);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstTypeOf_TypeOf_ReturnsInvalidResult()
        {
            User user = new(1, "Eduardo", 19);

            Guard guard = Guard.Create().AgainstTypeOf<User>(user);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstTypeOf_NotTypeOf_ReturnsSuccessResult()
        {
            User user = new(1, "Eduardo", 19);

            Guard guard = Guard.Create().AgainstTypeOf<Base>(user);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstInvalidEnum_InvalidEnum_ReturnsInvalidResult()
        {
            Guard guard = Guard.Create().AgainstInvalidEnum<PostType>(value: -1);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstInvalidEnum_ValidEnum_ReturnsSuccessResult()
        {
            Guard guard = Guard.Create().AgainstInvalidEnum<PostType>(value: 0);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.IsValid);
            Assert.IsType<SuccessResult>(result);
        }
    }
}
