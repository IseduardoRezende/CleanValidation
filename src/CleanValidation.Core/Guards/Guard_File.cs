using System.Linq.Expressions;
using CleanValidation.Core.Options;
using CleanValidation.Core.Results;
using CleanValidation.Core.Extensions;
using System.Runtime.CompilerServices;

namespace CleanValidation.Core.Guards
{
    public partial class Guard
    {
        public Guard AgainstInvalidContentTypes(
            IEnumerable<byte>? fileData,
            IEnumerable<ContentType>? contentTypes,
            string? message = null,
            [CallerArgumentExpression(nameof(fileData))] string? paramName = null)
        {
            if (!Continue || fileData is null || contentTypes is null)
                return this;

            if (ContentTypeOptions.ContainsType(fileData, contentTypes))
                Result = InvalidResult.Create([]);

            return this;
        }

        public Guard AgainstNotExactContentType(
            IEnumerable<byte>? fileData,
            ContentType contentType,
            string? message = null,
            [CallerArgumentExpression(nameof(fileData))] string? paramName = null)
        {
            if (!Continue || fileData is null)
                return this;

            if (!ContentTypeOptions.ContainsType(fileData, contentType))
                Result = InvalidResult.Create([]);

            return this;
        }
    }

    public partial class Guard<T>
    {
        new public Guard<T> AgainstInvalidContentTypes(
            IEnumerable<byte>? fileData,
            IEnumerable<ContentType>? contentTypes,
            string? message = null,
            [CallerArgumentExpression(nameof(fileData))] string? paramName = null)
        {
            if (!Continue || fileData is null || contentTypes is null)
                return this;

            if (ContentTypeOptions.ContainsType(fileData, contentTypes))
                Result = InvalidResult<T>.Create([]);

            return this;
        }

        public Guard<T> AgainstInvalidContentTypes(
            Expression<Func<T, IEnumerable<byte>?>> property,
            IEnumerable<ContentType>? contentTypes,
            string? message = null)
        {
            if (!Continue || property is null || contentTypes is null)
                return this;

            IEnumerable<byte>? fileData = property.GetValue(Result.Value);

            if (fileData is null)
                return this;

            if (ContentTypeOptions.ContainsType(fileData, contentTypes))
                Result = InvalidResult<T>.Create([]);

            return this;
        }

        new public Guard<T> AgainstNotExactContentType(
            IEnumerable<byte>? fileData,
            ContentType contentType,
            string? message = null,
            [CallerArgumentExpression(nameof(fileData))] string? paramName = null)
        {
            if (!Continue || fileData is null)
                return this;

            if (!ContentTypeOptions.ContainsType(fileData, contentType))
                Result = InvalidResult<T>.Create([]);

            return this;
        }

        public Guard<T> AgainstNotExactContentType(
            Expression<Func<T, IEnumerable<byte>?>> property,
             ContentType contentType,
            string? message = null)
        {
            if (!Continue || property is null)
                return this;

            IEnumerable<byte>? fileData = property.GetValue(Result.Value);

            if (fileData is null)
                return this;

            if (!ContentTypeOptions.ContainsType(fileData, contentType))
                Result = InvalidResult<T>.Create([]);

            return this;
        }
    }
}
