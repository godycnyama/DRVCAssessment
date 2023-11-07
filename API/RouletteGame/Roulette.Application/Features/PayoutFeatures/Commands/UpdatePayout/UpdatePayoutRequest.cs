using MediatR;

namespace Roulette.Application.Features.PayoutFeatures.Commands.UpdatePayout;

public sealed record UpdatePayoutRequest(int PayoutID, decimal Amount, string Currency, int AccountID, int SessionID, int BetID) : IRequest<UpdatePayoutResponse>;
