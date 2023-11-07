using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.SessionFeatures.Queries.GetSessions;
public sealed class GetSessionsHandler : IRequestHandler<GetSessionsRequest, List<GetSessionsResponse>>
{
    private readonly ISessionService sessionService;
    private readonly IMapper mapper;

    public GetSessionsHandler(ISessionService _sessionService, IMapper _mapper)
    {
        sessionService = _sessionService;
        mapper = _mapper;
    }
    
    public async Task<List<GetSessionsResponse>> Handle(GetSessionsRequest request, CancellationToken cancellationToken)
    {
        var sessions = await sessionService.GetAllSessions();
        return mapper.Map<List<GetSessionsResponse>>(sessions);
    }
}