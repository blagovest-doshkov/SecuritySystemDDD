namespace SecuritySystem.Application.Systems.Queries.Search
{
    using Common;
    using MediatR;
    using SecuritySystem.Application.Systems.Querries;
    using SecuritySystem.Domain.Systems.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchAlarmSystemsQuery: AlarmSystemsQuery, IRequest<SearchAlarmSystemsOutputModel>
    {
        public class SearchAlarmSystemsQueryHandler : AlarmSystemsQueryHandler, IRequestHandler<SearchAlarmSystemsQuery, SearchAlarmSystemsOutputModel>
        {
            public SearchAlarmSystemsQueryHandler(IAlarmSystemQueryRepository alarmSystemQueryRepository)
                :base(alarmSystemQueryRepository)
            { }

            public async Task<SearchAlarmSystemsOutputModel> Handle(
                SearchAlarmSystemsQuery request,
                CancellationToken cancellationToken)
            {
                var alarmSystems = await base.GetAlarmSystemListing<AlarmSystem>(request, cancellationToken);
                var totalPages = await base.GetTotalPages(request, cancellationToken);

                return new SearchAlarmSystemsOutputModel(alarmSystems, request.Page, totalPages);
            }
        }
    }
}
