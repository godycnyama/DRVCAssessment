using MediatR;

namespace Roulette.Application.Features.SessionFeatures.Commands.CreateSession;

public sealed record CreateSessionRequest(decimal WinningBonus, string Currency) : IRequest<CreateSessionResponse>;
