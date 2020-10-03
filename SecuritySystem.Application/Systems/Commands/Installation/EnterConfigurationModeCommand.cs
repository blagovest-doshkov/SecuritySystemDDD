namespace SecuritySystem.Application.Systems.Commands.Installation
{
    using Application.Common;
    using SecuritySystem.Domain.Systems.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class EnterConfigurationModeCommand : EntityCommand<int>, IRequest<Result>
    {
        public class EnterConfigurationModeCommandHandler : IRequestHandler<EnterConfigurationModeCommand, Result>
        {
            private readonly IAlarmSystemDomainRepository alarmSystemDomainRepository;

            public EnterConfigurationModeCommandHandler(
                IAlarmSystemDomainRepository alarmSystemDomainRepository)
            {
                this.alarmSystemDomainRepository = alarmSystemDomainRepository;
            }

            public async Task<Result> Handle(
                EnterConfigurationModeCommand request, 
                CancellationToken cancellationToken)
            {
                var alarmSystem = await this.alarmSystemDomainRepository
                    .Find(request.Id, cancellationToken);

                alarmSystem.InitiateConfigurationMode();

                await this.alarmSystemDomainRepository.Save(alarmSystem, cancellationToken);

                return Result.Success;
            }
        }
    }
}
