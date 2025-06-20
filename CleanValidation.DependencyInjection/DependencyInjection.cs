using CleanValidation.Core.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CleanValidation.DependencyInjection
{
    /// <summary>
    /// Provides methods for registering validation services in a dependency injection container.
    /// </summary>
    /// <remarks>This class is designed to simplify the integration of validation logic into applications by 
    /// automatically discovering and registering implementations of <see cref="IValidator{T}"/>. It is typically used
    /// in applications that rely on dependency injection for managing service lifetimes.</remarks>
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers all implementations of <see cref="IValidator{T}"/> found in the entry assembly  with the
        /// dependency injection container.
        /// </summary>
        /// <remarks>This method scans the entry assembly for classes that implement the <see
        /// cref="IValidator{T}"/> interface  and registers them with a scoped lifetime. It is typically used to
        /// integrate validation logic into an application.</remarks>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the validators will be added.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
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
