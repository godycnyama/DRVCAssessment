using MediatR;

namespace Roulette.Application.Features.SessionFeatures.Queries.GetSessions;
public sealed record GetSessionsRequest : IRequest<List<GetSessionsResponse>>;