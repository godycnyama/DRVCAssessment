using MediatR;

namespace Roulette.Application.Features.BetFeatures.CreateBet;

public sealed record CreateBetRequest(decimal Amount, int Number) : IRequest<CreateBetResponse>;
