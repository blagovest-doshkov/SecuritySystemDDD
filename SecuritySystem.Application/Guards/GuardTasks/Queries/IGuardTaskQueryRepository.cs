namespace SecuritySystem.Application.Guards.GuardTasks.Queries
{
    using SecuritySystem.Application.Common;
    using SecuritySystem.Domain.Common;
    using SecuritySystem.Domain.Guards.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IGuardTaskQueryRepository : IQueryRepository<GuardTask>
    {
        Task<IEnumerable<GuardTask>> GetGuardTaskListings(
            Specification<GuardTask> guardTaskSpecification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);


        Task<int> Total(
            Specification<GuardTask> guardTaskSpecification,
            CancellationToken cancellationToken = default);
    }

}
