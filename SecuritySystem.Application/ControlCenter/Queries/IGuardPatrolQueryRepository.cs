namespace SecuritySystem.Application.ControlCenter.Querries
{
    using Domain.Common;
    using Domain.ControlCenter.Models;
    using Application.Common;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IAlarmEventQueryRepository : IQueryRepository<AlarmEvent>
    {
        Task<IEnumerable<AlarmEvent>> GetAlarmEventListings(
            Specification<AlarmEvent> alarmEventSpecification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<int> Total(
            Specification<AlarmEvent> alarmEventSpecification,
            CancellationToken cancellationToken = default);
    }
}
