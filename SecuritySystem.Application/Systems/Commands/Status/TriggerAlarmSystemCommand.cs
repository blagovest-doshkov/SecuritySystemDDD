namespace SecuritySystem.Application.Systems.Commands.Status
{
    using Application.Common;
    using SecuritySystem.Domain.Systems.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class TriggerAlarmSystemCommand : EntityCommand<int>, IRequest<Result>
    {
        public class TriggerAlarmSystemCommandHandler : IRequestHandler<TriggerAlarmSystemCommand, Result>
        {
            private readonly IAlarmSystemDomainRepository alarmSystemDomainRepository;

            public TriggerAlarmSystemCommandHandler(
                IAlarmSystemDomainRepository alarmSystemDomainRepository)
            {
                this.alarmSystemDomainRepository = alarmSystemDomainRepository;
            }

            public async Task<Result> Handle(
                TriggerAlarmSystemCommand request, 
                CancellationToken cancellationToken)
            {
                var alarmSystem = await this.alarmSystemDomainRepository
                    .Find(request.Id, cancellationToken);

                alarmSystem.TriggerAlarm();

                await this.alarmSystemDomainRepository.Save(alarmSystem, cancellationToken);

                return Result.Success;
            }
        }
    }
}
