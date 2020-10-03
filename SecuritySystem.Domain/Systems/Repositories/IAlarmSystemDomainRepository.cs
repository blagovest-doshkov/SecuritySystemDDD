namespace SecuritySystem.Domain.Systems.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models;

    public interface IAlarmSystemDomainRepository : IDomainRepository<AlarmSystem>
    {
        Task<AlarmSystem> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

    }
}
