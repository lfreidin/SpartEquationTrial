namespace SparkEquation.Trial.WebAPI.Data.Factory
{
    public class ContextFactory : IContextFactory
    {
        public MainDbContext GetContext()
        {
            return new MainDbContext();
        }
    }
}