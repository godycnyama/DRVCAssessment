using FluentValidation;

namespace Roulette.Application.Features.SessionFeatures.Queries.GetSession;
public sealed class GetSessionValidator : AbstractValidator<GetSessionRequest>
{
    public GetSessionValidator()
    {
        RuleFor(x => x.SessionID).NotEmpty();
    }
}
