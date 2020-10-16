namespace SecuritySystem.Domain.ControlCenter.Events
{
    using Common;
    public class CloseAlarmEvent : IDomainEvent
    {
        internal CloseAlarmEvent(
            string eventUniqueId)
        {
            this.EventUniqueId = eventUniqueId;
        }

        public string EventUniqueId { get; private set; }
    }
}
