namespace SecuritySystem.Domain.Systems.Models
{
    using Common;
    using Common.Models;
    using Exceptions;
    using Microsoft.VisualBasic.CompilerServices;
    using SecuritySystem.Domain.Systems.Events;
    using static ModelConstants.AlarmSystem;

    public class AlarmSystem : Entity<int>, IAggregateRoot
    {
        internal AlarmSystem(
            int userId,
            string name,
            string notes,
            Address address,
            Contact contactsInfo
           )
        {
            Validate(userId, name, notes);

            //Meta
            this.Name = name;
            this.Notes = notes;
            this.Address = address;
            this.OwnerId = userId;
            this.ContactsInfo = contactsInfo;

            //Installtion
            //this.UniqueId = uniqueId; // Guid.NewGuid().ToString();
            this.IsInstalled = false;
            this.IsInConfiguration = false;
            this.ControlUnitSerialNumber = default!;

            //Status
            this.IsArmed = false;
            this.AlarmTriggered = false;

            //this.zones = new HashSet<Zone>();
        }

        //Status Properties
        public bool IsArmed { get; private set; }
        public bool AlarmTriggered { get; private set; }

        //Installation Properties
        public bool IsInConfiguration { get; private set; }
        public bool IsInstalled { get; private set; }
        public string ControlUnitSerialNumber { get; private set; }
        //public string UniqueId { get; private set; }

        //META
        public string Name { get; private set; }
        public string Notes { get; private set; }
        public Address Address { get; private set; }
        public int OwnerId { get; private set; }
        public Contact ContactsInfo { get; private set; }

        public AlarmSystem UpdateName(string name)
        {
            this.Name = name;
            return this;
        }
        public AlarmSystem UpdateNotes(string notes)
        {
            this.Notes = notes;
            return this;
        }
        public AlarmSystem UpdateAddress(
            string country,
            string province,
            string city,
            string street,
            double latitude,
            double longtitude)
        {
            this.Address.UpdateCountry(country);
            this.Address.UpdateProvince(province);
            this.Address.UpdateCity(city);
            this.Address.UpdateStreet(street);
            this.Address.UpdateCoordinates(latitude, longtitude);
            return this;
        }
        public AlarmSystem UpdateAddress(Address address)
        {
            this.Address.UpdateCountry(address.Country);
            this.Address.UpdateProvince(address.Province);
            this.Address.UpdateCity(address.City);
            this.Address.UpdateStreet(address.Street);
            this.Address.UpdateCoordinates(address.Coordinates);
            return this;
        }
        public AlarmSystem UpdateContactsInfo(Contact contact)
        {
            this.ContactsInfo = contact;
            return this;
        }
        public AlarmSystem UpdateContactsInfo(string contactName, string contactPhoneNumber)
        {
            return UpdateContactsInfo( new Contact(contactName,contactPhoneNumber));
        }


        public AlarmSystem InitiateConfigurationMode()
        {
            ValidateNotInConfigurationMode();

            this.IsInConfiguration = true;
            return this;
        }
        public AlarmSystem CompleteConfigurationMode()
        {
            ValidateInConfigurationMode();

            this.IsInConfiguration = false;
            return this;
        }
        public AlarmSystem AssignControlUnit(string serialNumber)
        {
            ValidateInConfigurationMode();
            ValidateControlUnitSerialNumber(serialNumber);
            this.ControlUnitSerialNumber = serialNumber;
            return this;
        }
        public AlarmSystem CompleteInstallation()
        {
            ValidateInConfigurationMode();
            ValidateControlUnitSerialNumber(this.ControlUnitSerialNumber);
            this.IsInstalled = true;
            //Authorization KEy?
            return this;
        }

        public AlarmSystem Arm()
        {
            if(!this.IsArmed)
            { 
                this.IsArmed = true;
            }
            return this;
        }
        public AlarmSystem Disarm()
        {
            this.IsArmed = false;
            ClearAlarm();
            return this;
        }
        public AlarmSystem TriggerAlarm()
        {
            ValidateAlarmNotTriggered();
            if (!this.AlarmTriggered)
            { 
                this.Arm();
                this.AlarmTriggered = true;
                this.RaiseEvent(new TriggeredAlarmSystemEvent(
                    this.Id, 
                    this.Notes,
                    this.ContactsInfo.Name,
                    this.ContactsInfo.PhoneNumber,
                    this.Address.City,
                    this.Address.Street,
                    this.Address.Coordinates.Latitude,
                    this.Address.Coordinates.Longitude));
            }

            return this;
        }
        public AlarmSystem ClearAlarm()
        {
            if (this.AlarmTriggered)
            {
                this.AlarmTriggered = false;
                this.RaiseEvent(new DisarmAlarmSystemEvent(this.Id));
            }
            return this;
        }

        //public IReadOnlyCollection<Zone> Zones => this.zones.ToList().AsReadOnly();

        //public void AddZone(Zone zone)
        //{
        //    ValidateInConfigurationMode();
        //    this.zones.Add(zone);
        //}

        private void Validate(int userId, string name, string notes)
        {
            ValidateUserId(userId);
            ValidateName(name);
            //ValidateAddress(address);
            //ValidateUniqueId(uniqueId);
            ValidateNotes(notes);
        }
        //private void ValidateAddress(Address address)
        //{
        //    Validator.IsNotNull<InvalidAlarmSystemException>(address, nameof(this.Address));
        //}
        private void ValidateUserId(int userId)
        {
            Validator.NonNegative<InvalidAlarmSystemException>(userId, nameof(this.OwnerId));
        }
        private void ValidateNotes(string notes)
        {
            Validator.StringLength<InvalidAlarmSystemException>(
                notes,
                MinNotesLength,
                MaxNotesLength,
                nameof(this.Notes));
        }

        private void ValidateName(string name)
        {
            Validator.StringLength<InvalidAlarmSystemException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
        }

        //private void ValidateUniqueId(string uniqueId)
        //{
        //    Validator.StringNotEmpty<InvalidAlarmSystemException>(uniqueId, nameof(this.UniqueId));
        //}

        private void ValidateControlUnitSerialNumber(string serialNumber)
        {
            Validator.StringNotEmpty<InvalidAlarmSystemException>(serialNumber, nameof(this.ControlUnitSerialNumber));
        }
        private void ValidateInConfigurationMode()
        {
            if (!this.IsInConfiguration)
            {
                throw new InvalidAlarmSystemException($"System with ID:{this.Id} is not in ConfigurationMode.");
            }
        }
        private void ValidateNotInConfigurationMode()
        {
            if (this.IsInConfiguration)
            {
                throw new InvalidAlarmSystemException($"System with ID:{this.Id} is in ConfigurationMode.");
            }
        }
        private void ValidateIsInstalled()
        {
            if (this.IsInstalled)
            {
                throw new InvalidAlarmSystemException($"System with ID:{this.Id} is not installed.");
            }
        }

        private void ValidateAlarmNotTriggered()
        {
            if (this.AlarmTriggered)
            {
                throw new InvalidAlarmSystemException($"System with ID:{this.Id} is already triggered");
            }
        }
    }
}
