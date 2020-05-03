using SparkEquation.Trial.WebAPI.Data;
using SparkEquation.Trial.WebAPI.Data.Factory;

namespace SparkEquation.Trial.Tests.Data
{
    public class TestContextFactory : IContextFactory
    {
        public MainDbContext GetContext()
        {
            var context = new MainDbContextTest();
            context.Database.EnsureCreated();
            return context;
        }
    }
}
