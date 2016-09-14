using Abp.MultiTenancy;
using ITRACK.Authorization.Roles;
using ITRACK.Editions;
using ITRACK.Users;

namespace ITRACK.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(EditionManager editionManager)
            : base(editionManager)
        {

        }
    }
}