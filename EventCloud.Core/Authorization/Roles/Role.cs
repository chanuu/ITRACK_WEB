using Abp.Authorization.Roles;
using ITRACK.MultiTenancy;
using ITRACK.Users;

namespace ITRACK.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}