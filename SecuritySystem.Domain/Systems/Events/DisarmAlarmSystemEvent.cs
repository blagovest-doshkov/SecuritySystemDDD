namespace SecuritySystem.Domain.Systems.Events
{
    using Common;
    public class DisarmAlarmSystemEvent : IDomainEvent
    {
        internal DisarmAlarmSystemEvent(
            int alarmSystemId)
        {
            this.AlarmSystemId = alarmSystemId;
        }

        public int AlarmSystemId { get; private set; }

    }
}
