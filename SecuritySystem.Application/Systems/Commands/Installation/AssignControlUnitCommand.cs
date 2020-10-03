namespace SecuritySystem.Application.Systems.Commands.Installation
{
    using Application.Common;
    using Application.Systems.Commands.Common;
    using Domain.Systems.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    

    public class AssignControlUnitCommand : AlarmSystemCommand<AssignControlUnitCommand>, IRequest<Result>
    {
        public class AssignControlUnitCommandHandler : IRequestHandler<AssignControlUnitCommand, Result>
        {
            private readonly IAlarmSystemDomainRepository alarmSystemDomainRepository;

            public AssignControlUnitCommandHandler(
                IAlarmSystemDomainRepository alarmSystemDomainRepository)
            {
                this.alarmSystemDomainRepository = alarmSystemDomainRepository;
            }

            public async Task<Result> Handle(
                AssignControlUnitCommand request, 
                CancellationToken cancellationToken)
            {
                var alarmSystem = await this.alarmSystemDomainRepository
                    .Find(request.Id, cancellationToken);

                alarmSystem.AssignControlUnit(request.ControlUnitSerialNumber);

                await this.alarmSystemDomainRepository.Save(alarmSystem, cancellationToken);

                return Result.Success;
            }
        }
    }
}
