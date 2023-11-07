using FluentValidation;

namespace Roulette.Application.Features.SpinFeatures.Commands.UpdateSpin;
public sealed class UpdateSpinValidator : AbstractValidator<UpdateSpinRequest>
{
    public UpdateSpinValidator()
    {
        RuleFor(x => x.SpinID).NotEmpty();
        RuleFor(x => x.AccountID).NotEmpty();
        RuleFor(x => x.SessionID).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
    }
}
