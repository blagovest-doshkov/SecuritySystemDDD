namespace SecuritySystem.Application.Guards.Querries
{
    using Domain.Common;
    using Domain.Guards.Models;
    using Application.Common;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IGuardPatrolQueryRepository : IQueryRepository<GuardPatrol>
    {
        Task<IEnumerable<TOutputModel>> GetGuardPatrolListings<TOutputModel>(
            Specification<GuardPatrol> guardPatrolSpecification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<int> Total(
            Specification<GuardPatrol> guardPatrolSpecification,
            CancellationToken cancellationToken = default);
    }
}
