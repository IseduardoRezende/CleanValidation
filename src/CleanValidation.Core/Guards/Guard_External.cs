using System.Text.Json;
using System.Linq.Expressions;
using CleanValidation.Core.Errors;
using CleanValidation.Core.Options;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using CleanValidation.Core.Extensions;
using CleanValidation.Core.Validators.Core;

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

            if (!UriValidator.IsValid(uri, kind))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidUri), paramName, CultureName), message));

            return this;
        }

        public Guard AgainstInvalidIpAddress(
            string? ipAddress,
            IpAddressOptions options = IpAddressOptions.None,
            string? message = null,
            [CallerArgumentExpression(nameof(ipAddress))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!IpAddressValidator.IsValid(ipAddress, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidIpAddress), paramName, CultureName), message));

            return this;
        }

        public Guard AgainstHtml(
            string? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (StringValidator.ContainsHtml(value))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstHtml), paramName, CultureName), message));

            return this;
        }

        public Guard AgainstUnmatchRegex(
            string? value,
            string pattern,
            RegexOptions options = RegexOptions.None,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null || pattern is null)
                return this;

            if (!Regex.IsMatch(value, pattern, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstUnmatchRegex), paramName, CultureName), message));

            return this;
        }

        public Guard AgainstInvalidJson<T>(
            string? json,
            JsonSerializerOptions? options = null,
            string? message = null,
            [CallerArgumentExpression(nameof(json))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!JsonValidator.IsValid<T>(json, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidJson), paramName, CultureName), message));

            return this;
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

            if (!UriValidator.IsValid(uri, kind))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidUri), paramName, CultureName), message));

            return this;
        }

        public Guard<T> AgainstInvalidUri(
            Expression<Func<T, string?>> property,
            UriKind kind = UriKind.Absolute,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            string? uri = property.GetValue(Value);

            if (!UriValidator.IsValid(uri, kind))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidUri), property.GetName(), CultureName), message));

            return this;
        }

        new public Guard<T> AgainstInvalidIpAddress(
            string? ipAddress,
            IpAddressOptions options = IpAddressOptions.None,
            string? message = null,
            [CallerArgumentExpression(nameof(ipAddress))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!IpAddressValidator.IsValid(ipAddress, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidIpAddress), paramName, CultureName), message));

            return this;
        }

        public Guard<T> AgainstInvalidIpAddress(
            Expression<Func<T, string?>> property,
            IpAddressOptions options = IpAddressOptions.None,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            string? ipAddress = property.GetValue(Value);

            if (!IpAddressValidator.IsValid(ipAddress, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidIpAddress), property.GetName(), CultureName), message));

            return this;
        }

        new public Guard<T> AgainstHtml(
            string? value,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (StringValidator.ContainsHtml(value))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstHtml), paramName, CultureName), message));

            return this;
        }

        public Guard<T> AgainstHtml(
            Expression<Func<T, string?>> property,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            string? value = property.GetValue(Value);

            if (StringValidator.ContainsHtml(value))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstHtml), property.GetName(), CultureName), message));

            return this;
        }

        new public Guard<T> AgainstUnmatchRegex(
            string? value,
            string pattern,
            RegexOptions options = RegexOptions.None,
            string? message = null,
            [CallerArgumentExpression(nameof(value))] string? paramName = null)
        {
            if (!Continue || value is null || pattern is null)
                return this;

            if (!Regex.IsMatch(value, pattern, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstUnmatchRegex), paramName, CultureName), message));

            return this;
        }

        public Guard<T> AgainstUnmatchRegex(
            Expression<Func<T, string?>> property,
            string pattern,
            RegexOptions options = RegexOptions.None,
            string? message = null)
        {
            if (!Continue || property is null || pattern is null)
                return this;

            string? value = property.GetValue(Value);

            if (value is null)
                return this;

            if (!Regex.IsMatch(value, pattern, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstUnmatchRegex), property.GetName(), CultureName), message));

            return this;
        }

        new public Guard<T> AgainstInvalidJson<TValue>(
            string? json,
            JsonSerializerOptions? options = null,
            string? message = null,
            [CallerArgumentExpression(nameof(json))] string? paramName = null)
        {
            if (!Continue)
                return this;

            if (!JsonValidator.IsValid<TValue>(json, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidJson), paramName, CultureName), message));

            return this;
        }

        public Guard<T> AgainstInvalidJson<TValue>(
            Expression<Func<T, string?>> property,
            JsonSerializerOptions? options = null,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            string? json = property.GetValue(Value);

            if (!JsonValidator.IsValid<TValue>(json, options))
                ErrorBag.Add(ErrorUtils.Custom(ErrorUtils
                    .GetByKey(nameof(AgainstInvalidJson), property.GetName(), CultureName), message));

            return this;
        }
    }
}
