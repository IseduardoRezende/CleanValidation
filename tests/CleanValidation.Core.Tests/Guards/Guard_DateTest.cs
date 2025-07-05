using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;

namespace CleanValidation.Core.Tests.Guards
{
    public class Guard_DateTest
    {
        [Fact]
        public void AgainstDateInPast_NullDate_ReturnsInvalidResult()
        {
            DateOnly? date = null;

            Guard guard = Guard.Create().AgainstDateInPast(date, DateOnly.FromDateTime(DateTime.UtcNow));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstDateInPast_NullDate_ReturnsInvalidResultType()
        {
            DateOnly? date = null;

            Guard<DateOnly> guard = Guard<DateOnly>
                .Create()
                .AgainstDateInPast(date, DateOnly.FromDateTime(DateTime.UtcNow));

            IResult<DateOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<DateOnly>>(result);
        }

        [Fact]
        public void AgainstDateInPast_PastDate_ReturnsInvalidResult()
        {
            DateOnly date = new(1989, 7, 7);    

            Guard guard = Guard.Create().AgainstDateInPast(date, DateOnly.FromDateTime(DateTime.UtcNow));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstDateInPast_FutureDate_ReturnsSuccessResult()
        {
            DateOnly date = new(2099, 7, 7);

            Guard guard = Guard.Create().AgainstDateInPast(date, DateOnly.FromDateTime(DateTime.UtcNow));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstDateInPast_PastDate_ReturnsInvalidResultType()
        {
            DateOnly date = new(1989, 7, 7);

            Guard<DateOnly> guard = Guard<DateOnly>
                .Create()
                .AgainstDateInPast(date, DateOnly.FromDateTime(DateTime.UtcNow));

            IResult<DateOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<DateOnly>>(result);
        }

        [Fact]
        public void AgainstDateInPast_FutureDate_ReturnsSuccessResultType()
        {
            DateOnly date = new(2099, 7, 7);

            Guard<DateOnly> guard = Guard<DateOnly>
                .Create()
                .AgainstDateInPast(date, DateOnly.FromDateTime(DateTime.UtcNow));

            IResult<DateOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<DateOnly>>(result);
        }

        [Fact]
        public void AgainstDateInFuture_NullDate_ReturnsInvalidResult()
        {
            DateOnly? date = null;

            Guard guard = Guard.Create().AgainstDateInFuture(date, DateOnly.FromDateTime(DateTime.UtcNow));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstDateInFuture_NullDate_ReturnsInvalidResultType()
        {
            DateOnly? date = null;

            Guard<DateOnly> guard = Guard<DateOnly>
                .Create()
                .AgainstDateInFuture(date, DateOnly.FromDateTime(DateTime.UtcNow));

            IResult<DateOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<DateOnly>>(result);
        }

        [Fact]
        public void AgainstDateInFuture_FutureDate_ReturnsInvalidResult()
        {
            DateOnly compareDate = new(1989, 7, 7);

            Guard guard = Guard.Create().AgainstDateInFuture(DateOnly.FromDateTime(DateTime.UtcNow), compareDate);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstDateInFuture_PastDate_ReturnsSuccessResult()
        {
            DateOnly compareDate = new(2099, 7, 7);

            Guard guard = Guard.Create().AgainstDateInFuture(DateOnly.FromDateTime(DateTime.UtcNow), compareDate);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstDateInFuture_FutureDate_ReturnsInvalidResultType()
        {
            DateOnly compareDate = new(1989, 7, 7);

            Guard<DateOnly> guard = Guard<DateOnly>
                .Create()
                .AgainstDateInFuture(DateOnly.FromDateTime(DateTime.UtcNow), compareDate);

            IResult<DateOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<DateOnly>>(result);
        }

        [Fact]
        public void AgainstDateInFuture_PastDate_ReturnsSuccessResultType()
        {
            DateOnly compareDate = new(2099, 7, 7);

            Guard<DateOnly> guard = Guard<DateOnly>
                .Create()
                .AgainstDateInFuture(DateOnly.FromDateTime(DateTime.UtcNow), compareDate);

            IResult<DateOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<DateOnly>>(result);
        }

        [Fact]
        public void AgainstTimeInPast_NullTime_ReturnsInvalidResult()
        {
            TimeOnly? time = null;

            Guard guard = Guard.Create().AgainstTimeInPast(time, TimeOnly.FromDateTime(DateTime.UtcNow));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstTimeInPast_NullTime_ReturnsInvalidResultType()
        {
            TimeOnly? time = null;

            Guard<TimeOnly> guard = Guard<TimeOnly>
                .Create()
                .AgainstTimeInPast(time, TimeOnly.FromDateTime(DateTime.UtcNow));

            IResult<TimeOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<TimeOnly>>(result);
        }

        [Fact]
        public void AgainstTimeInPast_PastTime_ReturnsInvalidResult()
        {
            TimeOnly time = new(10, 50, 56);
            TimeOnly compareTime = new(22, 01, 55);

            Guard guard = Guard.Create().AgainstTimeInPast(time, compareTime);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstTimeInPast_FutureTime_ReturnsSuccessResult()
        {
            TimeOnly time = new(22, 01, 55);
            TimeOnly compareTime = new(22, 01, 50);

            Guard guard = Guard.Create().AgainstTimeInPast(time, compareTime);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstTimeInPast_PastTime_ReturnsInvalidResultType()
        {
            TimeOnly time = new(10, 50, 56);
            TimeOnly compareTime = new(22, 01, 55);

            Guard<TimeOnly> guard = Guard<TimeOnly>
                .Create()
                .AgainstTimeInPast(time, compareTime);

            IResult<TimeOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<TimeOnly>>(result);
        }

        [Fact]
        public void AgainstTimeInPast_FutureTime_ReturnsSuccessResultType()
        {
            TimeOnly time = new(22, 01, 55);
            TimeOnly compareTime = new(22, 01, 50);

            Guard<TimeOnly> guard = Guard<TimeOnly>
                .Create()
                .AgainstTimeInPast(time, compareTime);

            IResult<TimeOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<TimeOnly>>(result);
        }

        [Fact]
        public void AgainstTimeInFuture_NullTime_ReturnsInvalidResult()
        {
            TimeOnly? time = null;

            Guard guard = Guard.Create().AgainstTimeInFuture(time, TimeOnly.FromDateTime(DateTime.UtcNow));

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstTimeInFuture_NullTime_ReturnsInvalidResultType()
        {
            TimeOnly? time = null;

            Guard<TimeOnly> guard = Guard<TimeOnly>
                .Create()
                .AgainstTimeInFuture(time, TimeOnly.FromDateTime(DateTime.UtcNow));

            IResult<TimeOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<TimeOnly>>(result);
        }

        [Fact]
        public void AgainstTimeInFuture_FutureTime_ReturnsInvalidResult()
        {
            TimeOnly time = new(23, 59, 59);
            TimeOnly compareTime = new(22, 30, 59);

            Guard guard = Guard.Create().AgainstTimeInFuture(time, compareTime);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstTimeInFuture_PastTime_ReturnsSuccessResult()
        {
            TimeOnly time = new(00, 00, 30);
            TimeOnly compareTime = new(22, 30, 59);

            Guard guard = Guard.Create().AgainstTimeInFuture(time, compareTime);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstTimeInFuture_FutureTime_ReturnsInvalidResultType()
        {
            TimeOnly time = new(23, 59, 59);
            TimeOnly compareTime = new(22, 30, 59);

            Guard<TimeOnly> guard = Guard<TimeOnly>
                .Create()
                .AgainstTimeInFuture(time, compareTime);

            IResult<TimeOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<TimeOnly>>(result);
        }

        [Fact]
        public void AgainstTimeInFuture_PastTime_ReturnsSuccessResultType()
        {
            TimeOnly time = new(00, 00, 30);
            TimeOnly compareTime = new(22, 30, 59);

            Guard<TimeOnly> guard = Guard<TimeOnly>
                .Create()
                .AgainstTimeInFuture(time, compareTime);

            IResult<TimeOnly> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<TimeOnly>>(result);
        }

        [Fact]
        public void AgainstDateTimeInPast_NullDateTime_ReturnsInvalidResult()
        {
            DateTime? dateTime = null;

            Guard guard = Guard.Create().AgainstDateTimeInPast(dateTime, DateTime.UtcNow);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstDateTimeInPast_NullDateTime_ReturnsInvalidResultType()
        {
            DateTime? dateTime = null;

            Guard<DateTime> guard = Guard<DateTime>
                .Create()
                .AgainstDateTimeInPast(dateTime, DateTime.UtcNow);

            IResult<DateTime> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<DateTime>>(result);
        }

        [Fact]
        public void AgainstDateTimeInPast_PastDateTime_ReturnsInvalidResult()
        {
            DateTime dateTime = new(1989, 7, 7, 10, 50, 56);
            DateTime compareDateTime = new(2028, 07, 07, 22, 01, 55);               

            Guard guard = Guard.Create().AgainstDateTimeInPast(dateTime, compareDateTime);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstDateTimeInPast_FutureDateTime_ReturnsSuccessResult()
        {
            DateTime dateTime = new(2025, 7, 7, 10, 50, 56);
            DateTime compareDateTime = new(2025, 07, 07, 03, 00, 57);

            Guard guard = Guard.Create().AgainstDateTimeInPast(dateTime, compareDateTime);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstDateTimeInPast_PastDateTime_ReturnsInvalidResultType()
        {
            DateTime dateTime = new(1989, 7, 7, 10, 50, 56);
            DateTime compareDateTime = new(2028, 07, 07, 22, 01, 55);

            Guard<DateTime> guard = Guard<DateTime>
                .Create()
                .AgainstDateTimeInPast(dateTime, compareDateTime);

            IResult<DateTime> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<DateTime>>(result);
        }

        [Fact]
        public void AgainstDateTimeInPast_FutureDateTime_ReturnsSuccessResultType()
        {
            DateTime dateTime = new(2025, 7, 7, 10, 50, 56);
            DateTime compareDateTime = new(2025, 07, 07, 03, 00, 57);

            Guard<DateTime> guard = Guard<DateTime>
                .Create()
                .AgainstDateTimeInPast(dateTime, compareDateTime);

            IResult<DateTime> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<DateTime>>(result);
        }

        [Fact]
        public void AgainstDateTimeInFuture_NullDateTime_ReturnsInvalidResult()
        {
            DateTime? dateTime = null;

            Guard guard = Guard.Create().AgainstDateTimeInFuture(dateTime, DateTime.UtcNow);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstDateTimeInFuture_NullDateTime_ReturnsInvalidResultType()
        {
            DateTime? dateTime = null;

            Guard<DateTime> guard = Guard<DateTime>
                .Create()
                .AgainstDateTimeInFuture(dateTime, DateTime.UtcNow);

            IResult<DateTime> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<DateTime>>(result);
        }

        [Fact]
        public void AgainstDateTimeInFuture_FutureDateTime_ReturnsInvalidResult()
        {
            DateTime dateTime = new(2090, 01, 01, 23, 59, 59);
            DateTime compareDateTime = new(2027, 01, 01, 22, 30, 59);

            Guard guard = Guard.Create().AgainstDateTimeInFuture(dateTime, compareDateTime);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult>(result);
        }

        [Fact]
        public void AgainstDateTimeInFuture_PastDateTime_ReturnsSuccessResult()
        {
            DateTime dateTime = new(2025, 05, 05, 00, 00, 30);
            DateTime compareDateTime = new(2025, 05, 05, 22, 30, 59);

            Guard guard = Guard.Create().AgainstDateTimeInFuture(dateTime, compareDateTime);

            IResult result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult>(result);
        }

        [Fact]
        public void AgainstDateTimeInFuture_FutureDateTime_ReturnsInvalidResultType()
        {
            DateTime dateTime = new(2090, 01, 01, 23, 59, 59);
            DateTime compareDateTime = new(2027, 01, 01, 22, 30, 59);

            Guard<DateTime> guard = Guard<DateTime>
                .Create()
                .AgainstDateTimeInFuture(dateTime, compareDateTime);

            IResult<DateTime> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.IsType<InvalidResult<DateTime>>(result);
        }

        [Fact]
        public void AgainstDateTimeInFuture_PastDateTime_ReturnsSuccessResultType()
        {
            DateTime dateTime = new(2025, 05, 05, 00, 00, 30);
            DateTime compareDateTime = new(2025, 05, 05, 22, 30, 59);

            Guard<DateTime> guard = Guard<DateTime>
                .Create()
                .AgainstDateTimeInFuture(dateTime, compareDateTime);

            IResult<DateTime> result = guard.GetResult();

            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsType<SuccessResult<DateTime>>(result);
        }
    }
}
