using System.Data.Entity.Migrations;
using ITRACK.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace ITRACK.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ITRACK.EntityFramework.ITRACKDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ITRACK";
        }

        protected override void Seed(ITRACK.EntityFramework.ITRACKDbContext context)
        {
            context.DisableAllFilters();
            new InitialDataBuilder(context).Build();
        }
    }
}
