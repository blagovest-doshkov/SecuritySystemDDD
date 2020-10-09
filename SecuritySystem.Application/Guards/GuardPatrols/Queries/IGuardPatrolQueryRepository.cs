namespace SecuritySystem.Application.Guards.GuardPatrols.Queries
{
    using SecuritySystem.Application.Common;
    using SecuritySystem.Domain.Common;
    using SecuritySystem.Domain.Guards.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IGuardPatrolQueryRepository : IQueryRepository<GuardPatrol>
    {
        Task<IEnumerable<GuardPatrol>> GetGuardPatrolListings(
            Specification<GuardPatrol> guardPatrolSpecification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);


        Task<int> Total(
            Specification<GuardPatrol> guardPatrolSpecification,
            CancellationToken cancellationToken = default);
    }
}
