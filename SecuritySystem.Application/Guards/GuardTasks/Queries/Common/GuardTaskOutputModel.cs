namespace SecuritySystem.Application.Guards.GuardTasks.Queries.Common
{
    using System.Collections.Generic;

    public abstract class GuardTaskOutputModel<TGuardTaskOutputModel>
    {
        internal GuardTaskOutputModel(
            IEnumerable<TGuardTaskOutputModel> guardTasks,
            int page,
            int totalPages)
        {
            this.GuardTasks = guardTasks;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TGuardTaskOutputModel> GuardTasks { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
