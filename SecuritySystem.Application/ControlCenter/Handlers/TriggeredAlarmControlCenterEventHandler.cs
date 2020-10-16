namespace SecuritySystem.Application.ControlCenter.Handlers
{
    using Application.Common;
    using Domain.ControlCenter.Factories;
    using Domain.ControlCenter.Repositories;
    using Domain.Systems.Events;   
    using System.Threading.Tasks;

    public class TriggeredAlarmControlCenterEventHandler : IEventHandler<TriggeredAlarmSystemEvent>
    {
        private readonly IAlarmEventFactory alarmEventFactory;
        private readonly IAlarmEventDomainRepository alarmEventDomainRepository;

        public TriggeredAlarmControlCenterEventHandler(
            IAlarmEventFactory alarmEventFactory,
            IAlarmEventDomainRepository alarmEventDomainRepository)
        {
            this.alarmEventFactory = alarmEventFactory;
            this.alarmEventDomainRepository = alarmEventDomainRepository;
        }

        public async Task Handle(TriggeredAlarmSystemEvent domainEvent)
        {
            var alarmEvent = this.alarmEventFactory
                .WithEventUniqueId(domainEvent.UniqueId)
                .WithEventDateTime(domainEvent.EventDateTime)
                .WithSystemId(domainEvent.AlarmSystemId)
                .WithNotes(domainEvent.Notes)
                .WithContact(domainEvent.ContactName, domainEvent.ContactPhoneNumber)
                .WithAddress(domainEvent.City, domainEvent.Street, domainEvent.Latitude, domainEvent.Longitude)
                .Build();

            await this.alarmEventDomainRepository.Save(alarmEvent);
        }
    }
}
