using MediatR;

namespace Roulette.Application.Features.PayoutFeatures.Queries.GetPayouts;
public sealed record GetPayoutsRequest : IRequest<List<GetPayoutsResponse>>;