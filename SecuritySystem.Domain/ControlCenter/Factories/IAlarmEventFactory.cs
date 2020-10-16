namespace SecuritySystem.Domain.ControlCenter.Factories
{
    using Common;
    using Common.Models;
    using Models;
    using System;

    public interface IAlarmEventFactory : IFactory<AlarmEvent>
    {
        IAlarmEventFactory WithSystemId(int systemId);

        IAlarmEventFactory WithEventUniqueId(string eventUniqueId);

        IAlarmEventFactory WithEventDateTime(DateTime eventDateTime);

        IAlarmEventFactory WithNotes(string notes);

        IAlarmEventFactory WithAddress(
            string city,
            string streetInfo,
            double latitude,
            double longitude);
        IAlarmEventFactory WithAddress(Address address);

        IAlarmEventFactory WithContact(string contactName, string contactPhoneNumber);

        IAlarmEventFactory WithContact(Contact contact);
    }

}
