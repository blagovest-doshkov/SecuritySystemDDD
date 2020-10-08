namespace SecuritySystem.Domain.Guards.Repositories.GuardUnit
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models;

    public interface IGuardUnitDomainRepository : IDomainRepository<GuardUnit>
    {
        Task<GuardTask> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

    }
}
