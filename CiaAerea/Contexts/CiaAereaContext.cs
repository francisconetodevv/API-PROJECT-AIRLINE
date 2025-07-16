using CIAArea.Entities;
using Microsoft.EntityFrameworkCore;

namespace CIAArea.Contexts;

// Hernando de DbContext - Classe do Entity Framework Core
public class CiaAereaContext : DbContext
{

    // Classe de aspnet que carrega a string de conexão do arquivo json appsettings.json
    private readonly IConfiguration _configuration;

    public CiaAereaContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Representam a tabela do banco
    public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
    public DbSet<Piloto> Pilotos => Set<Piloto>();
    public DbSet<Voo> Voos => Set<Voo>();
    public DbSet<Manutencao> Manutencoes => Set<Manutencao>();
    public DbSet<Cancelamento> Cancelamentos => Set<Cancelamento>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CiaAerea"));
    }
}