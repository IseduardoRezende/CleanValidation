using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using CleanValidation.Core.Options;
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
            if (Continue && !IsValidPassword(password, options))
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

        protected static bool ContainsSequence(string? password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            for (int i = 0; i < password.Length - 1; i++)
            {
                char current = password[i];
                char next = password[i + 1];

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
            if (Continue &&
                (email is null or { Length: > MaxEmailAddressLength } ||
                !new EmailAddressAttribute().IsValid(email)))
            {
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstInvalidEmailAddress), paramName, cultureName: CultureName), message));
            }
         
            return this;
        }

        public Guard AgainstInvalidPhone(
            string? phone,
            string? message = null,
            [CallerArgumentExpression(nameof(phone))] string? paramName = null)
        {
            if (Continue && (phone is null || !new PhoneAttribute().IsValid(phone)))
                Result = InvalidResult.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstInvalidPhone), paramName, cultureName: CultureName), message));

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
            if (Continue && !IsValidPassword(password, options))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstWeakPassword), paramName, cultureName: CultureName), message));

            return this;
        }

        new public Guard<T> AgainstInvalidEmailAddress(
            string? email,
            string? message = null,
            [CallerArgumentExpression(nameof(email))] string? paramName = null)
        {
            if (Continue && 
               (email is null or { Length: > MaxEmailAddressLength } || 
               !new EmailAddressAttribute().IsValid(email)))
            {
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstInvalidEmailAddress), paramName, cultureName: CultureName), message));
            }

            return this;
        }

        new public Guard<T> AgainstInvalidPhone(
            string? phone,
            string? message = null,
            [CallerArgumentExpression(nameof(phone))] string? paramName = null)
        {
            if (Continue && (phone is null || !new PhoneAttribute().IsValid(phone)))
                Result = InvalidResult<T>.Create(
                    ErrorUtils.Custom(ErrorUtils.GetByKey(nameof(AgainstInvalidPhone), paramName, cultureName: CultureName), message));

            return this;
        }
    }
}
