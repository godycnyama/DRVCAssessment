using MediatR;

namespace Roulette.Application.Features.SessionFeatures.Commands.DeleteSession;

public sealed record DeleteSessionRequest(int SessionID) : IRequest<DeleteSessionResponse>;
