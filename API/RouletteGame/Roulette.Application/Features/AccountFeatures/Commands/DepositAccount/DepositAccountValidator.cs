using FluentValidation;

namespace Roulette.Application.Features.AccountFeatures.Commands.DepositAccount;
public sealed class DepositAccountValidator : AbstractValidator<DepositAccountRequest>
{
    public DepositAccountValidator()
    {
        RuleFor(x => x.AccountID).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty();
    }
}
