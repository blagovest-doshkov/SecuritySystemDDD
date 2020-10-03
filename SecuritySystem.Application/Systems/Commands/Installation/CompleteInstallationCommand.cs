namespace SecuritySystem.Application.Systems.Commands.Installation
{
    using Application.Common;
    using SecuritySystem.Domain.Systems.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CompleteInstallationCommand : EntityCommand<int>, IRequest<Result>
    {
        public class CompleteInstallationCommandHandler : IRequestHandler<CompleteInstallationCommand, Result>
        {
            private readonly IAlarmSystemDomainRepository alarmSystemDomainRepository;

            public CompleteInstallationCommandHandler(
                IAlarmSystemDomainRepository alarmSystemDomainRepository)
            {
                this.alarmSystemDomainRepository = alarmSystemDomainRepository;
            }

            public async Task<Result> Handle(
                CompleteInstallationCommand request, 
                CancellationToken cancellationToken)
            {
                var alarmSystem = await this.alarmSystemDomainRepository
                    .Find(request.Id, cancellationToken);

                alarmSystem.CompleteInstallation();

                await this.alarmSystemDomainRepository.Save(alarmSystem, cancellationToken);

                return Result.Success;
            }
        }
    }
}
