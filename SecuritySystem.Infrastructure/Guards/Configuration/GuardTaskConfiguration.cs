namespace SecuritySystem.Infrastructure.Guards.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SecuritySystem.Domain.Guards.Models;
    using static Domain.Guards.Models.ModelConstants.Address;

    public class GuardTaskConfiguration : IEntityTypeConfiguration<GuardTask>
    {
        public void Configure(EntityTypeBuilder<GuardTask> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.EventUniqueId);

            builder
                .Property(t => t.EventDateTime);

            builder
                .Property(t => t.GuardTaskDateTime);

            builder
                .HasOne(t => t.AssignedPatrol)
                .WithMany()
                .HasForeignKey("GuardPatrolId");

            builder
                .OwnsOne(t => t.State, s => 
                {
                    //s.WithOwner();
                    s.Property(st => st.Value);
                    s.Property(st => st.Name);
                });

            builder
                .OwnsOne(t => t.Address, a =>
                {
                    a.WithOwner();

                    a
                    .Property(ad => ad.City)
                    .HasMaxLength(MaxCityNameLength)
                    .IsRequired();

                    a
                    .Property(ad => ad.StreetInfo)
                    .HasMaxLength(MaxStreetNameLength)
                    .IsRequired();

                    a.OwnsOne(ad => ad.Coordinates, gc => 
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

                });
        }
    }
}
