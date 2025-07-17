namespace CleanValidation.Core.Extensions
{
    public static class StringExtensions
    {
        public static string Format(this string value, params object[]? args)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            return string.Format(value, args ?? []);
        }
    }
}
