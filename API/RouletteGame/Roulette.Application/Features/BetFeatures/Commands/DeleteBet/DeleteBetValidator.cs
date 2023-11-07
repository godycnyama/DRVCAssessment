using FluentValidation;

namespace Roulette.Application.Features.BetFeatures.Commands.DeleteBet;
public sealed class DeleteBetValidator : AbstractValidator<DeleteBetRequest>
{
    public DeleteBetValidator()
    {
        RuleFor(x => x.BetID).NotEmpty();
    }
}
