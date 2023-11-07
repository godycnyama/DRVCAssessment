using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.SessionFeatures.Commands.DeleteSession;
public sealed class DeleteSessionHandler : IRequestHandler<DeleteSessionRequest, DeleteSessionResponse>
{
    private readonly ISessionService payoutService;
    private readonly IMapper _mapper;

    public DeleteSessionHandler(IMapper mapper, ISessionService _payoutService)
    {
        payoutService = _payoutService;
        _mapper = mapper;
    }

    public async Task<DeleteSessionResponse> Handle(DeleteSessionRequest request, CancellationToken cancellationToken)
    {
        return await payoutService.DeleteSession(request.SessionID);
    }
}
