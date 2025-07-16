using CIAArea.Entities;
using Microsoft.EntityFrameworkCore;

namespace CIAArea.Contexts;

// Hernando de DbContext - Classe do Entity Framework Core
public class CiaAereaContext : DbContext
{
    
    // Representam a tabela do banco
    public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
    public DbSet<Piloto> Pilotos => Set <Piloto>();
    public DbSet<Voo> Voos => Set <Voo>();
    public DbSet<Manutencao> Manutencoes => Set <Manutencao>();
    public DbSet<Cancelamento> Cancelamentos => Set <Cancelamento>();

}