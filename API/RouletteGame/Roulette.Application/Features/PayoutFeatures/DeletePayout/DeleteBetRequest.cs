using MediatR;

namespace Roulette.Application.Features.BetFeatures.DeleteBet;

public sealed record DeleteBetRequest(int Id) : IRequest<DeleteBetResponse>;
