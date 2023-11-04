using MediatR;

namespace Roulette.Application.Features.BetFeatures.UpdateBet;

public sealed record UpdateBetRequest(int Id, decimal Amount, int Number) : IRequest<UpdateBetResponse>;
