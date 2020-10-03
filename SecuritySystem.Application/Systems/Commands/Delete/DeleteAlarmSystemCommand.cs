namespace SecuritySystem.Application.Systems.Commands.Delete
{
    using MediatR;
    using Application.Common;
    using Domain.Systems.Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteAlarmSystemCommand: EntityCommand<int>, IRequest<Result>
    {
        public class DeleteAlarmSystemCommandHandler : IRequestHandler<DeleteAlarmSystemCommand, Result>
        {
            private readonly IAlarmSystemDomainRepository alarmSystemDomainRepository;

            public DeleteAlarmSystemCommandHandler(
                IAlarmSystemDomainRepository alarmSystemDomainRepository)
            {
                this.alarmSystemDomainRepository = alarmSystemDomainRepository;
            }

            public async Task<Result> Handle(
                DeleteAlarmSystemCommand request,
                CancellationToken cancellationToken)
            {
                //Check if system is installed/InAlarm? 
                return await this.alarmSystemDomainRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
