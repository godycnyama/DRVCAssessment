using FluentValidation;

namespace Roulette.Application.Features.BetFeatures.DeleteBet;
public sealed class DeleteBetValidator : AbstractValidator<DeleteBetRequest>
{
    public DeleteBetValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
