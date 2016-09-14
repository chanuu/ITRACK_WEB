using ITRACK.EntityFramework;

namespace ITRACK.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly ITRACKDbContext _context;

        public InitialDataBuilder(ITRACKDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            new DefaultTenantRoleAndUserBuilder(_context).Build();
        }
    }
}
