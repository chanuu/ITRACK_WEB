using Abp.Application.Services.Dto;

namespace ITRACK.Events.Dtos
{
    public class EventRegisterOutput : IOutputDto
    {
        public int RegistrationId { get; set; }
    }
}