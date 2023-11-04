using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Application.Features.BetFeatures.UpdateBet;
public sealed class UpdateBetValidator : AbstractValidator<UpdateBetRequest>
{
    public UpdateBetValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
    }
}
