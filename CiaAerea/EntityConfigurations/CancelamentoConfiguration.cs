using CIAArea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIAArea.EntitiesConfigurations;

public class CancelamentoConfiguration : IEntityTypeConfiguration<Cancelamento>
{
    public void Configure(EntityTypeBuilder<Cancelamento> builder)
    {
        builder.ToTable("Cancelamento");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.MotivoCancelamento)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.DataHoraNotificacao)
               .IsRequired();
    }
}