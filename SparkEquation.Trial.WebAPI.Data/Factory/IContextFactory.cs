namespace SparkEquation.Trial.WebAPI.Data.Factory
{
    public interface IContextFactory
    {
        MainDbContext GetContext();
    }
}