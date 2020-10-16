namespace SecuritySystem.Domain.Systems.Events
{
    using Common;
    using System;

    public class TriggeredAlarmSystemEvent : IDomainEvent
    {
        internal TriggeredAlarmSystemEvent(
            int alarmSystemId, 
            DateTime eventDateTime,
            string notes,
            string contactName,
            string contactPhoneNumber,
            string city,
            string street,
            double latitude,
            double longitude)
        {
            this.AlarmSystemId = alarmSystemId;
            this.Notes = notes;
            this.ContactName = contactName;
            this.ContactPhoneNumber = contactPhoneNumber;
            this.City = city;
            this.Street = street;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.UniqueId = Guid.NewGuid().ToString();
            this.EventDateTime = eventDateTime;
        }

        public string UniqueId { get; private set; }
        public DateTime EventDateTime { get; private set; }
        public int AlarmSystemId { get; private set; }
        public string Notes { get; private set; }

        public string ContactName { get; private set; }
        public string ContactPhoneNumber { get; private set; }

        public string City { get; private set; }
        public string Street { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
