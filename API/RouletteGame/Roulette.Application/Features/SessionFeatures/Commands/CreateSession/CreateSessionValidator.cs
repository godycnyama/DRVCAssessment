using FluentValidation;

namespace Roulette.Application.Features.SessionFeatures.Commands.CreateSession;
public sealed class CreateSessionValidator : AbstractValidator<CreateSessionRequest>
{
    public CreateSessionValidator()
    {
        RuleFor(x => x.WinningBonus).NotEmpty();
        RuleFor(x => x.Currency).NotEmpty().MaximumLength(4);


    }
}
