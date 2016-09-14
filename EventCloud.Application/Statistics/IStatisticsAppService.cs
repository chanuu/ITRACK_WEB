using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace ITRACK.Statistics
{
    public interface IStatisticsAppService : IApplicationService
    {
        Task<ListResultOutput<NameValueDto>> GetStatistics();
    }
}