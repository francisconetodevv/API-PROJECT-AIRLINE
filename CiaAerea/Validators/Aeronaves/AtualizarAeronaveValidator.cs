using CIAArea.Contexts;
using CIAArea.ViewModels;
using FluentValidation;

namespace CIAAerea.Validators;

public class AtualizarAeronaveValidator : AbstractValidator<AtualizarAeronaveViewModel>
{

    private readonly CiaAereaContext _context;

    public AtualizarAeronaveValidator(CiaAereaContext context)
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
            .MaximumLength(10).WithMessage("Comprimento máximo: 10 caracteres");

        RuleFor(a => a)
            .Must(aeronave => _context.Aeronaves.Count(a => a.Codigo == aeronave.Codigo && a.Id != aeronave.Id) == 0).WithMessage("Já existe uma aeronave com esse código");
        // Acima ele está checando se o código não existe já no banco.
        // Se existir, ele vai esbarrar e retornar a msg
    }
}