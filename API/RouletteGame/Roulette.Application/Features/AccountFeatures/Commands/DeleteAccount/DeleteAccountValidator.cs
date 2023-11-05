using FluentValidation;

namespace Roulette.Application.Features.AccountFeatures.Commands.DeleteAccount;
public sealed class DeleteAccountValidator : AbstractValidator<DeleteAccountRequest>
{
    public DeleteAccountValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
