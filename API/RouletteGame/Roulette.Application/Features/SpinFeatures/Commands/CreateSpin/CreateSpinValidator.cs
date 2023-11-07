using FluentValidation;

namespace Roulette.Application.Features.SpinFeatures.Commands.CreateSpin;
public sealed class CreateSpinValidator : AbstractValidator<CreateSpinRequest>
{
    public CreateSpinValidator()
    {
        RuleFor(x => x.AccountID).NotEmpty();
        RuleFor(x => x.SessionID).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
    }
}
