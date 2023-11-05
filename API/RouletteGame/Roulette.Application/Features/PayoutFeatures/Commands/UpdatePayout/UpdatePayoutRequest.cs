using MediatR;

namespace Roulette.Application.Features.PayoutFeatures.Commands.UpdatePayout;

public sealed record UpdatePayoutRequest(int Id, decimal Amount) : IRequest<UpdatePayoutResponse>;
