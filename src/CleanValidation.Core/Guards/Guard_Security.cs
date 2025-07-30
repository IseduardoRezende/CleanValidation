using System.Linq.Expressions;
using CleanValidation.Core.Errors;
using CleanValidation.Core.Options;
using CleanValidation.Core.Extensions;
using System.Runtime.CompilerServices;
using CleanValidation.Core.Validators.Core;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstWeakPassword(
            string? password,
            PasswordOptions? options,
            string? message = null,
            [CallerArgumentExpression(nameof(password))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!PasswordValidator.IsValid(password, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstWeakPassword), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstInvalidEmailAddress(
            string? email,
            string? message = null,
            [CallerArgumentExpression(nameof(email))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!EmailAddressValidator.IsValid(email))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidEmailAddress), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard AgainstInvalidPhone(
            string? phone,
            string? message = null,
            [CallerArgumentExpression(nameof(phone))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!PhoneValidator.IsValid(phone))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidPhone), paramName, cultureName: CultureName), message));

            return this;

        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstWeakPassword(
            string? password,
            PasswordOptions? options,
            string? message = null,
            [CallerArgumentExpression(nameof(password))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!PasswordValidator.IsValid(password, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstWeakPassword), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstWeakPassword(
            Expression<Func<T, string?>> property,
            PasswordOptions? options,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            string? password = property.GetValue(Value);

            if (!PasswordValidator.IsValid(password, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstWeakPassword), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstInvalidEmailAddress(
            string? email,
            string? message = null,
            [CallerArgumentExpression(nameof(email))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!EmailAddressValidator.IsValid(email))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidEmailAddress), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstInvalidEmailAddress(
            Expression<Func<T, string?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            string? email = property.GetValue(Value);

            if (!EmailAddressValidator.IsValid(email))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidEmailAddress), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstInvalidPhone(
            string? phone,
            string? message = null,
            [CallerArgumentExpression(nameof(phone))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!PhoneValidator.IsValid(phone))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidPhone), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstInvalidPhone(
            Expression<Func<T, string?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            string? phone = property.GetValue(Value);

            if (!PhoneValidator.IsValid(phone))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidPhone), property.GetName(), cultureName: CultureName), message));

            return this;
        }
    }
}
