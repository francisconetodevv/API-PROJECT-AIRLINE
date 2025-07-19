using CIAArea.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CIAAerea.Validators;


public class ExcluirAeronaveValidator : AbstractValidator<int>
{
    private readonly CiaAereaContext _context;

    public ExcluirAeronaveValidator(CiaAereaContext context)
    {
        _context = context;

        RuleFor(id => _context.Aeronaves.Include(a => a.Voos).Include(a => a.Manutencoes).FirstOrDefault(a => a.Id == id))
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Id da Aeronave inválido")
            .Must(aeronave => aeronave!.Voos.Count == 0).WithMessage("Não é possível excluir uma aeronave que já realizou voos")
            .Must(aeronave => aeronave!.Manutencoes.Count == 0).WithMessage("Não é possível excluir uma aeronave que já realizou manutenções");

    }
}