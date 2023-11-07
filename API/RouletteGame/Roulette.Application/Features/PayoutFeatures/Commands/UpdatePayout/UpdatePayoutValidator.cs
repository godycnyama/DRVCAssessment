using FluentValidation;

namespace Roulette.Application.Features.PayoutFeatures.Commands.UpdatePayout;
public sealed class UpdatePayoutValidator : AbstractValidator<UpdatePayoutRequest>
{
    public UpdatePayoutValidator()
    {
        RuleFor(x => x.PayoutID).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Currency).NotEmpty();
        RuleFor(x => x.AccountID).NotEmpty();
        RuleFor(x => x.SessionID).NotEmpty();
        RuleFor(x => x.BetID).NotEmpty();
    }
}
