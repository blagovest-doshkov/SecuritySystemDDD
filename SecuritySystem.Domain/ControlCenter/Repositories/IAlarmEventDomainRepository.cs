namespace SecuritySystem.Domain.ControlCenter.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models;

    public interface IAlarmEventDomainRepository : IDomainRepository<AlarmEvent>
    {
        Task<AlarmEvent> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

    }
}
