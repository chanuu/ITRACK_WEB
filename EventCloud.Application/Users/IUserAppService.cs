using System.Threading.Tasks;
using Abp.Application.Services;
using ITRACK.Users.Dto;

namespace ITRACK.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}