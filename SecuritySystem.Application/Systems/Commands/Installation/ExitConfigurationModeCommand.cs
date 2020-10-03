namespace SecuritySystem.Application.Systems.Commands.Installation
{
    using Application.Common;
    using SecuritySystem.Domain.Systems.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ExitConfigurationModeCommand : EntityCommand<int>, IRequest<Result>
    {
        public class ExitConfigurationModeCommandHandler : IRequestHandler<ExitConfigurationModeCommand, Result>
        {
            private readonly IAlarmSystemDomainRepository alarmSystemDomainRepository;

            public ExitConfigurationModeCommandHandler(
                IAlarmSystemDomainRepository alarmSystemDomainRepository)
            {
                this.alarmSystemDomainRepository = alarmSystemDomainRepository;
            }

            public async Task<Result> Handle(
                ExitConfigurationModeCommand request, 
                CancellationToken cancellationToken)
            {
                var alarmSystem = await this.alarmSystemDomainRepository
                    .Find(request.Id, cancellationToken);

                alarmSystem.CompleteConfigurationMode();

                await this.alarmSystemDomainRepository.Save(alarmSystem, cancellationToken);

                return Result.Success;
            }
        }
    }
}
