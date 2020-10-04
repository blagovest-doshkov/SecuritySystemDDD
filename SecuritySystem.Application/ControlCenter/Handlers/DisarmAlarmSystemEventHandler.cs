namespace SecuritySystem.Application.ControlCenter.Handlers
{
    using Application.Common;
    using Domain.ControlCenter.Repositories;
    using Domain.Systems.Events;
    using SecuritySystem.Domain.ControlCenter.Models;
    using System.Threading.Tasks;

    public class DisarmAlarmSystemEventHandler : IEventHandler<DisarmAlarmSystemEvent>
    {
        private readonly IAlarmEventDomainRepository alarmEventDomainRepository;

        public DisarmAlarmSystemEventHandler(
            IAlarmEventDomainRepository alarmEventDomainRepository)
        {
            this.alarmEventDomainRepository = alarmEventDomainRepository;
        }

        public async Task Handle(DisarmAlarmSystemEvent domainEvent)
        {
            var alarmEvent = await this.alarmEventDomainRepository.FidActiveEventByAlarmSystemId(domainEvent.AlarmSystemId);

            alarmEvent.UpdateState(AlarmEventState.Handled);

            await this.alarmEventDomainRepository.Save(alarmEvent);
        }
    }
}
