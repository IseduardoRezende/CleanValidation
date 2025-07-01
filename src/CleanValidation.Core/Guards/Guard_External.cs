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
        public Guard AgainstUri(string? uri, UriKind kind = UriKind.Absolute, string? message = null, [CallerArgumentExpression(nameof(uri))] string? paramName = null)
        {
            if (Continue && !Uri.TryCreate(uri, kind, out _))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstIpAddress(string? ip, string? message = null, [CallerArgumentExpression(nameof(ip))] string? paramName = null)
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

        public Guard AgainstRegex(string? value, string? pattern, RegexOptions options = RegexOptions.None, string? message = null, [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || pattern is null || !Regex.IsMatch(value, pattern, options)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstJson<T>(string? json, string? message = null, JsonSerializerOptions? options = null, [CallerArgumentExpression(nameof(json))] string? paramName = null)
        {
            if (Continue && !IsValidJson<T>(json, options))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;            
        }

        private static bool IsValidJson<T>(string? json, JsonSerializerOptions? options = null)
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
}
