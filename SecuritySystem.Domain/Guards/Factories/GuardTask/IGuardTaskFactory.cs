namespace SecuritySystem.Domain.Guards.Factories
{
    using Common;
    using Common.Models;
    using Models;
    using System;

    public interface IGuardTaskFactory : IFactory<GuardTask>
    {
        IGuardTaskFactory WithEventId(int eventId);
        IGuardTaskFactory WithEventDateTime(DateTime eventdatetime);
        IGuardTaskFactory WithAddress(Address address);
        IGuardTaskFactory WithAddress(string city,
            string streetInfo,
            GeoCoordinates coordinates);
        IGuardTaskFactory WithAddress(string city,
            string streetInfo,
            double latitude,
            double longtitude);
    }

}
