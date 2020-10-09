namespace SecuritySystem.Application.ControlCenter.Handlers
{
    using Application.Common;
    using Domain.ControlCenter.Events;
    using Domain.Guards.Repositories.GuardPatrol;
    using Domain.Guards.Models;
    using Domain.Guards.Factories;
    using System.Threading.Tasks;
    using SecuritySystem.Domain.Guards.Specifications;
    using SecuritySystem.Application.Guards.GuardPatrols.Queries;
    using SecuritySystem.Domain.Guards.Services;

    public class NewAlarmEventHandler: IEventHandler<NewAlarmEvent>
    {
        private readonly IGuardTaskFactory guardTaskDomainFactory;
        private readonly IGuardTaskDomainRepository guardTaskDomainRepository;
        private readonly IGuardPatrolQueryRepository guardPatrolQueryRepository;
        private readonly ILocationGuardPatrolService locationGuardPatrolService;

        public NewAlarmEventHandler(
            IGuardTaskFactory guardTaskDomainFactory,
            IGuardTaskDomainRepository guardTaskDomainRepository,
            IGuardPatrolQueryRepository guardPatrolQueryRepository,
            ILocationGuardPatrolService locationGuardPatrolService)
        {
            this.guardTaskDomainFactory = guardTaskDomainFactory;
            this.guardTaskDomainRepository = guardTaskDomainRepository;
            this.guardPatrolQueryRepository = guardPatrolQueryRepository;
            this.locationGuardPatrolService = locationGuardPatrolService;
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

            var availablePatrols = await this.guardPatrolQueryRepository.GetGuardPatrolListings(new GuardPatrolOnlyAvailableSpecification(true));
            var nearestPatrol = await this.locationGuardPatrolService.FindNearestPatrol(guardTask.Address.Coordinates, availablePatrols);

            guardTask.AssignGuardPatrol(nearestPatrol);
            await this.guardTaskDomainRepository.Save(guardTask);
        }
    }
}
