using System.Linq.Expressions;
using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using CleanValidation.Core.Options;
using CleanValidation.Core.Extensions;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

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

            if (!IsValidPassword(password, options))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstWeakPassword), paramName, cultureName: CultureName), message));

            return this;
        }

        protected static bool IsValidPassword(
            string? password,
            PasswordOptions? options)
        {
            if (string.IsNullOrWhiteSpace(password) || options is null)
                return false;

            if (password.Length < options.MinLength || password.Length > options.MaxLength)
                return false;

            if (options.RequireDigit && !password.Any(char.IsDigit))
                return false;

            if (options.RequireUpper && !password.Any(char.IsUpper))
                return false;

            if (options.RequireLower && !password.Any(char.IsLower))
                return false;

            if (options.RequireSpecial && !password.Any(c => !char.IsLetterOrDigit(c)))
                return false;

            if (options.DisallowSequences && ContainsSequence(password))
                return false;

            return true;
        }

        protected static bool ContainsSequence(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            for (int i = 0; i < value.Length - 1; i++)
            {
                char current = value[i];
                char next = value[i + 1];

                // Only Chars or Digits
                if ((char.IsLower(current) && char.IsLower(next)) ||
                    (char.IsUpper(current) && char.IsUpper(next)) ||
                    (char.IsDigit(current) && char.IsDigit(next)))
                {
                    // Using table ASCII
                    if (next - current == 1)
                        return true;
                }
            }

            return false;
        }

        protected const int MaxEmailAddressLength = 320;

        public Guard AgainstInvalidEmailAddress(
            string? email,
            string? message = null,
            [CallerArgumentExpression(nameof(email))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!IsValidEmailAddress(email))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstInvalidEmailAddress), paramName, cultureName: CultureName), message));

            return this;
        }

        protected static bool IsValidEmailAddress(string? email)
        {
            return email is { Length: <= MaxEmailAddressLength } &&
                   new EmailAddressAttribute().IsValid(email);
        }

        public Guard AgainstInvalidPhone(
            string? phone,
            string? message = null,
            [CallerArgumentExpression(nameof(phone))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!IsValidPhone(phone))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstInvalidPhone), paramName, cultureName: CultureName), message));

            return this;

        }

        protected static bool IsValidPhone(string? phone)
        {
            return phone is not null && new PhoneAttribute().IsValid(phone);
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

            if (!IsValidPassword(password, options))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstWeakPassword), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstWeakPassword(
            Expression<Func<T, string?>> property,
            PasswordOptions? options,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            string? password = property.GetValue(Result.Value);

            if (!IsValidPassword(password, options))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstWeakPassword), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstInvalidEmailAddress(
            string? email,
            string? message = null,
            [CallerArgumentExpression(nameof(email))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!IsValidEmailAddress(email))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstInvalidEmailAddress), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstInvalidEmailAddress(
            Expression<Func<T, string?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            string? email = property.GetValue(Result.Value);

            if (!IsValidEmailAddress(email))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstInvalidEmailAddress), property.GetName(), cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstInvalidPhone(
            string? phone,
            string? message = null,
            [CallerArgumentExpression(nameof(phone))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!IsValidPhone(phone))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstInvalidPhone), paramName, cultureName: CultureName), message));

            return this;
        }

        public Guard<T> AgainstInvalidPhone(
            Expression<Func<T, string?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            string? phone = property.GetValue(Result.Value);

            if (!IsValidPhone(phone))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstInvalidPhone), property.GetName(), cultureName: CultureName), message));

            return this;
        }
    }
}
