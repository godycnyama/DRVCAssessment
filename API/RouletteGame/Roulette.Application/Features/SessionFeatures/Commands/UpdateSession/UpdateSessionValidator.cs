using FluentValidation;

namespace Roulette.Application.Features.SessionFeatures.Commands.UpdateSession;
public sealed class UpdateSessionValidator : AbstractValidator<UpdateSessionRequest>
{
    public UpdateSessionValidator()
    {
        RuleFor(x => x.SessionID).NotEmpty();
        RuleFor(x => x.WinningBonus).NotEmpty();
        RuleFor(x => x.Currency).NotEmpty().MaximumLength(4); 
    }
}
