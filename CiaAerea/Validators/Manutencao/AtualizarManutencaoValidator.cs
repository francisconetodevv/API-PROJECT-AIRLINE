using CIAAerea.ViewModels.Manutencao;
using CIAArea.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CIAAerea.Validators.Manutencao;

public class AtualizarManutencaoValidator : AbstractValidator<AtualizarManutencaoViewModel>
{
    private readonly CiaAereaContext _context;

    public AtualizarManutencaoValidator(CiaAereaContext context)
    {
        _context = context;

        RuleFor(m => m.DataHoraManutencao)
            .NotEmpty().WithMessage("A data/hora da manutenção é obrigatória.");

        RuleFor(m => m.Tipo)
            .NotNull().WithMessage("O tipo da manutenção é obrigatório.");

        RuleFor(m => m).Custom((manutencao, ValidationContext) =>
        {
            var aeronave = _context.Aeronaves.Include(a => a.Voos).FirstOrDefault(a => a.Id == manutencao.AeronaveId);

            if (aeronave == null)
            {
                ValidationContext.AddFailure("Id de aeronave inválida");
            }
            else
            {
                var emVoo = aeronave.Voos.Any(v => v.DataHoraPartida < manutencao.DataHoraManutencao && v.DataHoraChegada >= manutencao.DataHoraManutencao);

                if (emVoo)
                {
                    ValidationContext.AddFailure("A aeronave selecionada estará em voo nesse horário.");
                }
            }
        });
    }
}