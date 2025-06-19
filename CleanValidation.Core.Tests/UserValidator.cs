using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;
using CleanValidation.Core.Validators;

namespace CleanValidation.Core.Tests
{
    internal record User(string Name, byte Age, string Description);
    
    internal class UserValidator : Validator<User>
    {
        public override async Task<Result<User>> ValidateAsync(
            User value, 
            string cultureName = "en-US", 
            CancellationToken cancellationToken = default)
        {
            var result = await base.ValidateAsync(value, cultureName, cancellationToken);

            if (!result.Sucess)
                return result;

            return Guard<User>.Create(cultureName)
                .AgainstNullOrWhiteSpace(value.Name)
                .AgainstNullOrWhiteSpace(value.Description)
                .Result;
        }
    }    
}
