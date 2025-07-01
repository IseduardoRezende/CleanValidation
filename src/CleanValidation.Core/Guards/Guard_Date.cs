using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {        
        public Guard AgainstDateInFuture(DateOnly? date, DateOnly compareDate, string? message = null, [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (Continue && (date is null || date.Value > compareDate))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstDateInPast(DateOnly? date, DateOnly compareDate, string? message = null, [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (Continue && (date is null || date.Value < compareDate))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstDateRange(DateOnly? date, DateOnly min, DateOnly max, string? message = null, [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (Continue && (date is null || date.Value < min || date.Value > max))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
        
        public Guard AgainstTimeInFuture(TimeOnly? time, TimeOnly compareTime, string? message = null, [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (Continue && (time is null || time.Value > compareTime))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstTimeInPast(TimeOnly? time, TimeOnly compareTime, string? message = null, [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (Continue && (time is null || time.Value < compareTime))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstTimeRange(TimeOnly? time, TimeOnly min, TimeOnly max, string? message = null, [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (Continue && (time is null || time.Value < min || time.Value > max))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
        
        public Guard AgainstDateTimeInFuture(DateTime? dateTime, DateTime compareDateTime, string? message = null, [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (Continue && (dateTime is null || dateTime.Value > compareDateTime))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstDateTimeInPast(DateTime? dateTime, DateTime compareDateTime, string? message = null, [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (Continue && (dateTime is null || dateTime.Value < compareDateTime))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstDateTimeRange(DateTime? dateTime, DateTime min, DateTime max, string? message = null, [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (Continue && (dateTime is null || dateTime.Value < min || dateTime.Value > max))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }
}
