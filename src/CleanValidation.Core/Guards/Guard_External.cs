using System.Net;
using System.Web;
using System.Text.Json;
using CleanValidation.Core.Errors;
using CleanValidation.Core.Results;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstInvalidUri(string? uri, UriKind kind = UriKind.Absolute, string? message = null, [CallerArgumentExpression(nameof(uri))] string? paramName = null)
        {
            if (Continue && !Uri.TryCreate(uri, kind, out _))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstInvalidIpAddress(string? ip, string? message = null, [CallerArgumentExpression(nameof(ip))] string? paramName = null)
        {
            if (Continue && (ip is null || !IPAddress.TryParse(ip, out _)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstContainsHtml(string? value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && HttpUtility.HtmlEncode(value) is not null)
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstUnmatchRegex(string? value, string? pattern, RegexOptions options = RegexOptions.None, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || pattern is null || !Regex.IsMatch(value, pattern, options)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstInvalidJson<T>(string? json, string? message = null, JsonSerializerOptions? options = null, [CallerArgumentExpression(nameof(json))] string? paramName = null)
        {
            if (Continue && !IsValidJson<T>(json, options))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        protected static bool IsValidJson<T>(string? json, JsonSerializerOptions? options = null)
        {
            if (string.IsNullOrWhiteSpace(json))
                return false;

            try
            {
                _ = JsonSerializer.Deserialize<T>(json, options);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstInvalidUri(string? uri, UriKind kind = UriKind.Absolute, string? message = null, [CallerArgumentExpression(nameof(uri))] string? paramName = null)
        {
            if (Continue && !Uri.TryCreate(uri, kind, out _))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstInvalidIpAddress(string? ip, string? message = null, [CallerArgumentExpression(nameof(ip))] string? paramName = null)
        {
            if (Continue && (ip is null || !IPAddress.TryParse(ip, out _)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstContainsHtml(string? value, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && HttpUtility.HtmlEncode(value) is not null)
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstUnmatchRegex(string? value, string? pattern, RegexOptions options = RegexOptions.None, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || pattern is null || !Regex.IsMatch(value, pattern, options)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstInvalidJson<TValue>(string? json, string? message = null, JsonSerializerOptions? options = null, [CallerArgumentExpression(nameof(json))] string? paramName = null)
        {
            if (Continue && !IsValidJson<TValue>(json, options))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }
}
