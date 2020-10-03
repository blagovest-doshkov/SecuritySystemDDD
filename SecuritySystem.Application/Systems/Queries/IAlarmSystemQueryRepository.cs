namespace SecuritySystem.Application.Systems.Querries
{
    using Domain.Systems.Models;
    using Domain.Common;
    using Application.Common;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;


    public interface IAlarmSystemQueryRepository : IQueryRepository<AlarmSystem>
    {
        Task<IEnumerable<TOutputModel>> GetAlarmSystemListings<TOutputModel>(
            Specification<AlarmSystem> alarmSystemSpecification,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);
        Task<int> Total(
            Specification<AlarmSystem> alarmSystemSpecification,
            CancellationToken cancellationToken = default);
    }
}
