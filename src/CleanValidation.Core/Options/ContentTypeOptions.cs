using System.Collections.ObjectModel;

namespace CleanValidation.Core.Options
{
    public enum ContentType
    {
        PDF,
        PNG,
        JPEG,
        BMP,
        ZIP
    }

    public static class ContentTypeOptions
    {
        private static readonly ReadOnlyDictionary<string, byte[]> _identifiers =
            new Dictionary<string, byte[]>
        {
            { nameof(ContentType.PDF),  [0x25, 0x50, 0x44, 0x46] },
            { nameof(ContentType.PNG),  [0x89, 0x50, 0x4E, 0x47] },
            { nameof(ContentType.JPEG), [0xFF, 0xD8, 0xFF] },
            { nameof(ContentType.BMP),  [0x42, 0x4D] },
            { nameof(ContentType.ZIP),  [0x50, 0x4B, 0x03, 0x04] },
        }.AsReadOnly();

        public static bool ContainsType(
            IEnumerable<byte>? fileData,
            IEnumerable<ContentType>? contentTypes)
        {
            if (fileData is null || contentTypes is null)
                return false;

            foreach (ContentType contentType in contentTypes)
            {
                if (ContainsMagicNumbers(fileData, contentType.ToString()))
                    return true;
            }

            return false;
        }

        public static bool ContainsType(
            IEnumerable<byte>? fileData,
            ContentType contentType)
        {
            if (fileData is null)
                return false;

            return ContainsMagicNumbers(fileData, contentType.ToString());
        }

        private static bool ContainsMagicNumbers(IEnumerable<byte>? fileData, string? identifierKey)
        {
            if (fileData is null || identifierKey is null ||
                !_identifiers.TryGetValue(identifierKey, out byte[]? magicBytes))
            {
                return false;
            }

            return fileData.Take(magicBytes.Length).SequenceEqual(magicBytes);
        }
    }
}
