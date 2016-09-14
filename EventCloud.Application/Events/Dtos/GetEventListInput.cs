using Abp.Application.Services.Dto;

namespace ITRACK.Events.Dtos
{
    public class GetEventListInput : IInputDto
    {
        public bool IncludeCanceledEvents { get; set; }
    }
}