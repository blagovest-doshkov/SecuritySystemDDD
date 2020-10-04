namespace SecuritySystem.Application.ControlCenter.Handlers
{
    using Application.Common;
    using Domain.ControlCenter.Events;
    using Domain.Guards.Repositories.GuardPatrol;
    using System.Threading.Tasks;
    using SecuritySystem.Domain.Guards.Models;

    public class CloseAlarmEventHandler: IEventHandler<CloseAlarmEvent>
    {
        private readonly IGuardTaskDomainRepository guardTaskDomainRepository;

        public CloseAlarmEventHandler(
            IGuardTaskDomainRepository guardTaskDomainRepository)
        {
            this.guardTaskDomainRepository = guardTaskDomainRepository;
        }

        public async Task Handle(CloseAlarmEvent domainEvent)
        {
            var guardTask = await this.guardTaskDomainRepository.FindActiveTaskByEventId(domainEvent.EventId);

            guardTask.UpdateState(GuardTaskState.Handled);

            await this.guardTaskDomainRepository.Save(guardTask);
        }
    }
}
