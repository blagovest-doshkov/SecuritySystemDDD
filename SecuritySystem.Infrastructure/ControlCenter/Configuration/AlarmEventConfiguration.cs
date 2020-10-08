namespace SecuritySystem.Infrastructure.ControlCenter.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.ControlCenter.Models;
    using static Domain.ControlCenter.Models.ModelConstants.AlarmEvent;
    using static Domain.ControlCenter.Models.ModelConstants.Address;
    using static Domain.Common.Models.ModelConstants.Contact;
    using static Domain.Common.Models.ModelConstants.PhoneNumber;


    public class AlarmEventConfiguration : IEntityTypeConfiguration<AlarmEvent>
    {
        public void Configure(EntityTypeBuilder<AlarmEvent> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.SystemId);

            builder
                .Property(e => e.Notes)
                .HasMaxLength(MaxNotesLength);

            builder
                .OwnsOne(e => e.State, state => 
                {
                    state.WithOwner();

                    state.Property(s => s.Value);
                });

            builder
                .OwnsOne(e => e.Contact, c =>
                {
                    c.WithOwner();

                    c
                    .Property(cp => cp.Name)
                    .HasMaxLength(MaxNameLength);

                    c.OwnsOne(cp => cp.PhoneNumber, pn =>
                    {
                        pn.WithOwner();

                        pn
                        .Property(p => p.Number)
                        .HasMaxLength(MaxPhoneNumberLength)
                        .IsRequired();
                    });
                });

            builder
                .OwnsOne(e => e.Address, a =>
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
