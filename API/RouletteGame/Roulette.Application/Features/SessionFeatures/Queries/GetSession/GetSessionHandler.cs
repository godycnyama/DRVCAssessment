using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SessionFeatures.Queries.GetSession;
public sealed class GetSessionHandler : IRequestHandler<GetSessionRequest, GetSessionResponse>
{
    private readonly ISessionService sessionService;
    private readonly IMapper mapper;

    public GetSessionHandler(IMapper _mapper, ISessionService _sessionService)
    {
        sessionService = _sessionService;
        mapper = _mapper;
    }

    public async Task<GetSessionResponse> Handle(GetSessionRequest request, CancellationToken cancellationToken)
    {
        Session session =  await sessionService.GetSession(request.SessionID);
        return mapper.Map<GetSessionResponse>(session);
    }
}
