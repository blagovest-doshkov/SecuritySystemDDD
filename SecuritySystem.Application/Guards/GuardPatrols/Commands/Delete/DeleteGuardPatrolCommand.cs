namespace SecuritySystem.Application.Guards.GuardPatrols.Commands.Delete
{
    using MediatR;
    using SecuritySystem.Application.Common;
    using SecuritySystem.Domain.Guards.Repositories.GuardPatrol;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteGuardPatrolCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteGuardPatrolCommandHandler : IRequestHandler<DeleteGuardPatrolCommand, Result>
        {
            private readonly IGuardPatrolDomainRepository guardPatrolDomainRepository;

            public DeleteGuardPatrolCommandHandler(
                IGuardPatrolDomainRepository guardPatrolDomainRepository)
            {
                this.guardPatrolDomainRepository = guardPatrolDomainRepository;
            }

            public async Task<Result> Handle(
                DeleteGuardPatrolCommand request,
                CancellationToken cancellationToken)
            {
                return await this.guardPatrolDomainRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
