using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Features.SessionFeatures.Commands.CreateSession;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SessionFeatures.Commands.UpdateSession;
public sealed class UpdateSessionHandler : IRequestHandler<UpdateSessionRequest, UpdateSessionResponse>
{
    private readonly ISessionService payoutService;
    private readonly IMapper mapper;

    public UpdateSessionHandler(IMapper _mapper, ISessionService _payoutService)
    {
        payoutService = _payoutService;
        mapper = _mapper;
    }

    public async Task<UpdateSessionResponse> Handle(UpdateSessionRequest request, CancellationToken cancellationToken)
    {
        Session payout = mapper.Map<Session>(request);
        var response = await payoutService.UpdateSession(payout);
        return mapper.Map<UpdateSessionResponse>(response);
    }
}
