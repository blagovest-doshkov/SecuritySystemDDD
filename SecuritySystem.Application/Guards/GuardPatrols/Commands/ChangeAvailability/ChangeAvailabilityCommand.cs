namespace SecuritySystem.Application.Guards.GuardPatrols.Commands.ChangeAvailability
{
    using MediatR;
    using SecuritySystem.Application.Common;
    using SecuritySystem.Domain.Guards.Repositories.GuardPatrol;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChangeAvailabilityCommand: EntityCommand<int>, IRequest<Result>
    {
        public bool isAvailable { get; set; }
        public class ChangeAvailabilityCommandHandler : IRequestHandler<ChangeAvailabilityCommand, Result>
        {
            private readonly IGuardPatrolDomainRepository guardPatrolDomainRepository;

            public ChangeAvailabilityCommandHandler(
                IGuardPatrolDomainRepository guardPatrolDomainRepository)
            {
                this.guardPatrolDomainRepository = guardPatrolDomainRepository;
            }

            public async Task<Result> Handle(
                ChangeAvailabilityCommand request,
                CancellationToken cancellationToken)
            {
                //Check if the guard User is assigned to this patrol and ETC
                var guardPatrol = await this.guardPatrolDomainRepository.Find(request.Id, cancellationToken);
                guardPatrol.SetAvailabilityTo(request.isAvailable);
                await this.guardPatrolDomainRepository.Save(guardPatrol, cancellationToken);

                return Result.Success;
            }
        }
    }
}
