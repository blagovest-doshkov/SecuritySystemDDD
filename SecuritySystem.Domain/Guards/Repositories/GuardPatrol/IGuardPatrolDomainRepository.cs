namespace SecuritySystem.Domain.Guards.Repositories.GuardPatrol
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models;

    public interface IGuardPatrolDomainRepository : IDomainRepository<GuardPatrol>
    {
        Task<GuardPatrol> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

    }
}
