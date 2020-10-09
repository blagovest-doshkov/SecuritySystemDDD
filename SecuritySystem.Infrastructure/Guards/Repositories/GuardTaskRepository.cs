namespace SecuritySystem.Infrastructure.Guards.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Domain.Guards.Models;
    using Domain.Guards.Repositories.GuardUnit;
    using Infrastructure.Common.Persistence;
    using System.Threading;
    using System.Threading.Tasks;
    using SecuritySystem.Domain.Guards.Repositories.GuardPatrol;
    using System.Linq;

    internal class GuardTaskRepository : DataRepository<IGuardsDbContext, GuardTask>,
        IGuardTaskDomainRepository
    {
        public GuardTaskRepository(IGuardsDbContext db)
            : base(db)
        { }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var guardTask = await this.Data.GuardTasks.FindAsync(id);

            if (guardTask == null)
            {
                return false;
            }

            this.Data.GuardTasks.Remove(guardTask);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<GuardTask> Find(int id, CancellationToken cancellationToken = default)
        {
            return await this
                .All()
                .FirstOrDefaultAsync(g => g.Id == id, cancellationToken);
        }

        public async Task<GuardTask> FindActiveTaskByEventId(int eventId, CancellationToken cancellationToken = default)
        {
                return await this
                    .AllActive()
                    .SingleOrDefaultAsync(t => t.EventId == eventId);
        }

        private IQueryable<GuardTask> AllActive()
        {
            return this
                .All()
                .Where(task => task.State != GuardTaskState.Handled);
        }
    }
}
