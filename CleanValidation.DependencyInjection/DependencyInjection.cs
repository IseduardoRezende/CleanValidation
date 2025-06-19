using CleanValidation.Core.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CleanValidation.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCleanValidation(IServiceCollection services)
        {
            return services.Scan(scan => scan
            .FromEntryAssembly()
            .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        }
    }
}
