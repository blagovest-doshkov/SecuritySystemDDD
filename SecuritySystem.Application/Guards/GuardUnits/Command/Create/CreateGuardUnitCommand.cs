namespace SecuritySystem.Application.Guards.GuardUnits.Commands.Create
{
    using MediatR;
    using SecuritySystem.Application.Common.Contracts;
    using SecuritySystem.Domain.Guards.Factories;
    using SecuritySystem.Domain.Guards.Repositories.GuardUnit;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateGuardUnitCommand : IRequest<CreateGuardUnitOutputModel>
    {
        public string Name { get; set; } = default!;

        public class CreateGuardUnitCommandHandler : IRequestHandler<CreateGuardUnitCommand, CreateGuardUnitOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IGuardUnitDomainRepository guardUnitDomainRepository;
            private readonly IGuardUnitFactory guardUnitFactory;

            public CreateGuardUnitCommandHandler(
                ICurrentUser currentUser,
                IGuardUnitDomainRepository guardUnitDomainRepository,
                IGuardUnitFactory guardUnitFactory)
            {
                this.currentUser = currentUser;
                this.guardUnitDomainRepository = guardUnitDomainRepository;
                this.guardUnitFactory = guardUnitFactory;
            }

            public async Task<CreateGuardUnitOutputModel> Handle(
                CreateGuardUnitCommand request,
                CancellationToken cancellationToken)
            {
                var guardUnit = this.guardUnitFactory
                    .WithName(request.Name)
                    .WithUserId(this.currentUser.UserId)
                    .Build();

                await this.guardUnitDomainRepository.Save(guardUnit, cancellationToken);

                return new CreateGuardUnitOutputModel(guardUnit.Id);
            }

        }
    }
}
