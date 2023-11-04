using FluentValidation;

namespace Roulette.Application.Features.BetFeatures.GetBet;
public sealed class GetBetValidator : AbstractValidator<GetBetRequest>
{
    public GetBetValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
