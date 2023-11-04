using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Application.Features.SpinFeatures.DeleteSpin;
public sealed class DeleteSpinValidator : AbstractValidator<DeleteSpinRequest>
{
    public DeleteSpinValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
