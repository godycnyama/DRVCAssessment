using FluentValidation;

namespace Roulette.Application.Features.PayoutFeatures.Queries.GetPayout;
public sealed class GetPayoutValidator : AbstractValidator<GetPayoutRequest>
{
    public GetPayoutValidator()
    {
        RuleFor(x => x.PayoutID).NotEmpty();
    }
}
