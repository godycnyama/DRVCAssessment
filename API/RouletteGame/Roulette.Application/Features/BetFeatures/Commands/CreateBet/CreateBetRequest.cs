using MediatR;

namespace Roulette.Application.Features.BetFeatures.Commands.CreateBet;

public sealed record CreateBetRequest(decimal Amount, int Number) : IRequest<CreateBetResponse>;
