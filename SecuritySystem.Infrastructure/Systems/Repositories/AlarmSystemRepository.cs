namespace SecuritySystem.Infrastructure.Systems.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Application.Systems.Querries;
    using Domain.Common;
    using Domain.Systems.Models;
    using Domain.Systems.Repositories;
    using Infrastructure.Common.Persistence;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AlarmSystemRepository : DataRepository<IAlarmSystemsDbContext, AlarmSystem>,
        IAlarmSystemDomainRepository,
        IAlarmSystemQueryRepository
    {
        public AlarmSystemRepository(IAlarmSystemsDbContext db)
            : base(db) 
        { }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var alarmSystem = await this.Data.AlarmSystems.FindAsync(id);

            if (alarmSystem == null)
            {
                return false;
            }

            this.Data.AlarmSystems.Remove(alarmSystem);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<AlarmSystem> Find(int id, CancellationToken cancellationToken = default)
        {
            return await this
                .All()
                .Include(s => s.Address)
                //.Include(s => s.ContactsInfo)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<AlarmSystem>> GetAlarmSystemListings(
            Specification<AlarmSystem> alarmSystemSpecification, 
            int skip = 0, 
            int take = int.MaxValue, 
            CancellationToken cancellationToken = default)
        {
            return (await (this.All().Where(alarmSystemSpecification))
                        .ToListAsync(cancellationToken))
                            .Skip(skip)
                            .Take(take);
        }

        public async Task<int> Total(Specification<AlarmSystem> alarmSystemSpecification, CancellationToken cancellationToken = default)
        {
            return await (this.Data.AlarmSystems.Where(alarmSystemSpecification))
                        .CountAsync(cancellationToken);
        }
    }
}
