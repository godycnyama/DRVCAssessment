using FluentValidation;

namespace Roulette.Application.Features.SpinFeatures.Commands.DeleteSpin;
public sealed class DeleteSpinValidator : AbstractValidator<DeleteSpinRequest>
{
    public DeleteSpinValidator()
    {
        RuleFor(x => x.SpinID).NotEmpty();
    }
}
