using CleanValidation.Core.GuardThrows;

namespace CleanValidation.Core.Extensions
{
    public static class GuardThrowExtensions
    {
        public static GuardThrow<T> GuardThrow<T>(this T? value, string cultureName = "en-US")
        {
            return GuardThrows.GuardThrow<T>.Create(value, cultureName);
        }
    }
}
