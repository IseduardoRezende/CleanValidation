using System.Text.Json;

namespace CleanValidation.Core.Validators.Core
{
    internal class JsonValidator
    {
        public static bool IsValid<T>(string? json, JsonSerializerOptions? options = null)
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
