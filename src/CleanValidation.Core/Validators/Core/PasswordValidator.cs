using CleanValidation.Core.Options;

namespace CleanValidation.Core.Validators.Core
{
    internal class PasswordValidator
    {
        public static bool IsValid(
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

            if (options.DisallowSequences && StringValidator.ContainsSequence(password))
                return false;

            return true;
        }

    }
}
