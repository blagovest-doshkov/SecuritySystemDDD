namespace SecuritySystem.Application.Guards.GuardTasks.Queries.Search
{
    using Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchGuardTaskQuery : GuardTaskQuery, IRequest<SearchGuardTaskOutputModel>
    {
        public class SearchGuardTaskQueryHandler : GuardTaskQueryHandler, IRequestHandler<SearchGuardTaskQuery, SearchGuardTaskOutputModel>
        {
            public SearchGuardTaskQueryHandler(IGuardTaskQueryRepository guardTaskQueryRepository)
                : base(guardTaskQueryRepository)
            { }

            public async Task<SearchGuardTaskOutputModel> Handle(
                SearchGuardTaskQuery request,
                CancellationToken cancellationToken)
            {
                var guardTasks = await base.GetGuardTaskListings(request, cancellationToken);
                var totalPages = await base.GetTotalPages(request, cancellationToken);

                return new SearchGuardTaskOutputModel(guardTasks, request.Page, totalPages);
            }
        }
    }
}
