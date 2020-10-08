namespace SecuritySystem.Infrastructure.Common.Persistence
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common.Models;
    using Events;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.ControlCenter;
    using Infrastructure.Guards;
    using Infrastructure.Systems;
    using SecuritySystem.Domain.Systems.Models;
    using SecuritySystem.Domain.ControlCenter.Models;
    using SecuritySystem.Domain.Guards.Models;

    internal class SecuritySystemDbContext : IdentityDbContext<User>,
        IAlarmSystemsDbContext,
        IControlCenterDbContext,
        IGuardsDbContext
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly Stack<object> savesChangesTracker;

        public SecuritySystemDbContext(
            DbContextOptions<SecuritySystemDbContext> options,
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.savesChangesTracker = new Stack<object>();
        }

        public DbSet<AlarmSystem> AlarmSystems { get; set; } = default!;

        public DbSet<Domain.Systems.Models.Address> Addresses { get; set; } = default!;

        public DbSet<AlarmEvent> AlarmEvents { get; set; } = default!;

        public DbSet<GuardTask> GuardTasks { get; set; } = default!;

        public DbSet<GuardUnit> GuardUnits { get; set; } = default!;

        public DbSet<GuardPatrol> GuardPatrols { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.savesChangesTracker.Push(new object());

            var entities = this.ChangeTracker
                .Entries<IEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entities)
            {
                var events = entity.Events.ToArray();

                entity.ClearEvents();

                foreach (var domainEvent in events)
                {
                    await this.eventDispatcher.Dispatch(domainEvent);
                }
            }

            this.savesChangesTracker.Pop();

            if (!this.savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
