namespace SecuritySystem.Domain.ControlCenter.Events
{
    using Common;
    public class CloseAlarmEvent : IDomainEvent
    {
        internal CloseAlarmEvent(
            int eventId)
        {
            this.EventId = eventId;
        }

        public int EventId { get; private set; }
    }
}
