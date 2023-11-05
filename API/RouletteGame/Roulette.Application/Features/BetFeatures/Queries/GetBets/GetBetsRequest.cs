using MediatR;

namespace Roulette.Application.Features.BetFeatures.Queries.GetBets;
public sealed record GetBetsRequest : IRequest<List<GetBetsResponse>>;