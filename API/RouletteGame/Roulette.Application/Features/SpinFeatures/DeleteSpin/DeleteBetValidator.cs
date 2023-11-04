using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Application.Features.BetFeatures.DeleteBet;
public sealed class DeleteBetValidator : AbstractValidator<DeleteBetRequest>
{
    public DeleteBetValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
