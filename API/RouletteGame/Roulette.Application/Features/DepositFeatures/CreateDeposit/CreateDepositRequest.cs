using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Roulette.Application.Features.DepositFeatures.CreateDeposit;

public sealed record CreateDepositRequest(decimal Amount, int Number) : IRequest<CreateDepositResponse>;
