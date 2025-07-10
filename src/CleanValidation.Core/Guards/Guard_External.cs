using System.Net;
using System.Text.Json;
using System.Net.Sockets;
using CleanValidation.Core.Errors;
using CleanValidation.Core.Options;
using CleanValidation.Core.Results;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstInvalidUri(
            string? uri,
            UriKind kind = UriKind.Absolute,
            string? message = null,
            [CallerArgumentExpression(nameof(uri))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!Uri.IsWellFormedUriString(uri, kind) || !Uri.TryCreate(uri, kind, out Uri? outUri))
            {
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));
                return this;
            }

            if (outUri.Scheme != Uri.UriSchemeHttp && outUri.Scheme != Uri.UriSchemeHttps)
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        [GeneratedRegex(@"^((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.|$)){4}$")]
        protected static partial Regex StrictIpv4Regex();

        public Guard AgainstInvalidIpAddress(
            string? ipAddress,
            IpAddressOptions options = IpAddressOptions.None,
            string? message = null,
            [CallerArgumentExpression(nameof(ipAddress))] string? paramName = null)
        {
            if (Continue && !IsValidIpAddress(ipAddress, options))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        protected static bool IsValidIpAddress(
            string? ipAddress,
            IpAddressOptions options = IpAddressOptions.None)
        {
            if (!IPAddress.TryParse(ipAddress, out var ip))
                return false;

            if ((options & IpAddressOptions.DisallowLeadingZerosInIpv4) != 0 &&
                ip.AddressFamily == AddressFamily.InterNetwork &&
                !StrictIpv4Regex().IsMatch(ipAddress))
            {
                return false;
            }

            if ((options & IpAddressOptions.DisallowIpv6) != 0 &&
                ip.AddressFamily == AddressFamily.InterNetworkV6)
            {
                return false;
            }

            if ((options & IpAddressOptions.DisallowLoopback) != 0 &&
                IPAddress.IsLoopback(ip))
            {
                return false;
            }

            return true;
        }

        public Guard AgainstHtml(
            string? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            var html = WebUtility.HtmlEncode(value);

            if (string.IsNullOrWhiteSpace(html) || !html.Equals(value))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstUnmatchRegex(
            string? value,
            string pattern,
            RegexOptions options = RegexOptions.None,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || pattern is null || !Regex.IsMatch(value, pattern, options)))
                Result = InvalidResult.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        public Guard AgainstInvalidJson<T>(
            string? json,
            JsonSerializerOptions? options = null,
            string? message = null,
            [CallerArgumentExpression(nameof(json))] string? paramName = null)
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
        new public Guard<T> AgainstInvalidUri(
            string? uri,
            UriKind kind = UriKind.Absolute,
            string? message = null,
            [CallerArgumentExpression(nameof(uri))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!Uri.IsWellFormedUriString(uri, kind) || !Uri.TryCreate(uri, kind, out Uri? outUri))
            {
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));
                return this;
            }

            if (outUri.Scheme != Uri.UriSchemeHttp && outUri.Scheme != Uri.UriSchemeHttps)
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstInvalidIpAddress(
            string? ipAddress,
            IpAddressOptions options = IpAddressOptions.None,
            string? message = null,
            [CallerArgumentExpression(nameof(ipAddress))] string? paramName = null)
        {
            if (Continue && !IsValidIpAddress(ipAddress, options))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstHtml(
            string? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            var html = WebUtility.HtmlEncode(value);

            if (string.IsNullOrWhiteSpace(html) || !html.Equals(value))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstUnmatchRegex(
            string? value,
            string pattern,
            RegexOptions options = RegexOptions.None,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (Continue && (value is null || pattern is null || !Regex.IsMatch(value, pattern, options)))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }

        new public Guard<T> AgainstInvalidJson<TValue>(
            string? json,
            JsonSerializerOptions? options = null,
            string? message = null,
            [CallerArgumentExpression(nameof(json))] string? paramName = null)
        {
            if (Continue && !IsValidJson<TValue>(json, options))
                Result = InvalidResult<T>.Create(ErrorUtils.InvalidParameter(CultureName, paramName));

            return this;
        }
    }
}
