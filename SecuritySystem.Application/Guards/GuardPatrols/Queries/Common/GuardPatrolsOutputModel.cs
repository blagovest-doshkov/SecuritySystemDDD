namespace SecuritySystem.Application.Guards.GuardPatrols.Queries.Common
{
   using System.Collections.Generic;

    public abstract class GuardPatrolsOutputModel<TGuardPatrolOutputModel>
    {
        internal GuardPatrolsOutputModel(
            IEnumerable<TGuardPatrolOutputModel> guardPatrols,
            int page,
            int totalPages)
        {
            this.GuardPatrols = guardPatrols;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TGuardPatrolOutputModel> GuardPatrols { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
