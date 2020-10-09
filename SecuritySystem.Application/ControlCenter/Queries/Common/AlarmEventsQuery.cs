namespace SecuritySystem.Application.ControlCenter.Queries.Common
{
    using SecuritySystem.Application.ControlCenter.Querries;
    using SecuritySystem.Domain.Common;
    using SecuritySystem.Domain.ControlCenter.Models;
    using SecuritySystem.Domain.ControlCenter.Specifications;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class AlarmEventsQuery
    {
        private const int AlarmEventsPerPage = 10;
        public int Page { get; set; } = 1;

        public int? SystemId { get; set; }
        public int? State { get; set; }

        public abstract class AlarmEventsQueryHandler
        {
            private readonly IAlarmEventQueryRepository alarmEventQueryRepository;

            protected AlarmEventsQueryHandler(IAlarmEventQueryRepository alarmEventQueryRepository)
            {
                this.alarmEventQueryRepository = alarmEventQueryRepository;
            }

            protected Task<IEnumerable<AlarmEvent>> GetAlarmEventListing(
                AlarmEventsQuery request, 
                CancellationToken cancellationToken = default)
            {
                var alarmEventSpecification = this.GetAlarmEventSpecification(request);
                var skip = (request.Page - 1) * AlarmEventsPerPage;
                return this.alarmEventQueryRepository.GetAlarmEventListings(alarmEventSpecification, skip, take: AlarmEventsPerPage, cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                AlarmEventsQuery request,
                CancellationToken cancellationToken = default)
            {
                var alarmEventSpecification = this.GetAlarmEventSpecification(request);
                var totalAlarmSystems = await this.alarmEventQueryRepository.Total(alarmEventSpecification, cancellationToken);
                return (int)Math.Ceiling((double)totalAlarmSystems / AlarmEventsPerPage);
            }

            private Specification<AlarmEvent> GetAlarmEventSpecification(AlarmEventsQuery request)
            {
                return new AlarmEventByStateSpecification(request.SystemId)
                    .And(new AlarmEventByStateSpecification(request.State));
            }
        }
    }
}
