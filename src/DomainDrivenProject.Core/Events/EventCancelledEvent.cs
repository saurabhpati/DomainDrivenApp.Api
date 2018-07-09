using Abp.Events.Bus;

namespace DomainDrivenProject.Events
{
    public class EventCancelledEvent : EventData
    {
        private Event @event;

        public EventCancelledEvent(Event @event)
        {
            this.@event = @event;
        }
    }
}