using MediatR;

namespace Roulette.Application.Features.BetFeatures.GetBets;
public sealed record GetBetsRequest : IRequest<List<GetBetsResponse>>;