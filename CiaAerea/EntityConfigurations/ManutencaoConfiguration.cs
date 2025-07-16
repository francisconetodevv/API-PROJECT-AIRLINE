using CIAArea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIAArea.EntitiesConfigurations;

public class ManutencaoConfiguration : IEntityTypeConfiguration<Manutencao>
{
    public void Configure(EntityTypeBuilder<Manutencao> builder)
    {
        builder.ToTable("Manutencoes");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.DataHoraManutencao)
               .IsRequired();

        builder.Property(m => m.Observacoes)
               .HasMaxLength(100);

        builder.Property(m => m.Tipo)
               .IsRequired();
    }
}