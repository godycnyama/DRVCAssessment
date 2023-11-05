using FluentValidation;

namespace Roulette.Application.Features.SpinFeatures.Queries.GetSpin;
public sealed class GetSpinValidator : AbstractValidator<GetSpinRequest>
{
    public GetSpinValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
