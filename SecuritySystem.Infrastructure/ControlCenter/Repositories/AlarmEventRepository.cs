namespace SecuritySystem.Infrastructure.ControlCenter.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SecuritySystem.Application.ControlCenter.Querries;
    using SecuritySystem.Domain.Common;
    using SecuritySystem.Domain.ControlCenter.Models;
    using SecuritySystem.Domain.ControlCenter.Repositories;
    using SecuritySystem.Infrastructure.Common.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AlarmEventRepository : DataRepository<IControlCenterDbContext, AlarmEvent>,
        IAlarmEventDomainRepository,
        IAlarmEventQueryRepository
    {

        public AlarmEventRepository(IControlCenterDbContext db)
            : base(db)
        { }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var alarmEvent = await this.Data.AlarmEvents.FindAsync(id, cancellationToken);

            if (alarmEvent == null)
                return false;

            this.Data.AlarmEvents.Remove(alarmEvent);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<AlarmEvent> FindActiveEventByAlarmSystemId(int AlarmSystemId, CancellationToken cancellationToken = default)
        {
            return await this
                .AllActive()
                .SingleOrDefaultAsync(ev => ev.SystemId == AlarmSystemId);
        }

        public async Task<AlarmEvent> Find(int id, CancellationToken cancellationToken = default)
        {
            return await this
                .All()
                .FirstOrDefaultAsync(ev => ev.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<AlarmEvent>> GetAlarmEventListings(
            Specification<AlarmEvent> alarmEventSpecification,
            int skip = 0, 
            int take = int.MaxValue, 
            CancellationToken cancellationToken = default)
        {
            return (await (this.All().Where(alarmEventSpecification))
                        .ToListAsync(cancellationToken))
                            .Skip(skip)
                            .Take(take);
        }

        public async Task<int> Total(
            Specification<AlarmEvent> alarmEventSpecification, 
            CancellationToken cancellationToken = default)
        {
            return await (this.Data.AlarmEvents.Where(alarmEventSpecification))
                        .CountAsync(cancellationToken);
        }

        private IQueryable<AlarmEvent> AllActive()
        {
            return this
                .All()
                .Where(alarm => alarm.State.Value != AlarmEventState.Handled.Value);
        }

        public Task<AlarmEvent> FindActiveEventByEventUniqueId(string EventUniqueId, CancellationToken cancellationToken = default)
        {
            return this
                    .All()
                    .SingleOrDefaultAsync(alarm => alarm.EventUniqueId == EventUniqueId);
        }
    }
}
