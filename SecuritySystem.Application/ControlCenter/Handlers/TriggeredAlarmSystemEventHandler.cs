namespace SecuritySystem.Application.ControlCenter.Handlers
{
    using Application.Common;
    using Domain.ControlCenter.Factories;
    using Domain.ControlCenter.Repositories;
    using Domain.Systems.Events;   
    using System.Threading.Tasks;

    public class TriggeredAlarmSystemEventHandler : IEventHandler<TriggeredAlarmSystemEvent>
    {
        private readonly IAlarmEventFactory alarmEventFactory;
        private readonly IAlarmEventDomainRepository alarmEventDomainRepository;

        public TriggeredAlarmSystemEventHandler(
            IAlarmEventFactory alarmEventFactory,
            IAlarmEventDomainRepository alarmEventDomainRepository)
        {
            this.alarmEventFactory = alarmEventFactory;
            this.alarmEventDomainRepository = alarmEventDomainRepository;
        }

        public async Task Handle(TriggeredAlarmSystemEvent domainEvent)
        {
            var alarmEvent = this.alarmEventFactory
                .WithSystemId(domainEvent.AlarmSystemId)
                .WithNotes(domainEvent.Notes)
                .WithContact(domainEvent.ContactName, domainEvent.ContactPhoneNumber)
                .WithAddress(domainEvent.City, domainEvent.Street, domainEvent.Latitude, domainEvent.longitude)
                .Build();

            await this.alarmEventDomainRepository.Save(alarmEvent);

            alarmEvent.RequestGuardAssignment();
        }
    }
}
