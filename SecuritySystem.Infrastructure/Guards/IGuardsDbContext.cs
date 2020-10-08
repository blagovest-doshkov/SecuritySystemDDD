namespace SecuritySystem.Infrastructure.Guards
{
    using Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using SecuritySystem.Domain.Guards.Models;

    interface IGuardsDbContext : IDbContext
    {
        DbSet<GuardTask> GuardTasks { get; }

        DbSet<GuardUnit> GuardUnits { get; }

        DbSet<GuardPatrol> GuardPatrols { get; }
    }
}
