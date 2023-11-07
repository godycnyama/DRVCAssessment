using MediatR;

namespace Roulette.Application.Features.BetFeatures.Commands.CreateBet;

public sealed record CreateBetRequest(decimal Amount, string Currency, int Number, int AccountID, int SessionID) : IRequest<CreateBetResponse>;
