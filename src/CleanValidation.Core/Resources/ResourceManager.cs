using System.Globalization;
using System.Reflection;

namespace CleanValidation.Core.Resources
{
    internal static class ResourceManager
    {
        public const string BaseName = "CleanValidation.Core.Resources.Messages";

        public static string GetString(string key, string cultureName)
        {            
            System.Resources.ResourceManager resourceManager = new(BaseName, Assembly.GetExecutingAssembly());
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureName);
            return resourceManager.GetString(key)!;
        }
    }
}
