namespace SecuritySystem.Application.Guards.GuardPatrols.Queries.Search
{
    using MediatR;
    using SecuritySystem.Application.Guards.GuardPatrols.Queries.Common;
    using SecuritySystem.Domain.Guards.Models;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchGuardPatrolsQuery: GuardPatrolsQuery, IRequest<SearchGuardPatrolsOutputModel>
    {
        public class SearchGuardPatrolsQueryHandler : GuardPatrolsQueryHandler, IRequestHandler<
            SearchGuardPatrolsQuery, 
            SearchGuardPatrolsOutputModel>
        {
            public SearchGuardPatrolsQueryHandler(IGuardPatrolQueryRepository guardPatrolQueryRepository)
                : base(guardPatrolQueryRepository)
            { }

            public async Task<SearchGuardPatrolsOutputModel> Handle(
                SearchGuardPatrolsQuery request,
                CancellationToken cancellationToken)
            {
                var list = await base.GetGuardPatrolListings<GuardPatrol>(request, cancellationToken);

                var totalPages = await base.GetTotalPages(request, cancellationToken);

                return new SearchGuardPatrolsOutputModel(list, request.Page, totalPages);
            }
        }
    }
}
