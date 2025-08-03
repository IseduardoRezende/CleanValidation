using CleanValidation.Core.Guards;
using CleanValidation.Core.Options;
using CleanValidation.Core.Results;
using CleanValidation.Core.Validators;

namespace CleanValidation.Core.Tests
{
    public record Base(long Id);

    public record User(long Id, string Name, byte Age) : Base(Id);

    public record Post(long Id, string Tittle, long UserId, string Content, PostType Type) : Base(Id);

    public enum PostType { Games, Programming, Life, Movies }

    public class UserValidator : Validator<User>
    {
        public override IResult<User> Validate(
            User? user,
            ValidationOption option = ValidationOption.ContinueOnFailure,
            string cultureName = "en-US")
        {
            return Guard<User>.Create(user, option, cultureName)
            .AgainstNull()
            .AgainstWhiteSpace(u => u.Name)
            .AgainstLessThan(u => u.Id, min: 1)
            .AgainstMinLength(u => u.Name, minLength: 3)
            .AgainstMaxLength(u => u.Name, maxLength: 50)
            .AgainstOutOfRange(u => u.Age, min: 18, max: 110)
            .GetResult();
        }
    }
}
