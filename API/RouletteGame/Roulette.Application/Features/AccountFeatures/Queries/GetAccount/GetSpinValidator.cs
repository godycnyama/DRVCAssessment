using FluentValidation;

namespace Roulette.Application.Features.SpinFeatures.GetSpin;
public sealed class GetSpinValidator : AbstractValidator<GetSpinRequest>
{
    public GetSpinValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
