using CIAAerea.ViewModels.Cancelamento;
using CIAArea.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CIAAerea.Validators.Cancelamento;

public class CancelarVooValidator : AbstractValidator<CancelarVooViewModel>
{
    private readonly CiaAereaContext _context;

    public CancelarVooValidator(CiaAereaContext context)
    {
        _context = context;

        RuleFor(c => c).Custom((MotivoCancelamento, validationContext) =>
        {
            var voo = _context.Voos.Include(v => v.Cancelamento).FirstOrDefault(v => v.Id == MotivoCancelamento.VooId);
            if (voo == null)
            {
                validationContext.AddFailure("Id de voo inválido");
            }
            else
            {
                if (voo.Cancelamento != null)
                {
                    validationContext.AddFailure("Este voo já foi cancelado");
                }

                if (voo.DataHoraPartida < DateTime.Now && voo.DataHoraChegada >= DateTime.Now)
                {
                    validationContext.AddFailure("Não é possível cancelar um voo em andamento.");
                }

                if (voo.DataHoraChegada <= DateTime.Now)
                {
                    validationContext.AddFailure("Não é possível cancelar um voo já finalizado");
                }
            }
        });

    }
}