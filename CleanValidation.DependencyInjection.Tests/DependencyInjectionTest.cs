using Microsoft.Extensions.DependencyInjection;

namespace CleanValidation.DependencyInjection.Tests
{
    public class DependencyInjectionTest
    {
        [Fact]
        public void AddCleanValidation_IncrementsServiceCollectionCount_ReturnsTrue()
        {
            ServiceCollection services = new();
            int startCount = services.Count;

            services.AddCleanValidation([typeof(UserValidator).Assembly]);
            int finalCount = services.Count;

            Assert.True(finalCount > startCount);
            Assert.Equal(1, finalCount);
        }
    }
}
