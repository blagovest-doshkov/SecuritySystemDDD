namespace SecuritySystem.Application.Systems.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using SecuritySystem.Domain.Systems.Models;
    using SecuritySystem.Domain.Systems.Repositories;

    public class DetailsAlarmSystemQuery : IRequest<AlarmSystem>
    {
        public int Id { get; set; }

        public class DetailsAlarmSystemQueryHandler : IRequestHandler<DetailsAlarmSystemQuery, AlarmSystem>
        {
            private readonly IAlarmSystemDomainRepository alarmRepository;

            public DetailsAlarmSystemQueryHandler(IAlarmSystemDomainRepository alarmRepository)
            {
                this.alarmRepository = alarmRepository;
            }

            public async Task<AlarmSystem> Handle(
                DetailsAlarmSystemQuery request,
                CancellationToken cancellationToken
                )
            {
                return await this.alarmRepository.Find(request.Id, cancellationToken);
            }
        }
    }
}
