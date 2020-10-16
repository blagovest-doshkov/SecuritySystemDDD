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
            string eventUniqueId,
            Address address,
            DateTime eventDateTime
            )
        {
            ValidateEventId(eventUniqueId);

            this.GuardTaskDateTime = DateTime.UtcNow;
            this.State = GuardTaskState.InProgress;
            this.EventUniqueId = eventUniqueId;
            this.EventDateTime = eventDateTime;
            this.Address = address;
            this.AssignedPatrol = default!;            
        }

        //EF workaround for migrations
        internal GuardTask(
            string eventUniqueId,
            DateTime eventDateTime
            )
        {
            this.GuardTaskDateTime = DateTime.UtcNow;
            this.State = GuardTaskState.InProgress;
            this.EventUniqueId = eventUniqueId;
            this.EventDateTime = eventDateTime;
            this.Address = default!;
            this.AssignedPatrol = default!;
        }

        public string EventUniqueId { get; private set; }
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
            this.RaiseEvent(new AssignedPatrolEvent(this.EventUniqueId, guard.Id));
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
        private void ValidateEventId(string eventId)
        {
            Validator.StringNotEmpty<InvalidGuardTaskException>(eventId, nameof(this.EventUniqueId));
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
