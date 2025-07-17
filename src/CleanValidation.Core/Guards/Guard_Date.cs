using System.Linq.Expressions;
using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using CleanValidation.Core.Extensions;
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
            if (!Continue || date is null)
                return this;

            if (date.Value > compareDate)
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
            if (!Continue || date is null)
                return this;

            if (date.Value < compareDate)
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
            if (!Continue || time is null)
                return this;

            if (time.Value > compareTime)
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
            if (!Continue || time is null)
                return this;

            if (time.Value < compareTime)
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
            if (!Continue || dateTime is null)
                return this;

            if (dateTime.Value > compareDateTime)
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
            if (!Continue || dateTime is null)
                return this;

            if (dateTime.Value < compareDateTime)
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
            if (!Continue || date is null)
                return this;

            if (date.Value > compareDate)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstDateInFuture<TProperty>(
            Expression<Func<T, TProperty?>> property,
            DateOnly compareDate,
            string? message = null)
                where TProperty : struct
        {
            if (!Continue || property is null)
                return this;

            DateOnly? date = property.GetValue(Result.Value).To<DateOnly>();

            if (date is not null && date > compareDate)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateInFuture), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstDateInPast(
            DateOnly? date,
            DateOnly compareDate,
            string? message = null,
            [CallerArgumentExpression(nameof(date))] string? paramName = null)
        {
            if (!Continue || date is null)
                return this;

            if (date.Value < compareDate)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateInPast), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstDateInPast<TProperty>(
            Expression<Func<T, TProperty?>> property,
            DateOnly compareDate,
            string? message = null)
                where TProperty : struct
        {
            if (!Continue || property is null)
                return this;

            DateOnly? date = property.GetValue(Result.Value).To<DateOnly>();

            if (date is not null && date < compareDate)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateInPast), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstTimeInFuture(
            TimeOnly? time,
            TimeOnly compareTime,
            string? message = null,
            [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (!Continue || time is null)
                return this;

            if (time.Value > compareTime)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTimeInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstTimeInFuture<TProperty>(
            Expression<Func<T, TProperty?>> property,
            TimeOnly compareTime,
            string? message = null)
                where TProperty : struct
        {
            if (!Continue || property is null)
                return this;

            TimeOnly? time = property.GetValue(Result.Value).To<TimeOnly>();

            if (time is not null && time > compareTime)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTimeInFuture), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstTimeInPast(
            TimeOnly? time,
            TimeOnly compareTime,
            string? message = null,
            [CallerArgumentExpression(nameof(time))] string? paramName = null)
        {
            if (!Continue || time is null)
                return this;

            if (time.Value < compareTime)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTimeInPast), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstTimeInPast<TProperty>(
            Expression<Func<T, TProperty?>> property,
            TimeOnly compareTime,
            string? message = null)
                where TProperty : struct
        {
            if (!Continue || property is null)
                return this;

            TimeOnly? time = property.GetValue(Result.Value).To<TimeOnly>();

            if (time is not null && time < compareTime)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstTimeInPast), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstDateTimeInFuture(
            DateTime? dateTime,
            DateTime compareDateTime,
            string? message = null,
            [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (!Continue || dateTime is null)
                return this;

            if (dateTime.Value > compareDateTime)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateTimeInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstDateTimeInFuture<TProperty>(
            Expression<Func<T, TProperty?>> property,
            DateTime compareDateTime,
            string? message = null)
                where TProperty : struct
        {
            if (!Continue || property is null)
                return this;

            DateTime? dateTime = property.GetValue(Result.Value).To<DateTime>();

            if (dateTime is not null && dateTime > compareDateTime)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateTimeInFuture), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstDateTimeInPast(
            DateTime? dateTime,
            DateTime compareDateTime,
            string? message = null,
            [CallerArgumentExpression(nameof(dateTime))] string? paramName = null)
        {
            if (!Continue || dateTime is null)
                return this;

            if (dateTime.Value < compareDateTime)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateTimeInPast), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstDateTimeInPast<TProperty>(
            Expression<Func<T, TProperty?>> property,
            DateTime compareDateTime,
            string? message = null)
                where TProperty : struct
        {
            if (!Continue || property is null)
                return this;

            DateTime? dateTime = property.GetValue(Result.Value).To<DateTime>();

            if (dateTime is not null && dateTime < compareDateTime)
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstDateTimeInPast), property.GetName(), cultureName: CultureName), message));

            return this;
        }
    }
}
