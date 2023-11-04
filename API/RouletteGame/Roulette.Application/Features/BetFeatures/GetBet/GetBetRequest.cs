using MediatR;

namespace Roulette.Application.Features.BetFeatures.GetBet;

public sealed record GetBetRequest(int Id) : IRequest<GetBetResponse>;
