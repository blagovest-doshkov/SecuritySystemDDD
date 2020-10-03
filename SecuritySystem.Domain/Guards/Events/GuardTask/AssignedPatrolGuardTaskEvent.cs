namespace SecuritySystem.Domain.Systems.Events
{
    using Common;
    public class AssignedPatrolGuardTaskEvent : IDomainEvent
    {
        internal AssignedPatrolGuardTaskEvent(
            int eventId,
            int guardPatrolId)
        {
            this.EventId = eventId;
            this.GuardPatrolId = guardPatrolId;
        }

        public int EventId { get; private set; }
        public int GuardPatrolId { get; private set; }
    }
}
