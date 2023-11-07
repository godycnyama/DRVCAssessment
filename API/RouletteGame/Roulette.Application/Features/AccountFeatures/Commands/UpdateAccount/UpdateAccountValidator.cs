using FluentValidation;

namespace Roulette.Application.Features.AccountFeatures.Commands.UpdateAccount;
public sealed class UpdateAccountValidator : AbstractValidator<UpdateAccountRequest>
{
    public UpdateAccountValidator()
    {
        RuleFor(x => x.AccountID).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.UserName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Balance).NotEmpty();
        RuleFor(x => x.Currency).NotEmpty().MaximumLength(4);
    }
}
