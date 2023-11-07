using FluentValidation;

namespace Roulette.Application.Features.BetFeatures.Commands.UpdateBet;
public sealed class UpdateBetValidator : AbstractValidator<UpdateBetRequest>
{
    public UpdateBetValidator()
    {
        RuleFor(x => x.BetID).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
        RuleFor(x => x.AccountID).NotEmpty();
        RuleFor(x => x.SessionID).NotEmpty();
    }
}
