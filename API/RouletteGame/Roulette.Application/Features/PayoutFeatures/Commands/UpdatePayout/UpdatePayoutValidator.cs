using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Application.Features.PayoutFeatures.Commands.UpdatePayout;
public sealed class UpdatePayoutValidator : AbstractValidator<UpdatePayoutRequest>
{
    public UpdatePayoutValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty();
    }
}
