namespace SecuritySystem.Application.ControlCenter.Handlers
{
    using Application.Common;
    using Domain.ControlCenter.Repositories;
    using Domain.Systems.Events;
    using SecuritySystem.Domain.ControlCenter.Models;
    using System.Threading.Tasks;

    public class AssignedPatrolEventHandler: IEventHandler<AssignedPatrolEvent>
    {
        private readonly IAlarmEventDomainRepository alarmEventDomainRepository;

        public AssignedPatrolEventHandler(
            IAlarmEventDomainRepository alarmEventDomainRepository)
        {
            this.alarmEventDomainRepository = alarmEventDomainRepository;
        }

        public async Task Handle(AssignedPatrolEvent domainEvent)
        {
            var alarmEvent = await this.alarmEventDomainRepository.FindActiveEventByEventUniqueId(domainEvent.EventUniqueId);

            if(alarmEvent != null)
            { 
                alarmEvent.UpdateAssignedGuardId(domainEvent.GuardPatrolId);
                await this.alarmEventDomainRepository.Save(alarmEvent);
            }
        }
    }
}
