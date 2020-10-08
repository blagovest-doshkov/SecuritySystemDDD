namespace SecuritySystem.Application.Guards.GuardUnits.Commands.Delete
{
    using MediatR;
    using SecuritySystem.Application.Common;
    using SecuritySystem.Domain.Guards.Repositories.GuardUnit;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteGuardUnitCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteGuardUnitCommandHandler : IRequestHandler<DeleteGuardUnitCommand, Result>
        {
            private readonly IGuardUnitDomainRepository guardUnitDomainRepository;

            public DeleteGuardUnitCommandHandler(
                IGuardUnitDomainRepository guardUnitDomainRepository)
            {
                this.guardUnitDomainRepository = guardUnitDomainRepository;
            }

            public async Task<Result> Handle(
                DeleteGuardUnitCommand request,
                CancellationToken cancellationToken)
            {
                return await this.guardUnitDomainRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
