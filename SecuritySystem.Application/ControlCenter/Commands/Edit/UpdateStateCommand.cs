namespace SecuritySystem.Application.ControlCenter.Commands.Installation
{
    using Application.Common;
    using MediatR;
    using Domain.ControlCenter.Repositories;
    using System.Threading;
    using System.Threading.Tasks;
    using SecuritySystem.Domain.ControlCenter.Models;
    using SecuritySystem.Domain.Common.Models;

    public class UpdateStateCommand : EntityCommand<int>, IRequest<Result>
    {
        public int State  { get; private set; } = default!;

        public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, Result>
        {
            private readonly IAlarmEventDomainRepository alarmEventDomainRepository;

            public UpdateStateCommandHandler(
                IAlarmEventDomainRepository alarmEventDomainRepository)
            {
                this.alarmEventDomainRepository = alarmEventDomainRepository;
            }

            public async Task<Result> Handle(
                UpdateStateCommand request, 
                CancellationToken cancellationToken)
            {
                var alarmEvent = await this.alarmEventDomainRepository
                    .Find(request.Id, cancellationToken);

                alarmEvent.UpdateState(Enumeration.FromValue<AlarmEventState>(request.State));

                await this.alarmEventDomainRepository.Save(alarmEvent, cancellationToken);

                return Result.Success;
            }
        }
    }
}
