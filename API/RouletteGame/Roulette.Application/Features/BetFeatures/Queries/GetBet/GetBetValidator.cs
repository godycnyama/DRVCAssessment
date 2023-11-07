using FluentValidation;

namespace Roulette.Application.Features.BetFeatures.Queries.GetBet;
public sealed class GetBetValidator : AbstractValidator<GetBetRequest>
{
    public GetBetValidator()
    {
        RuleFor(x => x.BetID).NotEmpty();
    }
}
