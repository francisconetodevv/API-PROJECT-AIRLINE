using CIAAerea.ViewModels.Manutencao;
using CIAArea.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CIAAerea.Validators.Manutencao;

public class ExcluirManutencaoValidator : AbstractValidator<int>
{
    private readonly CiaAereaContext _context;

    public ExcluirManutencaoValidator(CiaAereaContext context)
    {
        _context = context;

        RuleFor(id => _context.Manutencoes.Find(id))
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("ID da manutenção é inválido")
            .Must(manutencao => manutencao!.DataHoraManutencao > DateTime.Now).WithMessage("Não é possível excluir uma manutenção que já ocorreu.");

    }
}