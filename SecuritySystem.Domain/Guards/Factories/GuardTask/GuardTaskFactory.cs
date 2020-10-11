namespace SecuritySystem.Domain.Guards.Factories
{
    using Models;
    using Common.Models;
    using Exceptions;
    using System;

    public class GuardTaskFactory : IGuardTaskFactory
    {
        private int EventId;
        private Address Address = default!;
        private DateTime EventDateTime;

        private bool AddressSet = false;

        public IGuardTaskFactory WithEventId(int eventId)
        {
            this.EventId = eventId;
            return this;
        }

        public IGuardTaskFactory WithEventDateTime(DateTime eventdatetime)
        {
            this.EventDateTime = eventdatetime;
            return this;
        }


        public IGuardTaskFactory WithAddress(Address address)
        {
            this.AddressSet = true;
            this.Address = address;
            return this;
        }

        public IGuardTaskFactory WithAddress(string city, string streetInfo, GeoCoordinates coordinates)
        {
            this.Address = new Address(city, streetInfo, coordinates);
            return this;
        }

        public IGuardTaskFactory WithAddress(string city, string streetInfo, double latitude, double longitude)
        {
            this.Address = new Address(city, streetInfo, new GeoCoordinates(latitude, longitude));
            return this;
        }

        public GuardTask Build()
        {
            if (!AddressSet)
            {
                throw new InvalidGuardTaskException("Address must have a value.");
            }

            return new GuardTask(EventId, Address, EventDateTime);
        }

    }

}
