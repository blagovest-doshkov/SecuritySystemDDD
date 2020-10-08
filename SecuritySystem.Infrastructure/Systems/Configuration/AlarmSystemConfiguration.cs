namespace SecuritySystem.Infrastructure.Systems.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SecuritySystem.Domain.Systems.Models;
    using static Domain.Systems.Models.ModelConstants.AlarmSystem;
    using static Domain.Common.Models.ModelConstants.PhoneNumber;

    public class AlarmSystemConfiguration : IEntityTypeConfiguration<AlarmSystem>
    {
        public void Configure(EntityTypeBuilder<AlarmSystem> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .Property(s => s.OwnerId)
                .IsRequired();

            builder
                .Property(s => s.Name)
                .HasMaxLength(ModelConstants.AlarmSystem.MaxNameLength)
                .IsRequired();

            builder
                .Property(s => s.Notes)
                .HasMaxLength(MaxNotesLength)
                .IsRequired();

            builder
                .Property(s => s.IsInstalled)
                .IsRequired();

            builder
                .Property(s => s.IsInConfiguration)
                .IsRequired();

            builder
                .Property(s => s.IsArmed)
                .IsRequired();

            builder
                .Property(s => s.AlarmTriggered)
                .IsRequired();

            builder
                .Property(s => s.ControlUnitSerialNumber);

            builder
                .OwnsOne(s => s.ContactsInfo, c =>
                {
                    c.WithOwner();

                    c
                    .Property(cp => cp.Name)
                    .HasMaxLength(Domain.Common.Models.ModelConstants.Contact.MaxNameLength);

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
                .HasOne(s => s.Address)
                .WithOne()
                .HasForeignKey("AddressId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
