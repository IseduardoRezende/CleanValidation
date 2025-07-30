using System.ComponentModel.DataAnnotations;

namespace CleanValidation.Core.Validators.Core
{
    internal class PhoneValidator
    {
        public static bool IsValid(string? phone)
        {
            return phone is not null && new PhoneAttribute().IsValid(phone);
        }
    }
}
