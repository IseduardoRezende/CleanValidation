using System.Net;

namespace CleanValidation.Core.Validators.Core
{
    internal class StringValidator
    {
        public static bool ContainsHtml(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            string html = WebUtility.HtmlEncode(value);
            return !html.Equals(value);
        }

        public static bool ContainsSequence(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            for (int i = 0; i < value.Length - 1; i++)
            {
                char current = value[i];
                char next = value[i + 1];

                // Only Chars or Digits
                if ((char.IsLower(current) && char.IsLower(next)) ||
                    (char.IsUpper(current) && char.IsUpper(next)) ||
                    (char.IsDigit(current) && char.IsDigit(next)))
                {
                    // Using table ASCII
                    if (next - current == 1)
                        return true;
                }
            }

            return false;
        }
    }
}
