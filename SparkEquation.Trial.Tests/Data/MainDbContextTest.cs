using Microsoft.EntityFrameworkCore;
using SparkEquation.Trial.WebAPI.Data;

namespace SparkEquation.Trial.Tests.Data
{
    internal class MainDbContextTest : MainDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("SpartEquation");
        }

        public override bool AreTransactionsSupported()
        {
            return false;
        }

    }
}
