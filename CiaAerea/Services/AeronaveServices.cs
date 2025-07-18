using CIAArea.Contexts;
using CIAArea.Entities;
using CIAArea.ViewModels;

namespace CIAArea.Services;

public class AeronaveServices
{
    // Instância do db Context para ter acesso ao banco de dados
    private readonly CiaAereaContext _context;

    // Construtor
    public AeronaveServices(CiaAereaContext context)
    {
        _context = context;
    }

    // Primeira ação do CRUD - Create - Método POST
    public DetalhesAeronaveViewModel AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
        var aeronave = new Aeronave(dados.Fabricante, dados.Modelo, dados.Codigo);

        _context.Add(aeronave);
        _context.SaveChanges();

        return new DetalhesAeronaveViewModel(
            aeronave.Id,
            aeronave.Fabricante,
            aeronave.Modelo,
            aeronave.Codigo
        );
    }

    // Método de Get - Aeronaves
    public IEnumerable<ListarAeronaveViewModel> ListarAeronaves()
    {
        return _context.Aeronaves.Select(a => new ListarAeronaveViewModel(a.Id, a.Modelo, a.Codigo));
    }

    // Método de Get - Aeronave
    public DetalhesAeronaveViewModel? ListarAeronavePeloId(int id)
    {
        var aeronave = _context.Aeronaves.Find(id);

        if (aeronave != null)
        {
            return new DetalhesAeronaveViewModel
           (
               aeronave.Id,
               aeronave.Fabricante,
               aeronave.Modelo,
               aeronave.Codigo
           );
        }

        return null;
    }

}