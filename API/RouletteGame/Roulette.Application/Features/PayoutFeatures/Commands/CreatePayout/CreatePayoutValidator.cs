using FluentValidation;

namespace Roulette.Application.Features.PayoutFeatures.Commands.CreatePayout;
public sealed class CreatePayoutValidator : AbstractValidator<CreatePayoutRequest>
{
    public CreatePayoutValidator()
    {
        RuleFor(x => x.Amount).NotEmpty();
    }
}
