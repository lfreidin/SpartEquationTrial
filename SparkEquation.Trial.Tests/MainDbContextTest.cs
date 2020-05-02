using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SparkEquation.Trial.WebAPI.Controllers;
using SparkEquation.Trial.WebAPI.Data;
using SparkEquation.Trial.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SparkEquation.Trial.Tests
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
