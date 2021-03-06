﻿namespace SecuritySystem.Domain.ControlCenter.Events
{
    using Common;
    using System;

    public class NewAlarmEvent : IDomainEvent
    {
        internal NewAlarmEvent(
            int eventId,
            DateTime eventDateTime,
            string notes,
            string city,
            string street,
            double latitude,
            double longitude
            )
        {
            this.EventId = eventId;
            this.EventDateTime = eventDateTime;
            this.Notes = notes;

            this.City = city;
            this.Street = street;
            this.Latitude = latitude;
            this.longitude = longitude;
        }

        public int EventId { get; private set; }
        public DateTime EventDateTime { get; private set; }
        public string Notes { get; private set; }

        public string City { get; private set; }
        public string Street { get; private set; }
        public double Latitude { get; private set; }
        public double longitude { get; private set; }

        
    }
}
