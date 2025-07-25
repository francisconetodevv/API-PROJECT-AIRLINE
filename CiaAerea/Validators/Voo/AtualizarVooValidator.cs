using CIAAerea.ViewModels.Voo;
using CIAArea.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CIAAerea.Validators.Voo;


public class AtualizarVooValidator : AbstractValidator<AtualizarVooViewModel>
{
    private readonly CiaAereaContext _context;

    public AtualizarVooValidator(CiaAereaContext context)
    {
        _context = context;

        RuleFor(v => v.Origem)
            .NotEmpty().WithMessage("A origem do voo é obrigatória.")
            .Length(3).WithMessage("Aeroporto de origem inválido");

        RuleFor(v => v.Destino)
            .NotEmpty().WithMessage("O destino do voo é obrigatório.")
            .Length(3).WithMessage("Aeroporto de destino inválido");

        RuleFor(v => v)
            .Must(voo => voo.DataHoraPartida > DateTime.Now).WithMessage("A data e hora de partida devem ser futuras.")
            .Must(voo => voo.DataHoraChegada > voo.DataHoraPartida).WithMessage("A data e hora de chegada devem ser posteriores à data e hora de partida.");

        // Regras customizadas, pois envolvem lógica de negócio mais complexa
        // Verifica se o piloto está disponível
        // Verifica se a aeronave está disponível
        // Verifica se a aeronave não está em manutenção
        RuleFor(v => v).Custom((voo, validationContext) =>
        {
            var piloto = _context.Pilotos
                                 .Include(p => p.Voos)
                                 .FirstOrDefault(p => p.Id == voo.PilotoId);

            if (piloto == null)
            {
                validationContext.AddFailure("Piloto inválido");
            }
            else
            {
                var pilotoEmVoo = piloto.Voos.Any(v => v.Id != voo.Id && 
                                                       (v.DataHoraPartida <= voo.DataHoraPartida && v.DataHoraChegada >= voo.DataHoraChegada) ||
                                                       (v.DataHoraPartida >= voo.DataHoraPartida && v.DataHoraChegada <= voo.DataHoraChegada) ||
                                                       (v.DataHoraChegada >= voo.DataHoraPartida && v.DataHoraChegada <= voo.DataHoraChegada));

                if (pilotoEmVoo)
                {
                    validationContext.AddFailure("Este piloto já está escalado para outro voo no horário especificado.");
                }
            }

            var aeronave = _context.Aeronaves
                                   .Include(a => a.Voos)
                                   .Include(a => a.Manutencoes)
                                   .FirstOrDefault(a => a.Id == voo.AeronaveId);
            if (aeronave == null)
            {
                validationContext.AddFailure("Aeronave inválida");
            }
            else
            {
                var aeronaveEmVoo = aeronave.Voos.Any(v => v.Id != voo.Id &&
                                                       (v.DataHoraPartida <= voo.DataHoraPartida && v.DataHoraChegada >= voo.DataHoraChegada) ||
                                                       (v.DataHoraPartida >= voo.DataHoraPartida && v.DataHoraChegada <= voo.DataHoraChegada) ||
                                                       (v.DataHoraChegada >= voo.DataHoraPartida && v.DataHoraChegada <= voo.DataHoraChegada));
                if (aeronaveEmVoo)
                {
                    validationContext.AddFailure("Essa aeronave estará em voo no horário especificado.");
                }

                var aeronaveEmManutencao = aeronave.Manutencoes.Any(m => m.DataHoraManutencao >= voo.DataHoraPartida && m.DataHoraManutencao <= voo.DataHoraChegada); 
                
                if (aeronaveEmManutencao)
                {
                    validationContext.AddFailure("Essa aeronave estará em manutenção no horário especificado.");
                }
            }
        });
    }
}