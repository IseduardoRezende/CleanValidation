namespace CleanValidation.Core.Options
{
    public class PasswordOptions
    {
        public static readonly PasswordOptions Default = new()
        {
            MinLength = 8,
            MaxLength = 35, 
            RequireUpper = true,
            RequireLower = true,
            RequireDigit = true,
            RequireSpecial = true,
            DisallowSequences = true,
        };

        public int MaxLength { get; init; }

        public int MinLength { get; init; }

        public bool RequireUpper { get; init; }
        
        public bool RequireLower { get; init; }
        
        public bool RequireDigit { get; init; }

        public bool RequireSpecial { get; init; }

        public bool DisallowSequences { get; init; }           
    }
}
