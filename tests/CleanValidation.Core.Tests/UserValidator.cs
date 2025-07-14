using CleanValidation.Core.Guards;
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
        public override IResult Validate(User? value, string cultureName = "en-US") =>
            Guard.Create(cultureName)
            .AgainstNull(value)
            .AgainstWhiteSpace(value.Name)
            .AgainstLessThan(value.Id, min: 1)
            .AgainstMinLength(value.Name, minLength: 3)
            .AgainstMaxLength(value.Name, maxLength: 50)
            .AgainstOutOfRange(value.Age, min: 18, max: 110)
            .GetResult();
    }
}
