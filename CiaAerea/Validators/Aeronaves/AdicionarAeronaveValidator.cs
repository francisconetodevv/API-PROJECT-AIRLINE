using CIAArea.Contexts;
using CIAArea.ViewModels;
using FluentValidation;

namespace CIAAerea.Validators;

public class AdicionarAeronaveValidator : AbstractValidator<AdicionarAeronaveViewModel>
{

    private readonly CiaAereaContext _context;

    public AdicionarAeronaveValidator(CiaAereaContext context)
    {
        _context = context;

        // Criando as regras de validação, com os métodos em cadeia

        RuleFor(a => a.Fabricante)
            .NotEmpty().WithErrorCode("Informação obrigatória")
            .MaximumLength(50).WithMessage("Comprimento máximo: 50 caracteres");

        RuleFor(a => a.Modelo)
            .NotEmpty().WithErrorCode("Informação obrigatória")
            .MaximumLength(50).WithMessage("Comprimento máximo: 50 caracteres");

        RuleFor(a => a.Codigo)
            .NotEmpty().WithErrorCode("Informação obrigatória")
            .MaximumLength(10).WithMessage("Comprimento máximo: 10 caracteres")
            .Must(codigo => !_context.Aeronaves.Any(aeronave => aeronave.Codigo == codigo)).WithMessage("Aeronave já existente");
        // Acima ele está checando se o código não existe já no banco.
        // Se existir, ele vai esbarrar e retornar a msg
    }
}