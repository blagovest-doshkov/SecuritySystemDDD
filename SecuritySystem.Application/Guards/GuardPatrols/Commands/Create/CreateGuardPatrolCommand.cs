namespace SecuritySystem.Application.Guards.GuardPatrols.Commands.Create
{
    using MediatR;
    using SecuritySystem.Domain.Guards.Factories;
    using SecuritySystem.Domain.Guards.Repositories.GuardPatrol;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateGuardPatrolCommand: IRequest<CreateGuardPatrolOutputModel>
    {
        public class CreateGuardPatrolCommandHandler : IRequestHandler<CreateGuardPatrolCommand, CreateGuardPatrolOutputModel>
        {
            private readonly IGuardPatrolDomainRepository guardPatrolDomainRepository;
            private readonly IGuardPatrolFactory guardPatrolFactory;

            public CreateGuardPatrolCommandHandler(
                IGuardPatrolDomainRepository guardPatrolDomainRepository,
                IGuardPatrolFactory guardPatrolFactory)
            {
                this.guardPatrolDomainRepository = guardPatrolDomainRepository;
                this.guardPatrolFactory = guardPatrolFactory;
            }

            public async Task<CreateGuardPatrolOutputModel> Handle(
                CreateGuardPatrolCommand request,
                CancellationToken cancellationToken)
            {
                var guardPatrol = this.guardPatrolFactory.Build();

                await this.guardPatrolDomainRepository.Save(guardPatrol, cancellationToken);

                return new CreateGuardPatrolOutputModel(guardPatrol.Id);
            }

        }
    }
}
