namespace SecuritySystem.Domain.Guards.Factories
{
    using Models;
    using Common.Models;
    using Exceptions;
    using System;

    public class GuardTaskFactory : IGuardTaskFactory
    {
        private string EventUniqueId = default!;
        private Address Address = default!;
        private DateTime EventDateTime;

        private bool EventUniqueIdSet = false;
        private bool AddressSet = false;

        public IGuardTaskFactory WithEventUniqueId(string eventId)
        {
            this.EventUniqueIdSet = true;
            this.EventUniqueId = eventId;
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
            return WithAddress(new Address(city, streetInfo, coordinates));
        }

        public IGuardTaskFactory WithAddress(string city, string streetInfo, double latitude, double longitude)
        {
            return WithAddress(new Address(city, streetInfo, new GeoCoordinates(latitude, longitude)));
        }

        public GuardTask Build()
        {
            if (!AddressSet || !EventUniqueIdSet)
            {
                throw new InvalidGuardTaskException("Address must have a value.");
            }

            return new GuardTask(EventUniqueId, Address, EventDateTime);
        }

    }

}
