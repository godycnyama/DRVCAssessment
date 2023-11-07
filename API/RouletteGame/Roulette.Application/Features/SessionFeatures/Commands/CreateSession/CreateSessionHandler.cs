using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Features.PayoutFeatures.Commands.CreatePayout;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SessionFeatures.Commands.CreateSession;
public sealed class CreateSessionHandler : IRequestHandler<CreateSessionRequest, CreateSessionResponse>
{
    private readonly ISessionService sessionService;
    private readonly IMapper mapper;

    public CreateSessionHandler(IMapper _mapper, ISessionService _sessionService)
    {
        sessionService = _sessionService;
        mapper = _mapper;
    }

    public async Task<CreateSessionResponse> Handle(CreateSessionRequest request, CancellationToken cancellationToken)
    {
        Session session = mapper.Map<Session>(request);
        var response = await sessionService.CreateSession(session);
        return mapper.Map<CreateSessionResponse>(response);


    }
}
