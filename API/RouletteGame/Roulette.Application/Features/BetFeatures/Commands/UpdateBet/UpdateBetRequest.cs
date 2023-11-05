using MediatR;

namespace Roulette.Application.Features.BetFeatures.Commands.UpdateBet;

public sealed record UpdateBetRequest(int Id, decimal Amount, int Number) : IRequest<UpdateBetResponse>;
