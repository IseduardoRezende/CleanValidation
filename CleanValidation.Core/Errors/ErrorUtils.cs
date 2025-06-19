using CleanValidation.Core.Resources;

namespace CleanValidation.Core.Errors
{
    public static class ErrorUtils
    {        
        public static Error InvalidOperation(string cultureName)
        {
            return new Error(ResourceManager.GetString("ErrorUtils_InvalidOperation", cultureName), field: null);
        }
        
        public static Error InvalidParameter(string cultureName, string? field) 
        { 
            return new Error(ResourceManager.GetString("ErrorUtils_InvalidParameter", cultureName), field);
        }

        public static IEnumerable<Error> InvalidParameters(string cultureName, params string[] fields)
        {
            foreach (var field in fields)
            {
                yield return InvalidParameter(cultureName, field);
            }
        }
    }
}
