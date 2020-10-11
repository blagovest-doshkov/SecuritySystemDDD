namespace SecuritySystem.Application.Guards.GuardTasks.Queries.Search
{
    using SecuritySystem.Application.Guards.GuardTasks.Queries.Common;
    using SecuritySystem.Domain.Guards.Models;
    using System.Collections.Generic;

    public class SearchGuardTaskOutputModel : GuardTaskOutputModel<GuardTask>
    {
        public SearchGuardTaskOutputModel(
            IEnumerable<GuardTask> guardTasks,
            int page,
            int totalPages
            ) : base(guardTasks, page, totalPages) { }
    }
}
