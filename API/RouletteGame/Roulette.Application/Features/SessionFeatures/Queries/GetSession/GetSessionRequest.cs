using MediatR;

namespace Roulette.Application.Features.SessionFeatures.Queries.GetSession;

public sealed record GetSessionRequest(int SessionID) : IRequest<GetSessionResponse>;
