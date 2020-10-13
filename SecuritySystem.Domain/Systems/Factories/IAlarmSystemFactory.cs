namespace SecuritySystem.Domain.Systems.Factories
{
    using Common;
    using Common.Models;
    using Models;

    public interface IAlarmSystemFactory : IFactory<AlarmSystem>
    {
        IAlarmSystemFactory WithUserId(string userId);
        IAlarmSystemFactory WithName(string name);

        IAlarmSystemFactory WithNotes(string notes);

        IAlarmSystemFactory WithAddress(Address address);

        IAlarmSystemFactory WithAddress(string country,
            string province,
            string city,
            string street,
            double latitude,
            double longitude);

        IAlarmSystemFactory WithContact(string contactName, string contactPhoneNumber);
        IAlarmSystemFactory WithContact(Contact contact);
    }
}
