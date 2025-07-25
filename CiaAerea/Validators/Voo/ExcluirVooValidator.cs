using CIAArea.Contexts;
using FluentValidation;

namespace CIAAerea.Validators.Voo;

public class ExcluirVooValidator : AbstractValidator<int>
{
    private readonly CiaAereaContext _context;

    public ExcluirVooValidator(CiaAereaContext context)
    {
        _context = context;

        RuleFor(id => _context.Voos.Find(id))
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Voo não encontrado. Verifique o ID informado.")
            .Must(voo => voo!.DataHoraChegada >= DateTime.Now).WithMessage("Não é possível excluir um voo que já ocorreu.");
    }
}