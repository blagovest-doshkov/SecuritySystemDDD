namespace SecuritySystem.Domain.Systems.Factories
{
    using Common.Models;
    using Models;
    using Exceptions;

    public class AlarmSystemFactory : IAlarmSystemFactory
    {
        private string OwnerId = default!;
        private string Name = default!;
        private string Notes = default!;
        private Address Address = default!;
        private Contact ContactsInfo = default!;

        private bool NameSet = false;
        private bool NotesSet = false;
        private bool AddressSet = false;
        private bool OwnerIdSet = false;
        private bool ContactsInfoSet = false;

        public IAlarmSystemFactory WithUserId(string userId)
        {
            this.OwnerIdSet = true;
            this.OwnerId = userId;
            return this;
        }
        public IAlarmSystemFactory WithName(string name)
        {
            this.NameSet = true;
            this.Name = name;
            return this;
        }

        public IAlarmSystemFactory WithNotes(string notes)
        {
            this.NotesSet = true;
            this.Notes = notes;
            return this;
        }

        public IAlarmSystemFactory WithAddress(Address address)
        {
            this.AddressSet = true;
            this.Address = address;
            return this;
        }

        public IAlarmSystemFactory WithAddress(
            string country,
            string province,
            string city,
            string street,
            double latitude,
            double longitude)
        {
            return WithAddress(new Address(
                country,
                province,
                city,
                street,
                new GeoCoordinates(latitude,longitude)
                ));
        }

        public IAlarmSystemFactory WithContact(string contactName, string contactPhoneNumber)
        {
            return WithContact(new Contact(contactName, contactPhoneNumber));
        }

        public IAlarmSystemFactory WithContact(Contact contact)
        {
            this.ContactsInfoSet = true;
            this.ContactsInfo = contact;
            return this;
        }

        public AlarmSystem Build()
        {
            if (!this.NotesSet || !this.AddressSet || !this.NameSet || !this.OwnerIdSet || !this.ContactsInfoSet)
            {
                throw new InvalidAlarmSystemException("SystemId, Notes, Address and Contact must have a value.");
            }

            return new AlarmSystem(
                this.OwnerId,
                this.Name,
                this.Notes,
                this.Address,
                this.ContactsInfo);
        }
    }
}
