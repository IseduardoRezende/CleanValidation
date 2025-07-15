using System.Resources;
using System.Reflection;
using System.Globalization;
using CleanValidation.Core.Exceptions;

namespace CleanValidation.Core.Resources
{
    public class CleanResourceManager
    {
        public const string DefaultBaseName = "CleanValidation.Core.Resources.Messages";

        private CleanResourceManager(string baseName)
        {
            BaseName = baseName;
        }

        public string BaseName { get; }

        public static CleanResourceManager Create(string? baseName = DefaultBaseName)
        {
            return new(baseName ?? DefaultBaseName);
        }

        /// <summary>
        /// Retrieves a localized string resource based on the specified key and culture name.
        /// </summary>
        /// <remarks>This method uses the <see cref="ResourceManager"/> to retrieve
        /// string resources from the assembly. Ensure that the resource file is properly configured and contains the
        /// requested key for the specified culture.</remarks>
        /// <param name="key">The key identifying the string resource to retrieve. Cannot be null or empty.</param>
        /// <param name="cultureName">The name of the culture for which the resource is requested, such as "en-US". Cannot be null or empty.</param>
        /// <returns>The localized string resource corresponding to the specified key and culture. 
        /// Returns <see cref="string.Empty"/> if the resource is not found.</returns>
        /// <exception cref="CleanValidationException">Thrown if an error occurs while retrieving the resource.</exception>
        public string GetString(string key, string cultureName)
        {
            try
            {
                ResourceManager resourceManager = new(BaseName, Assembly.GetExecutingAssembly());
                CultureInfo? culture = CultureInfo.GetCultureInfo(cultureName);
                return resourceManager.GetString(key, culture) ?? string.Empty;
            }
            catch (Exception ex)
            {
                throw new CleanValidationException(ex.Message, ex);
            }
        }
    }
}
