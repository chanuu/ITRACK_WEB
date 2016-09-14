using Abp.Application.Features;
using ITRACK.Authorization.Roles;
using ITRACK.MultiTenancy;
using ITRACK.Users;

namespace ITRACK.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}
