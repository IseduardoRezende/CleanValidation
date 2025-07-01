using CleanValidation.Core.Guards;
using CleanValidation.Core.Results;
using CleanValidation.Core.Validators;

namespace CleanValidation.Core.Tests
{
    public record User(string Name, byte Age, string Description);

    public class UserValidator : Validator<User>
    {
        public override IResult Validate(User value, string cultureName = "en-US")
        {
            IResult result = base.Validate(value, cultureName);

            if (!result.Success)
                return result;

            return Guard.Create(cultureName)
               .AgainstWhiteSpace(value.Name)
               .AgainstWhiteSpace(value.Description)
               .GetResult();
        }

        public override async Task<IResult> ValidateAsync(
            User value, 
            string cultureName = "en-US", 
            CancellationToken cancellationToken = default)
        {
            IResult result = await base.ValidateAsync(value, cultureName, cancellationToken);

            if (!result.Success)
                return result;

            //Simulates a asynchronously operation
            await Task.Delay(millisecondsDelay: 350, cancellationToken);

            return SuccessResult.Create();
        }
    }    
}
