using CIAAerea.Validators.Piloto;
using CIAAerea.ViewModels.Piloto;
using CIAArea.Contexts;
using CIAArea.Entities;
using FluentValidation;

namespace CIAAerea.Services;


public class PilotoService
{
    private readonly CiaAereaContext _context;
    private readonly AdicionarPilotoValidator _adicionarPilotoValidator;

    public PilotoService(CiaAereaContext context, AdicionarPilotoValidator adicionarPilotoValidator)
    {
        _context = context;
        _adicionarPilotoValidator = adicionarPilotoValidator;
    }

    public DetalhesPilotoViewModel AdicionarPiloto(AdicionarPilotoViewModel dados)
    {
        _adicionarPilotoValidator.ValidateAndThrow(dados);

        var piloto = new Piloto(dados.Nome, dados.Matricula);

        _context.Add(piloto);
        _context.SaveChanges();

        return new DetalhesPilotoViewModel(piloto.Id, piloto.Nome, piloto.Matricula);
    }

    public IEnumerable<ListarPilotoViewModel> ListarPilotos()
    {
        return _context.Pilotos.Select(p => new ListarPilotoViewModel(p.Id, p.Nome));
    }
    
    public DetalhesPilotoViewModel? ListarPilotoPeloId(int id)
    {
        var piloto = _context.Pilotos.Find(id);

        if (piloto != null)
        {
            return new DetalhesPilotoViewModel(piloto.Id, piloto.Nome, piloto.Matricula);
        }

        return null;
    }
}