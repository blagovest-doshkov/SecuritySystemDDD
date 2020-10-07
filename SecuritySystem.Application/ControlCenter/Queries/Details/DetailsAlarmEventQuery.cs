namespace SecuritySystem.Application.ControlCenter.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using SecuritySystem.Domain.ControlCenter.Models;
    using SecuritySystem.Domain.ControlCenter.Repositories;

    public class DetailsAlarmEventQuery : IRequest<AlarmEvent>
    {
        public int Id { get; set; }

        public class DetailsAlarmEventQueryHandler : IRequestHandler<DetailsAlarmEventQuery, AlarmEvent>
        {
            private readonly IAlarmEventDomainRepository alarmRepository;

            public DetailsAlarmEventQueryHandler(IAlarmEventDomainRepository alarmRepository)
            {
                this.alarmRepository = alarmRepository;
            }

            public async Task<AlarmEvent> Handle(
                DetailsAlarmEventQuery request,
                CancellationToken cancellationToken
                )
            {
                return await this.alarmRepository.Find(request.Id, cancellationToken);
            }
        }
    }
}
