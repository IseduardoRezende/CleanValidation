using System.Linq.Expressions;
using CleanValidation.Core.Errors;
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

            if (date > compareDate)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateInFuture), paramName, cultureName: CultureName), message));

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

            if (date < compareDate)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateInPast), paramName, cultureName: CultureName), message));

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

            if (time > compareTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstTimeInFuture), paramName, cultureName: CultureName), message));

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

            if (time < compareTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstTimeInPast), paramName, cultureName: CultureName), message));

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

            if (dateTime > compareDateTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateTimeInFuture), paramName, cultureName: CultureName), message));

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

            if (dateTime < compareDateTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateTimeInPast), paramName, cultureName: CultureName), message));

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

            if (date > compareDate)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstDateInFuture(
            Expression<Func<T, DateOnly?>> property,
            DateOnly compareDate,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            DateOnly? date = property.GetValue(Value);

            if (date is not null && date > compareDate)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateInFuture), property.GetName(), cultureName: CultureName), message));

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

            if (date < compareDate)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateInPast), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstDateInPast(
            Expression<Func<T, DateOnly?>> property,
            DateOnly compareDate,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            DateOnly? date = property.GetValue(Value);

            if (date is not null && date < compareDate)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateInPast), property.GetName(), cultureName: CultureName), message));

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

            if (time > compareTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstTimeInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstTimeInFuture(
            Expression<Func<T, TimeOnly?>> property,
            TimeOnly compareTime,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            TimeOnly? time = property.GetValue(Value);

            if (time is not null && time > compareTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstTimeInFuture), property.GetName(), cultureName: CultureName), message));

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

            if (time < compareTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstTimeInPast), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstTimeInPast(
            Expression<Func<T, TimeOnly?>> property,
            TimeOnly compareTime,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            TimeOnly? time = property.GetValue(Value);

            if (time is not null && time < compareTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstTimeInPast), property.GetName(), cultureName: CultureName), message));

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

            if (dateTime > compareDateTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateTimeInFuture), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstDateTimeInFuture(
            Expression<Func<T, DateTime?>> property,
            DateTime compareDateTime,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            DateTime? dateTime = property.GetValue(Value);

            if (dateTime is not null && dateTime > compareDateTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateTimeInFuture), property.GetName(), cultureName: CultureName), message));

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

            if (dateTime < compareDateTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateTimeInPast), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstDateTimeInPast(
            Expression<Func<T, DateTime?>> property,
            DateTime compareDateTime,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            DateTime? dateTime = property.GetValue(Value);

            if (dateTime is not null && dateTime < compareDateTime)
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstDateTimeInPast), property.GetName(), cultureName: CultureName), message));

            return this;
        }
    }
}
