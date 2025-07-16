using CIAArea.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIAArea.EntitiesConfigurations;

public class PilotoConfiguration : IEntityTypeConfiguration<Piloto>
{
    public void Configure(EntityTypeBuilder<Piloto> builder)
    {
        builder.ToTable("Piloto");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.Matricula)
               .IsRequired()
               .HasMaxLength(10);

        // Como definir indices, pois será possível ter somente uma matrícula por piloto
        builder.HasIndex(p => p.Matricula)
               .IsUnique();
    }
}