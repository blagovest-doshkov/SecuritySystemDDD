namespace SecuritySystem.Infrastructure.ControlCenter
{
    using Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using Domain.ControlCenter.Models;

    internal interface IControlCenterDbContext : IDbContext
    {
        DbSet<AlarmEvent> AlarmEvents { get; }
    }
}
