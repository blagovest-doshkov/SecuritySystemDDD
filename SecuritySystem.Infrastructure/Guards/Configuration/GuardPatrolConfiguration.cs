namespace SecuritySystem.Infrastructure.Guards.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SecuritySystem.Domain.Guards.Models;

    public class GuardPatrolConfiguration : IEntityTypeConfiguration<GuardPatrol>
    {
        public void Configure(EntityTypeBuilder<GuardPatrol> builder)
        {
            builder
                .HasKey(p=> p.Id);

            builder
                .Property(p => p.IsAvailable)
                .IsRequired();

            builder
                .OwnsOne(p => p.GeoLocation, gc => 
                {
                    gc.WithOwner();

                    gc
                    .Property(c => c.Latitude)
                    .HasColumnType("decimal(12,9)")
                    .IsRequired();

                    gc
                    .Property(c => c.Longitude)
                    .HasColumnType("decimal(12,9)")
                    .IsRequired();
                });

            builder
                .HasMany(p => p.GuardUnits)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("guardUnits");
        }
    }
}
