namespace CleanValidation.Core.Validators.Core
{
    internal class UriValidator
    {
        public static bool IsValid(
           string? uri,
           UriKind kind = UriKind.Absolute)
        {
            if (!Uri.IsWellFormedUriString(uri, kind) || !Uri.TryCreate(uri, kind, out Uri? outUri))
                return false;

            return outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps;
        }
    }
}
