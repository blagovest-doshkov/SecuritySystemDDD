namespace SecuritySystem.Infrastructure.Guards.Repositories
{
    using Application.Guards.GuardPatrols.Queries;
    using Domain.Common;
    using Domain.Guards.Models;
    using Domain.Guards.Repositories.GuardPatrol;
    using Infrastructure.Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;


    internal class GuardPatrolRepository: DataRepository<IGuardsDbContext,GuardPatrol>,
        IGuardPatrolDomainRepository,
        IGuardPatrolQueryRepository
    {
        public GuardPatrolRepository(IGuardsDbContext db)
            : base(db)
        { }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var guardPatrol = await this.Data.GuardPatrols.FindAsync(id);

            if (guardPatrol == null)
            {
                return false;
            }

            this.Data.GuardPatrols.Remove(guardPatrol);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<GuardPatrol> Find(int id, CancellationToken cancellationToken = default)
        {
            return await this
                .All()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<GuardPatrol>> GetAvailablePatrols(CancellationToken cancellationToken = default)
        {
            return await this.AllAvailable().ToListAsync();
        }

        public async Task<IEnumerable<GuardPatrol>> GetGuardPatrolListings(
            Specification<GuardPatrol> guardPatrolSpecification, 
            int skip = 0, 
            int take = int.MaxValue, 
            CancellationToken cancellationToken = default)
        {
            return (await (this.All().Where(guardPatrolSpecification))
                .ToListAsync(cancellationToken))
                    .Skip(skip)
                    .Take(take);
        }

        public async Task<int> Total(
            Specification<GuardPatrol> guardPatrolSpecification, 
            CancellationToken cancellationToken = default)
        {
            return await(this.All().Where(guardPatrolSpecification))
                .CountAsync(cancellationToken);
        }

        private IQueryable<GuardPatrol> AllAvailable()
            => this
                .All()
                .Where(patrol => patrol.IsAvailable);
    }
}
