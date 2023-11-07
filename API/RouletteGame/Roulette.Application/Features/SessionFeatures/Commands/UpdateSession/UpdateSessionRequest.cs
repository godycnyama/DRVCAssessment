using MediatR;

namespace Roulette.Application.Features.SessionFeatures.Commands.UpdateSession;

public sealed record UpdateSessionRequest(int SessionID, decimal WinningBonus, string Currency) : IRequest<UpdateSessionResponse>;
