using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstWeakPassword(
            string? value,
            int minLength = 5,
            int maxLength = 20,
            bool requireUpper = true,
            bool requireLower = true,
            bool requireDigit = true,
            bool requireSpecial = true,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (string.IsNullOrWhiteSpace(value))
            {
                Result = ErrorResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));
                return this;
            }

            if (value.Length < minLength || value.Length > maxLength)
                Result = ErrorResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            if (requireDigit && !value.Any(char.IsDigit))
                Result = ErrorResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            if (requireUpper && !value.Any(char.IsUpper))
                Result = ErrorResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            if (requireLower && !value.Any(char.IsLower))
                Result = ErrorResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            if (requireSpecial && !value.Any(c => !char.IsLetterOrDigit(c)))
                Result = ErrorResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstInvalidEmailAddress(
            string? email, 
            string? message = null, 
            [CallerArgumentExpression(nameof(email))] string? paramName = null)
        {
            if (Continue && (email is null || !new EmailAddressAttribute().IsValid(email)))
                Result = ErrorResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }        

        public Guard AgainstInvalidPhone(
            string? phone, 
            string? message = null, 
            [CallerArgumentExpression(nameof(phone))] string? paramName = null)
        {
            if (Continue && (phone is null || !new PhoneAttribute().IsValid(phone)))
                Result = ErrorResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstWeakPassword(
            string? value,
            int minLength = 5,
            int maxLength = 20,
            bool requireUpper = true,
            bool requireLower = true,
            bool requireDigit = true,
            bool requireSpecial = true,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (string.IsNullOrWhiteSpace(value))
            {
                Result = ErrorResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));
                return this;
            }

            if (value.Length < minLength || value.Length > maxLength)
                Result = ErrorResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            if (requireDigit && !value.Any(char.IsDigit))
                Result = ErrorResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            if (requireUpper && !value.Any(char.IsUpper))
                Result = ErrorResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            if (requireLower && !value.Any(char.IsLower))
                Result = ErrorResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            if (requireSpecial && !value.Any(c => !char.IsLetterOrDigit(c)))
                Result = ErrorResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstInvalidEmailAddress(
            string? email, 
            string? message = null, 
            [CallerArgumentExpression(nameof(email))] string? paramName = null)
        {
            if (Continue && (email is null || !new EmailAddressAttribute().IsValid(email)))
                Result = ErrorResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }        

        new public Guard<T> AgainstInvalidPhone(
            string? phone, 
            string? message = null, 
            [CallerArgumentExpression(nameof(phone))] string? paramName = null)
        {
            if (Continue && (phone is null || !new PhoneAttribute().IsValid(phone)))
                Result = ErrorResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }
}
