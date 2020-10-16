namespace SecuritySystem.Domain.ControlCenter.Factories
{
    using Common.Models;
    using Models;
    using SecuritySystem.Domain.ControlCenter.Exceptions;
    using System;

    public class AlarmEventFactory : IAlarmEventFactory
    {
        private int SystemId;
        private string EventUniqueId = default!;
        private DateTime EventDateTime;
        private string Notes = default!;
        private Address Address = default!;
        private Contact Contact = default!;

        private bool SystemIdSet = false;
        private bool NotesSet = false;
        private bool AddressSet = false;
        private bool ContactSet = false;
        private bool EventUniqueIdSet = false;
        private bool EventDateTimeSet = false;

        public IAlarmEventFactory WithSystemId(int systemId)
        {
            this.SystemIdSet = true;
            this.SystemId = systemId;
            return this;
        }

        public IAlarmEventFactory WithEventUniqueId(string eventUniqueId)
        {
            this.EventUniqueIdSet = true;
            this.EventUniqueId = eventUniqueId;
            return this;
        }

        public IAlarmEventFactory WithEventDateTime(DateTime eventDateTime)
        {
            this.EventDateTimeSet = true;
            this.EventDateTime = eventDateTime;
            return this;
        }

        public IAlarmEventFactory WithNotes(string notes)
        {
            this.NotesSet = true;
            this.Notes = notes;
            return this;
        }

        public IAlarmEventFactory WithAddress(
            string city,
            string streetInfo,
            double latitude,
            double longitude)
        {
            return WithAddress(new Address(
                city,
                streetInfo,
                new GeoCoordinates(latitude,longitude)));
        }

        public IAlarmEventFactory WithAddress(Address address)
        {
            this.AddressSet = true;
            this.Address = address;
            return this;
        }

        public IAlarmEventFactory WithContact(string contactName, string contactPhoneNumber)
        {
            return WithContact(new Contact(contactName, contactPhoneNumber));
        }

        public IAlarmEventFactory WithContact(Contact contact)
        {
            this.ContactSet = true;
            this.Contact = contact;
            return this;
        }

        public AlarmEvent Build()
        {
            if (!this.NotesSet || !this.AddressSet || !this.ContactSet || !this.SystemIdSet || !this.EventUniqueIdSet || !this.EventDateTimeSet)
            {
                throw new InvalidAlarmEventException("SystemId, Notes, Address and Contact must have a value.");
            }

            return new AlarmEvent(
                this.SystemId,
                this.EventUniqueId,
                this.EventDateTime,
                this.Notes,
                this.Address,
                this.Contact);
        }
    }

}
