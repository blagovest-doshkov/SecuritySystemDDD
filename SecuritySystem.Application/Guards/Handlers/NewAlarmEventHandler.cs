namespace SecuritySystem.Application.ControlCenter.Handlers
{
    using Application.Common;
    using Application.Guards.GuardTasks.Services;
    using Application.Guards.Querries;
    using Domain.ControlCenter.Events;
    using Domain.Guards.Repositories.GuardPatrol;
    using Domain.Guards.Models;
    using Domain.Guards.Factories;
    using System.Threading.Tasks;
    using SecuritySystem.Domain.Guards.Specifications;

    public class NewAlarmEventHandler: IEventHandler<NewAlarmEvent>
    {
        private readonly IGuardTaskFactory guardTaskDomainFactory;
        private readonly IGuardTaskDomainRepository guardTaskDomainRepository;
        private readonly IGuardPatrolQueryRepository guardPatrolQueryRepository;
        private readonly IGuardPatrolLocationService guardPatrolLocationService;

        public NewAlarmEventHandler(
            IGuardTaskFactory guardTaskDomainFactory,
            IGuardTaskDomainRepository guardTaskDomainRepository,
            IGuardPatrolQueryRepository guardPatrolQueryRepository,
            IGuardPatrolLocationService guardPatrolLocationService)
        {
            this.guardTaskDomainFactory = guardTaskDomainFactory;
            this.guardTaskDomainRepository = guardTaskDomainRepository;
            this.guardPatrolQueryRepository = guardPatrolQueryRepository;
            this.guardPatrolLocationService = guardPatrolLocationService;
        }

        public async Task Handle(NewAlarmEvent domainEvent)
        {
            var guardTask = this.guardTaskDomainFactory
                .WithEventId(domainEvent.EventId)
                .WithEventDateTime(domainEvent.EventDateTime)
                .WithAddress(
                    domainEvent.City,
                    domainEvent.Street,
                    domainEvent.Latitude,
                    domainEvent.Longtitude)
                .Build();

            await this.guardTaskDomainRepository.Save(guardTask); //In order ID to be generated in DB should be tested without this line

            var availablePatrols = await this.guardPatrolQueryRepository.GetGuardPatrolListings<GuardPatrol>(new GuardPatrolOnlyAvailableSpecification(true));
            var nearestPatrol = await this.guardPatrolLocationService.DeterminateClosestGuardPatrol(availablePatrols, guardTask.Address.Coordinates);

            guardTask.AssignGuardPatrol(nearestPatrol);
            await this.guardTaskDomainRepository.Save(guardTask);
        }
    }
}
