using FluentValidation;

namespace Roulette.Application.Features.PayoutFeatures.Commands.DeletePayout;
public sealed class DeletePayoutValidator : AbstractValidator<DeletePayoutRequest>
{
    public DeletePayoutValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
