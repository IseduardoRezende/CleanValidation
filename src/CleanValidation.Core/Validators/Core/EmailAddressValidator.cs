using System.ComponentModel.DataAnnotations;

namespace CleanValidation.Core.Validators.Core
{
    internal class EmailAddressValidator
    {
        public const int MaxEmailAddressLength = 320;

        public static bool IsValid(string? email)
        {
            return email is { Length: <= MaxEmailAddressLength } &&
                   new EmailAddressAttribute().IsValid(email);
        }
    }
}
