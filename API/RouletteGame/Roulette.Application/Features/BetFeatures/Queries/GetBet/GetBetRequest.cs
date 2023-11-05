using MediatR;

namespace Roulette.Application.Features.BetFeatures.Queries.GetBet;

public sealed record GetBetRequest(int Id) : IRequest<GetBetResponse>;
