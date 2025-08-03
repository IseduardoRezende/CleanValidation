using CleanValidation.Core.Exceptions;

namespace CleanValidation.Core.GuardThrows
{
    /// <summary>
    /// Provides a mechanism for validating input values and throwing <see cref="CleanValidationException"/> when validation fails.
    /// </summary>
    /// <remarks>
    /// The <see cref="GuardThrow"/> class is designed to facilitate input validation in a fluent
    /// manner. It allows chaining multiple validation methods, such as <see cref="AgainstWhiteSpace(string,
    /// string?, string?)"/> and <see cref="AgainstNull(object?, string?,  string?)"/>.
    /// </remarks>
    public partial class GuardThrow
    {
        protected GuardThrow(string cultureName = "en-US")
        {
            CultureName = cultureName;
        }

        protected string CultureName { get; }

        public static GuardThrow Create(string cultureName = "en-US")
        {
            return new GuardThrow(cultureName);
        }
    }

    public partial class GuardThrow<T> : GuardThrow
    {
        protected GuardThrow(T? value, string cultureName) : base(cultureName)
        {
            Value = value;
        }

        protected T? Value { get; }

        public static GuardThrow<T> Create(T? value, string cultureName = "en-US")
        {
            return new GuardThrow<T>(value, cultureName);
        }

        new public static GuardThrow<T> Create(string cultureName = "en-US")
        {
            return new GuardThrow<T>(default, cultureName);
        }

        public T? GetValue()
        {
            return Value;
        }
    }
}
