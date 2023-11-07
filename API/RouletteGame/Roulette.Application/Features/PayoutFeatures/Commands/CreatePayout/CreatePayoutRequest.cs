using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Roulette.Application.Features.PayoutFeatures.Commands.CreatePayout;

public sealed record CreatePayoutRequest(decimal Amount,string Currency,int AccountID, int SessionID, int BetID) : IRequest<CreatePayoutResponse>;
