namespace SecuritySystem.Domain.Guards.Models
{
    using Common;
    using Common.Models;
    using Exceptions;
    using SecuritySystem.Domain.Systems.Events;
    using System;

    public class GuardTask:Entity<int>, IAggregateRoot
    {
        internal GuardTask(
            int eventId,
            Address address,
            DateTime eventDateTime
            )
        {
            ValidateEventId(eventId);

            this.GuardTaskDateTime = DateTime.UtcNow;
            this.State = GuardTaskState.InProgress;
            this.EventId = eventId;
            this.EventDateTime = eventDateTime;
            this.Address = address;
            this.AssignedPatrol = default!;            
        }

        public int EventId { get; private set; }
        public GuardTaskState State { get; private set; }
        public GuardPatrol AssignedPatrol { get; private set; }
        public Address Address { get; private set; }
        public DateTime EventDateTime { get; private set; }
        public DateTime GuardTaskDateTime { get; private set; }
        
        //public DateTime? PatrolAssignedDateTime { get; private set; }
        // logs/history (ex. "Pending Patrol assignment", "Patrol Arrived", "Calling Police" etc

        public GuardTask AssignGuardPatrol(GuardPatrol guard)
        {
            ValidateGuardPatrol(guard);
            this.AssignedPatrol = guard;
            this.AssignedPatrol.SetAvailabilityTo(false);
            //Trigger Event
            this.RaiseEvent(new AssignedPatrolEvent(this.EventId, guard.Id));
            return this;
        }

        public GuardTask UpdateState(GuardTaskState state)
        {
            this.State = state;
            if (state == GuardTaskState.Handled)
            {
                this.AssignedPatrol.SetAvailabilityTo(true);
            }
            return this;
        }

        //Validations
        private void ValidateEventId(int eventId)
        {
            Validator.NonNegative<InvalidGuardTaskException>(eventId, nameof(this.EventId));
        }

        private void ValidateGuardPatrol(GuardPatrol guard)
        {
            Validator.IsNotNull<AssigningGuardPatrolException>(guard, nameof(this.AssignedPatrol));
            if (!guard.IsAvailable)
            {
                throw new AssigningGuardPatrolException($"Guard with ID='{guard.Id}' is not available for signing Task with ID='{this.Id}'");
            }
        }
    }
}
