using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Guards
{
    public class Guard_EqualityTest
    {
        [Fact]
        public void AgainstNull_NullObject_ReturnsInvalidResult()
        {
            string? value = null;

            Guard guard = Guard.Create().AgainstNull(value);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<ErrorResult>(result);
        }

        [Fact]
        public void AgainstNull_NotNullObject_ReturnsSuccessResult()
        {
            string value = "Hello World";

            Guard guard = Guard.Create().AgainstNull(value);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }
       
        [Fact]
        public void AgainstEqual_Equals_ReturnsInvalidResult()
        {
            int value1 = 10;
            int value2 = 10;

            Guard guard = Guard.Create().AgainstEqual(value1, value2);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstEqual_NotEquals_ReturnsSuccessResult()
        {
            string? name1 = null;
            string name2 = "Lívia";

            Guard guard = Guard.Create().AgainstEqual(name1, name2);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }       

        [Fact]
        public void AgainstEqual_NullObjects_ReturnsInvalidResult()
        {
            string? value1 = null;
            string? value2 = null;

            Guard guard = Guard.Create().AgainstEqual(value1, value2);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstNotEqual_NotEquals_ReturnsInvalidResult()
        {
            int? value1 = null;
            int value2 = 10;

            Guard guard = Guard.Create().AgainstNotEqual(value1, value2);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstNotEqual_Equals_ReturnsSuccessResult()
        {
            string name1 = "Lívia";
            string name2 = "Lívia";

            Guard guard = Guard.Create().AgainstNotEqual(name1, name2);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstNotEqual_NullObjects_ReturnsSuccessResult()
        {
            string? value1 = null;
            string? value2 = null;

            Guard guard = Guard.Create().AgainstNotEqual(value1, value2);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstDefault_Default_ReturnsInvalidResult()
        {
            DateTime dateTime = default;

            Guard guard = Guard.Create().AgainstDefault(dateTime);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstDefault_NonDefault_ReturnsSuccessResult()
        {
            DateTime dateTime = DateTime.UtcNow;

            Guard guard = Guard.Create().AgainstDefault(dateTime);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstEmpty_EmptyString_ReturnsInvalidResult()
        {
            string value = "";

            Guard guard = Guard.Create().AgainstEmpty(value);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstEmpty_NotEmptyString_ReturnsSuccessResult()
        {
            string value = "Hi";

            Guard guard = Guard.Create().AgainstEmpty(value);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstEmpty_EmptyList_ReturnsInvalidResult()
        {
            List<string> values = [];

            Guard guard = Guard.Create().AgainstEmpty(values);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstEmpty_NotEmptyList_ReturnsSuccessResult()
        {
            List<string> values = ["Hi", "I'am", "Eduardo", "."];

            Guard guard = Guard.Create().AgainstEmpty(values);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstWhiteSpace_WhiteSpace_ReturnsInvalidResult()
        {
            string value = "    ";

            Guard guard = Guard.Create().AgainstWhiteSpace(value);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstWhiteSpace_NotWhiteSpace_ReturnsSuccessResult()
        {
            string value = "Hi - ";

            Guard guard = Guard.Create().AgainstWhiteSpace(value);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstIn_ValueIn_ReturnsInvalidResult()
        {
            string[] values = ["Hi", "Hey", "What's up", "Yo"];

            Guard guard = Guard.Create().AgainstIn("Hey", values);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstIn_ValueNotIn_ReturnsSuccessResult()
        {
            string[] values = ["Hi", "Hey", "What's up", "Yo"];

            Guard guard = Guard.Create().AgainstIn("Hello", values);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstNotIn_ValueNotIn_ReturnsInvalidResult()
        {
            string[] values = ["Hi", "Hey", "What's up", "Yo"];

            Guard guard = Guard.Create().AgainstNotIn("Hello", values);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstNotIn_ValueIn_ReturnsSuccessResult()
        {
            string[] values = ["Hi", "Hey", "What's up", "Yo"];

            Guard guard = Guard.Create().AgainstNotIn("Hey", values);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstOutOfRange_ValueOutOfRange_ReturnsInvalidResult()
        {
            int value = 5;

            Guard guard = Guard.Create().AgainstOutOfRange(value, 10, 20);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstOutOfRange_ValueInRange_ReturnsSuccessResult()
        {
            int value = 15;

            Guard guard = Guard.Create().AgainstOutOfRange(value, 10, 20);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstOutOfRange_DateOutOfRange_ReturnsInvalidResult()
        {
            DateOnly date = new(2077, 01, 01);

            Guard guard = Guard.Create().AgainstOutOfRange(
                date, 
                new DateOnly(1999, 01, 01),
                new DateOnly(2025, 01, 01));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstOutOfRange_DateInRange_ReturnsSuccessResult()
        {
            DateOnly date = new(2025, 07, 08);

            Guard guard = Guard.Create().AgainstOutOfRange(
                date,
                new DateOnly(1999, 01, 01),
                new DateOnly(2099, 01, 01));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstOutOfRange_TimeOutOfRange_ReturnsInvalidResult()
        {
            TimeOnly time = new(10, 30);

            Guard guard = Guard.Create().AgainstOutOfRange(
                time,
                new TimeOnly(12, 45),
                new TimeOnly(22, 00));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstOutOfRange_TimeInRange_ReturnsSuccessResult()
        {
            TimeOnly time = new(12, 00);

            Guard guard = Guard.Create().AgainstOutOfRange(
                time,
                new TimeOnly(12, 00),
                new TimeOnly(23, 59));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstOutOfRange_DateTimeOutOfRange_ReturnsInvalidResult()
        {
            DateTime dateTime = new(2077, 07, 08, 10, 30, 00);

            Guard guard = Guard.Create().AgainstOutOfRange(
                dateTime,
                new DateTime(1999, 01, 01, 12, 45, 00),
                new DateTime(2025, 01, 01, 22, 00, 00));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstOutOfRange_DateTimeInRange_ReturnsSuccessResult()
        {
            DateTime dateTime = new(2025, 07, 08, 12, 00, 00);

            Guard guard = Guard.Create().AgainstOutOfRange(
                dateTime,
                new DateTime(2025, 07, 08, 12, 00, 00),
                new DateTime(2025, 07, 08, 23, 59, 59));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }
    }
}
