namespace SecuritySystem.Application.ControlCenter.Queries.Search
{
    using Common;
    using MediatR;
    using SecuritySystem.Application.ControlCenter.Querries;
    using SecuritySystem.Domain.ControlCenter.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchAlarmEventsQuery : AlarmEventsQuery, IRequest<SearchAlarmEventsOutputModel>
    {
        public class SearchAlarmSystemsQueryHandler : AlarmEventsQueryHandler, IRequestHandler<SearchAlarmEventsQuery, SearchAlarmEventsOutputModel>
        {
            public SearchAlarmSystemsQueryHandler(IAlarmEventQueryRepository alarmEventQueryRepository)
                :base(alarmEventQueryRepository)
            { }

            public async Task<SearchAlarmEventsOutputModel> Handle(
                SearchAlarmEventsQuery request,
                CancellationToken cancellationToken)
            {
                var alarmEvents = await base.GetAlarmEventListing<AlarmEvent>(request, cancellationToken);
                var totalPages = await base.GetTotalPages(request, cancellationToken);

                return new SearchAlarmEventsOutputModel(alarmEvents, request.Page, totalPages);
            }
        }
    }
}
