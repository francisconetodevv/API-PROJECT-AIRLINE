using CIAArea.Contexts;
using CIAArea.Entities;
using CIAArea.ViewModels;
using CIAAerea.Validators;
using FluentValidation;

namespace CIAArea.Services;

public class AeronaveServices
{
    // Instância do db Context para ter acesso ao banco de dados
    private readonly CiaAereaContext _context;
    private readonly AdicionarAeronaveValidator _adicionarAeronaveValidator;
    private readonly AtualizarAeronaveValidator _atualizarAeronaveValidator;
    private readonly ExcluirAeronaveValidator _excluirAeronaveValidator;

    // Construtor
    public AeronaveServices(CiaAereaContext context, AdicionarAeronaveValidator adicionarAeronaveValidator, AtualizarAeronaveValidator atualizarAeronaveValidator, ExcluirAeronaveValidator excluirAeronaveValidator)
    {
        _context = context;
        _adicionarAeronaveValidator = adicionarAeronaveValidator;
        _atualizarAeronaveValidator = atualizarAeronaveValidator;
        _excluirAeronaveValidator = excluirAeronaveValidator;
    }

    // Primeira ação do CRUD - Create - Método POST
    public DetalhesAeronaveViewModel AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
        _adicionarAeronaveValidator.ValidateAndThrow(dados);

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

    // Método de PUT - Aeronave
    public DetalhesAeronaveViewModel? AtualizarAeronave(AtualizarAeronaveViewModel dados)
    {
        _atualizarAeronaveValidator.ValidateAndThrow(dados);

        var aeronave = _context.Aeronaves.Find(dados.Id);

        if (aeronave != null)
        {
            aeronave.Fabricante = dados.Fabricante;
            aeronave.Modelo = dados.Modelo;
            aeronave.Codigo = dados.Codigo;

            _context.Update(aeronave);
            _context.SaveChanges();

            return new DetalhesAeronaveViewModel(aeronave.Id, aeronave.Fabricante, aeronave.Modelo, aeronave.Codigo);
        }

        return null;
    }

    public void ExcluirAeronave(int id)
    {
        _excluirAeronaveValidator.ValidateAndThrow(id);
        var aeronave = _context.Aeronaves.Find(id);

        if (aeronave != null)
        {
            _context.Remove(aeronave);
            _context.SaveChanges();
        }
    }

}