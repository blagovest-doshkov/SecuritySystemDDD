namespace SecuritySystem.Domain.Systems.Events
{
    using Common;
    public class AssignedPatrolEvent : IDomainEvent
    {
        internal AssignedPatrolEvent(
            string eventUniqueId,
            int guardPatrolId)
        {
            this.EventUniqueId = eventUniqueId;
            this.GuardPatrolId = guardPatrolId;
        }

        public string EventUniqueId { get; private set; }
        public int GuardPatrolId { get; private set; }
    }
}
