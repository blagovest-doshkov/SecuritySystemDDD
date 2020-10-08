namespace SecuritySystem.Infrastructure.Guards.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SecuritySystem.Domain.Guards.Models;
    using static Domain.Guards.Models.ModelConstants.GuardUnit;

    public class GuardUnitConfiguration : IEntityTypeConfiguration<GuardUnit>
    {
        public void Configure(EntityTypeBuilder<GuardUnit> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.UserId)
                .IsRequired();

            builder
                .Property(u => u.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();
        }
    }
}
