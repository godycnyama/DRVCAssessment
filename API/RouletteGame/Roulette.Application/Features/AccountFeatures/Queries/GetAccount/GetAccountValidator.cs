using FluentValidation;

namespace Roulette.Application.Features.AccountFeatures.Queries.GetAccount; 
public sealed class GetAccountValidator : AbstractValidator<GetAccountRequest>
{
    public GetAccountValidator()
    {
        RuleFor(x => x.AccountID).NotEmpty();
    }
}
