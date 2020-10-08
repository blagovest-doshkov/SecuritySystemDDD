namespace SecuritySystem.Infrastructure.Systems
{
    using Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Domain.Systems.Models;

    interface IAlarmSystemsDbContext : IDbContext
    {
        DbSet<AlarmSystem> AlarmSystems { get; }

        DbSet<Address> Addresses { get; }
    }
}
