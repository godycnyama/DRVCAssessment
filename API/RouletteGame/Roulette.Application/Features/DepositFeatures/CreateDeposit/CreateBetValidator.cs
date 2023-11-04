using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Application.Features.BetFeatures.CreateBet;
public sealed class CreateBetValidator : AbstractValidator<CreateBetRequest>
{
    public CreateBetValidator()
    {
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Number).NotEmpty();
    }
}
