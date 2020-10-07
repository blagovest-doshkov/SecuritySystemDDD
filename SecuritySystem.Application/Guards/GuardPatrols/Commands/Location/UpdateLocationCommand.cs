namespace SecuritySystem.Application.Guards.GuardPatrols.Commands.Location
{
    using MediatR;
    using SecuritySystem.Application.Common;
    using SecuritySystem.Domain.Guards.Repositories.GuardPatrol;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateLocationCommand: EntityCommand<int>, IRequest<Result>
    {
        public double latitude { get; set; }
        public double longtitude { get; set; }

        public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Result>
        {
            private readonly IGuardPatrolDomainRepository guardPatrolDomainRepository;

            public UpdateLocationCommandHandler(
                IGuardPatrolDomainRepository guardPatrolDomainRepository)
            {
                this.guardPatrolDomainRepository = guardPatrolDomainRepository;
            }

            public async Task<Result> Handle(
                UpdateLocationCommand request,
                CancellationToken cancellationToken)
            {

                var guardPatrol = await this.guardPatrolDomainRepository.Find(request.Id, cancellationToken);

                guardPatrol.UpdateLocation(request.latitude, request.longtitude);

                await this.guardPatrolDomainRepository.Save(guardPatrol, cancellationToken);

                return Result.Success;
            }
        }
    }
}
