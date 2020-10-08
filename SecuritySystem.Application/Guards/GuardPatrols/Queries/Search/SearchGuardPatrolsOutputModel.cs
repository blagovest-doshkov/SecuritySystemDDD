namespace SecuritySystem.Application.Guards.GuardPatrols.Queries.Search
{
    using SecuritySystem.Application.Guards.GuardPatrols.Queries.Common;
    using SecuritySystem.Domain.Guards.Models;
    using System.Collections.Generic;

    public class SearchGuardPatrolsOutputModel : GuardPatrolsOutputModel<GuardPatrol>
    {
        public SearchGuardPatrolsOutputModel(
            IEnumerable<GuardPatrol> guardPatrols,
            int page,
            int totalPages)
            : base(guardPatrols, page, totalPages)
        {
        }
    }
}
