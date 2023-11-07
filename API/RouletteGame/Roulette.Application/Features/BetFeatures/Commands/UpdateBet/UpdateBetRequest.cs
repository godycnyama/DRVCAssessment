using MediatR;

namespace Roulette.Application.Features.BetFeatures.Commands.UpdateBet;

public sealed record UpdateBetRequest(int BetID, decimal Amount, string Currency, int Number, int AccountID, int SessionID) : IRequest<UpdateBetResponse>;
