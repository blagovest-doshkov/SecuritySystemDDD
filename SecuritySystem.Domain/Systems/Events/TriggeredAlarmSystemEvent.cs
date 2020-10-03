namespace SecuritySystem.Domain.Systems.Events
{
    using Common;
    public class TriggeredAlarmSystemEvent : IDomainEvent
    {
        internal TriggeredAlarmSystemEvent(
            int alarmSystemId, 
            string notes,
            string contactName,
            string contactPhoneNumber,
            string city,
            string street,
            double latitude,
            double longtitude)
        {
            this.AlarmSystemId = alarmSystemId;
            this.Notes = notes;
            this.ContactName = contactName;
            this.ContactPhoneNumber = contactPhoneNumber;
            this.City = city;
            this.Street = street;
            this.Latitude = latitude;
            this.Longtitude = longtitude;
        }

        public int AlarmSystemId { get; private set; }
        public string Notes { get; private set; }

        public string ContactName { get; private set; }
        public string ContactPhoneNumber { get; private set; }

        public string City { get; private set; }
        public string Street { get; private set; }
        public double Latitude { get; private set; }
        public double Longtitude { get; private set; }
    }
}
