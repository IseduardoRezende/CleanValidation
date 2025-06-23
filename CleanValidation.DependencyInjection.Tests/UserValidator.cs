using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;
using CleanValidation.Core.Validators;

namespace CleanValidation.DependencyInjection.Tests
{
    public record User(string Name, byte Age, string Description);

    public class UserValidator : Validator<User>
    {
        public override async Task<IResult> ValidateAsync(
            User value, 
            string cultureName = "en-US", 
            CancellationToken cancellationToken = default)
        {
            var result = await base.ValidateAsync(value, cultureName, cancellationToken);

            if (!result.Success)
                return result;

            return Guard.Create(cultureName)
                .AgainstNullOrWhiteSpace(value.Name)
                .AgainstNullOrWhiteSpace(value.Description)
                .GetResult();
        }
    }    
}
