using FluentValidation;

namespace Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
public sealed class CreateAccountValidator : AbstractValidator<CreateAccountRequest>
{
    public CreateAccountValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.UserName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Balance).NotEmpty();
        RuleFor(x => x.Currency).NotEmpty().MaximumLength(4);
    }
}
