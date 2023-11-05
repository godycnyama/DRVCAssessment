using MediatR;

namespace Roulette.Application.Features.BetFeatures.Commands.DeleteBet;

public sealed record DeleteBetRequest(int Id) : IRequest<DeleteBetResponse>;
