using FluentValidation;

namespace Roulette.Application.Features.BetFeatures.Commands.CreateBet;
public sealed class CreateBetValidator : AbstractValidator<CreateBetRequest>
{
    public CreateBetValidator()
    {
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
        RuleFor(x => x.AccountID).NotEmpty();
        RuleFor(x => x.SessionID).NotEmpty();
    }
}
