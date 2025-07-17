using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstDateInFuture(
            DateOnly? date, 
            DateOnly compareDate, 
            string? message = null, 
            [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (Continue && (date is null || date.Value > compareDate))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstDateInPast(
            DateOnly? date, 
            DateOnly compareDate, 
            string? message = null, 
            [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (Continue && (date is null || date.Value < compareDate))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateInPast), paramName, cultureName: CultureName), message));

            return this;
        }        

        public Guard AgainstTimeInFuture(
            TimeOnly? time, 
            TimeOnly compareTime, 
            string? message = null, 
            [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (Continue && (time is null || time.Value > compareTime))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTimeInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstTimeInPast(
            TimeOnly? time, 
            TimeOnly compareTime, 
            string? message = null, 
            [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (Continue && (time is null || time.Value < compareTime))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTimeInPast), paramName, cultureName: CultureName), message));

            return this;
        }        

        public Guard AgainstDateTimeInFuture(
            DateTime? dateTime, 
            DateTime compareDateTime, 
            string? message = null, 
            [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (Continue && (dateTime is null || dateTime.Value > compareDateTime))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateTimeInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstDateTimeInPast(
            DateTime? dateTime, 
            DateTime compareDateTime, 
            string? message = null, 
            [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (Continue && (dateTime is null || dateTime.Value < compareDateTime))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateTimeInPast), paramName, cultureName: CultureName), message));

            return this;
        }        
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstDateInFuture(
            DateOnly? date, 
            DateOnly compareDate, 
            string? message = null, 
            [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (Continue && (date is null || date.Value > compareDate))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstDateInPast(
            DateOnly? date, 
            DateOnly compareDate, 
            string? message = null, 
            [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (Continue && (date is null || date.Value < compareDate))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateInPast), paramName, cultureName: CultureName), message));

            return this;
        }      

        new public Guard<T> AgainstTimeInFuture(
            TimeOnly? time, 
            TimeOnly compareTime, 
            string? message = null, 
            [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (Continue && (time is null || time.Value > compareTime))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTimeInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstTimeInPast(
            TimeOnly? time, 
            TimeOnly compareTime, 
            string? message = null, 
            [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (Continue && (time is null || time.Value < compareTime))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTimeInPast), paramName, cultureName: CultureName), message));

            return this;
        }        

        new public Guard<T> AgainstDateTimeInFuture(
            DateTime? dateTime, 
            DateTime compareDateTime, 
            string? message = null, 
            [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (Continue && (dateTime is null || dateTime.Value > compareDateTime))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateTimeInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstDateTimeInPast(
            DateTime? dateTime, 
            DateTime compareDateTime, 
            string? message = null, 
            [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (Continue && (dateTime is null || dateTime.Value < compareDateTime))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateTimeInPast), paramName, cultureName: CultureName), message));

            return this;
        }        
    }
}
