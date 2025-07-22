using CIAAerea.ViewModels.Piloto;
using CIAArea.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CIAAerea.Validators.Piloto;

public class ExcluirPilotoValidator : AbstractValidator<int>
{

    private readonly CiaAereaContext _context;

    public ExcluirPilotoValidator(CiaAereaContext context)
    {
        _context = context;

        RuleFor(id => _context.Pilotos.Include(p => p.Voos).FirstOrDefault(p => p.Id == id))
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id do piloto é inválido ou não encontrado.")
            .Must(piloto => piloto!.Voos.Count == 0).WithMessage("Não é possível excluir um piloto que está vinculado a voos.");
    }
}