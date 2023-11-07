using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.PayoutFeatures.Commands.UpdatePayout;
public sealed class UpdatePayoutHandler : IRequestHandler<UpdatePayoutRequest, UpdatePayoutResponse>
{
    private readonly IPayoutService payoutService;
    private readonly IMapper mapper;

    public UpdatePayoutHandler(IMapper _mapper, IPayoutService _payoutService)
    {
        payoutService = _payoutService;
        mapper = _mapper;
    }

    public async Task<UpdatePayoutResponse> Handle(UpdatePayoutRequest request, CancellationToken cancellationToken)
    {
        Payout payout = mapper.Map<Payout>(request);
        var response = await payoutService.UpdatePayout(payout);
        return mapper.Map<UpdatePayoutResponse>(response);
    }
}
