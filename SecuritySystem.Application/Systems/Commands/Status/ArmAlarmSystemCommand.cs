namespace SecuritySystem.Application.Systems.Commands.Status
{
    using Application.Common;
    using SecuritySystem.Domain.Systems.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ArmAlarmSystemCommand : EntityCommand<int>, IRequest<Result>
    {
        public class ArmAlarmSystemCommandHandler : IRequestHandler<ArmAlarmSystemCommand, Result>
        {
            private readonly IAlarmSystemDomainRepository alarmSystemDomainRepository;

            public ArmAlarmSystemCommandHandler(
                IAlarmSystemDomainRepository alarmSystemDomainRepository)
            {
                this.alarmSystemDomainRepository = alarmSystemDomainRepository;
            }

            public async Task<Result> Handle(
                ArmAlarmSystemCommand request, 
                CancellationToken cancellationToken)
            {
                var alarmSystem = await this.alarmSystemDomainRepository
                    .Find(request.Id, cancellationToken);

                alarmSystem.Arm();

                await this.alarmSystemDomainRepository.Save(alarmSystem, cancellationToken);

                return Result.Success;
            }
        }
    }
}
