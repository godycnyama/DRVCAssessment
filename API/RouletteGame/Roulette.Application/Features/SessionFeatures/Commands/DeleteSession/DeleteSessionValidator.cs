using FluentValidation;

namespace Roulette.Application.Features.SessionFeatures.Commands.DeleteSession;
public sealed class DeleteSessionValidator : AbstractValidator<DeleteSessionRequest>
{
    public DeleteSessionValidator()
    {
        RuleFor(x => x.SessionID).NotEmpty();
    }
}
