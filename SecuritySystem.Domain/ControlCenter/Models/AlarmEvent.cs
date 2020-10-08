namespace SecuritySystem.Domain.ControlCenter.Models
{
    using Common;
    using Common.Models;
    using Exceptions;
    using SecuritySystem.Domain.ControlCenter.Events;
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

        public AlarmEvent RequestGuardAssignment()
        {
            this.RaiseEvent(new NewAlarmEvent(
                this.Id, 
                EventDateTime,
                Notes,
                Address.City,
                Address.StreetInfo,
                Address.Coordinates.Latitude,
                Address.Coordinates.Longitude));
            return this;
        }

        public AlarmEvent UpdateAssignedGuardId(int guardId)
        {
            this.AssignedGuardId = guardId;
            return this;
        }

        public AlarmEvent UpdateState(AlarmEventState state)
        {
            ValidateEventNotHandled();
            this.State = state;
            if (state == AlarmEventState.Handled)
            {
                this.RaiseEvent(new CloseAlarmEvent(this.Id));
            }
            return this;
        }

        public AlarmEvent UpdateNotes(string notes)
        {
            ValidateNotes(notes);
            this.Notes = notes;
            return this;
        }

        private void ValidateNotes(string notes)
        {
            Validator.StringLength<InvalidAlarmEventException>(notes, MinNotesLength, MaxNotesLength, nameof(this.Notes));
        }

        private void ValidateEventNotHandled()
        {
            if (this.State == AlarmEventState.Handled)
                throw new InvalidAlarmEventException($"AlarmEvent with ID:{this.Id} is already handled.");
        }
    }
}
