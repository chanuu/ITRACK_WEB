using System.Threading.Tasks;
using Abp.Application.Services;
using ITRACK.Roles.Dto;

namespace ITRACK.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
