namespace SecuritySystem.Domain.ControlCenter.Models
{
    using Common;
    using Common.Models;
    using Exceptions;
    using System;
    using static ModelConstants.AlarmEvent;

    public class AlarmEvent: Entity<int>, IAggregateRoot
    {
        internal AlarmEvent(
            int systemId,
            string notes,
            Address address,
            Contact contact)
        {
            ValidateNotes(notes);

            this.SystemId = systemId;
            this.Notes = notes;
            this.Address = address;
            this.Contact = contact;
            this.EventDateTime = DateTime.UtcNow;
            this.AssignedGuardId = default!;
            this.State = AlarmEventState.InProgress;
        }

        public int SystemId { get; private set; }
        public string Notes { get; private set; }
        public Address Address { get; private set; }
        public Contact Contact { get; private set; }
        public DateTime EventDateTime { get; private set; }
        public AlarmEventState State { get; private set; }
        public int? AssignedGuardId { get; private set; }

        public AlarmEvent UpdateAssignedGuardId(int guardId)
        {
            this.AssignedGuardId = guardId;
            return this;
        }

        public AlarmEvent UpdateState(AlarmEventState state)
        {
            this.State = state;
            return this;
        }

        private void ValidateNotes(string notes)
        {
            Validator.StringLength<InvalidAlarmEventException>(notes, MinNotesLength, MaxNotesLength, nameof(this.Notes));
        }
    }
}
