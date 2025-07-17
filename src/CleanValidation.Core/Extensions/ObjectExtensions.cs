namespace CleanValidation.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static TType? To<TType>(this object? obj)
        {
            try
            {
                return (TType?)Convert.ChangeType(obj, typeof(TType?));
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
