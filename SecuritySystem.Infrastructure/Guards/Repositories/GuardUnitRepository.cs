namespace SecuritySystem.Infrastructure.Guards.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Domain.Guards.Models;
    using Domain.Guards.Repositories.GuardUnit;
    using Infrastructure.Common.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    internal class GuardUnitRepository : DataRepository<IGuardsDbContext, GuardUnit>,
        IGuardUnitDomainRepository
    {
        public GuardUnitRepository(IGuardsDbContext db)
            : base(db)
        { }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var guardUnit = await this.Data.GuardUnits.FindAsync(id);

            if (guardUnit == null)
            {
                return false;
            }

            this.Data.GuardUnits.Remove(guardUnit);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<GuardUnit> Find(int id, CancellationToken cancellationToken = default)
        {
            return await this
                .All()
                .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        }
    }
}
