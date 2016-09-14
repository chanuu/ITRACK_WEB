using Abp.Events.Bus.Entities;

namespace ITRACK.Events
{
    public class EventCancelledEvent : EntityEventData<Event>
    {
        public EventCancelledEvent(Event entity) 
            : base(entity)
        {
        }
    }
}