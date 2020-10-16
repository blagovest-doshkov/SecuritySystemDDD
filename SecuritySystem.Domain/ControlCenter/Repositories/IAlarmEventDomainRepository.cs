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

        Task<AlarmEvent> FindActiveEventByAlarmSystemId(int AlarmSystemId, CancellationToken cancellationToken = default);
        Task<AlarmEvent> FindActiveEventByEventUniqueId(string EventUniqueId, CancellationToken cancellationToken = default);
    }
}
