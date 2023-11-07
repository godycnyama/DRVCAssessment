using MediatR;

namespace Roulette.Application.Features.PayoutFeatures.Queries.GetPayout;

public sealed record GetPayoutRequest(int PayoutID) : IRequest<GetPayoutResponse>;
