using FluentValidation;

namespace Roulette.Application.Features.PayoutFeatures.Commands.CreatePayout;
public sealed class CreatePayoutValidator : AbstractValidator<CreatePayoutRequest>
{
    public CreatePayoutValidator()
    {
        RuleFor(x => x.AccountID).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Currency).NotEmpty();
        RuleFor(x => x.SessionID).NotEmpty();
        RuleFor(x => x.BetID).NotEmpty();

    }
}
