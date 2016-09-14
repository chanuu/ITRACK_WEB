using Abp.Authorization;
using ITRACK.Authorization.Roles;
using ITRACK.MultiTenancy;
using ITRACK.Users;

namespace ITRACK.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
