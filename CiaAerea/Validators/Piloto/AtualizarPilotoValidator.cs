using CIAAerea.ViewModels.Piloto;
using CIAArea.Contexts;
using FluentValidation;

namespace CIAAerea.Validators.Piloto;

public class AtualizarPilotoValidator : AbstractValidator<AtualizarPilotoViewModel>
{

    private readonly CiaAereaContext _context;

    public AtualizarPilotoValidator(CiaAereaContext context)
    {
        _context = context;

        // Criando as regras de validação, com os métodos em cadeia

        RuleFor(p => p.Nome)
            .NotEmpty().WithErrorCode("Informação obrigatória")
            .MaximumLength(100).WithMessage("Comprimento máximo: 50 caracteres");

        RuleFor(p => p.Matricula)
            .NotEmpty().WithErrorCode("Informação obrigatória")
            .MaximumLength(10).WithMessage("Comprimento máximo: 10 caracteres");

        RuleFor(p => p)
            .Must(piloto => _context.Pilotos.Count(p => p.Matricula == piloto.Matricula && p.Id != piloto.Id)  == 0).WithMessage("Piloto já existente");
    }
}