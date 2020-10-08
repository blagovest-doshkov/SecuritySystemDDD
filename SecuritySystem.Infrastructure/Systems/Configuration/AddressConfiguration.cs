namespace SecuritySystem.Infrastructure.Systems.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SecuritySystem.Domain.Systems.Models;
    using static Domain.Systems.Models.ModelConstants.Address;

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Country)
                .HasMaxLength(MaxCountryNameLength)
                .IsRequired();

            builder
                .Property(a => a.Province);

            builder
                .Property(a => a.City)
                .HasMaxLength(MaxCityNameLength)
                .IsRequired();

            builder
                .Property(a => a.Street)
                .HasMaxLength(MaxStreetNameLength)
                .IsRequired();

            builder
                .OwnsOne(a => a.Coordinates, gc =>
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
        }
    }
}
