namespace CleanValidation.Core.Options
{
    [Flags]
    public enum PasswordOptions
    {
        RequireUpper = 0,
        RequireLower = 1,
        RequireDigit = 2,
        RequireSpecial = 4,
    }
}
