using Abp.MultiTenancy;
using ITRACK.Users;

namespace ITRACK.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {

    }
}