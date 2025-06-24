using CleanValidation.Core.Validators;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
        /// <param name="assemblies">Represents the assemblies to scan.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddCleanValidation(this IServiceCollection services, Assembly[] assemblies)
        {
            return services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        }
    }
}
