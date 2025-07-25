using CIAAerea.Validators.Manutencao;
using CIAAerea.ViewModels.Manutencao;
using CIAArea.Contexts;
using CIAArea.Entities;
using FluentValidation;

namespace CIAAerea.Services;

public class ManutencaoService
{
    private readonly CiaAereaContext _context;
    private readonly AdicionarManutencaoValidator _adicionarManutencaoValidator;

    public ManutencaoService(CiaAereaContext context, AdicionarManutencaoValidator adicionarManutencaoValidator)
    {
        _context = context;
        _adicionarManutencaoValidator = adicionarManutencaoValidator;
    }

    public ListarManutencaoViewModel AdicionarManutencao(AdicionarManutencaoViewModel dados)
    {
        _adicionarManutencaoValidator.ValidateAndThrow(dados);

        var manutencao = new Manutencao(
            dados.DataHoraManutencao,
            dados.Tipo,
            dados.AeronaveId,
            dados.Observacoes
        );

        _context.Add(manutencao);
        _context.SaveChanges();

        return new ListarManutencaoViewModel(
            manutencao.Id,
            manutencao.DataHoraManutencao,
            manutencao.Observacoes,
            manutencao.Tipo,
            manutencao.AeronaveId
        );
    }
    
}