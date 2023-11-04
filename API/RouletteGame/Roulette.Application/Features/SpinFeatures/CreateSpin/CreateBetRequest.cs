using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Roulette.Application.Features.BetFeatures.CreateBet;

public sealed record CreateBetRequest(decimal Amount, int Number) : IRequest<CreateBetResponse>;
