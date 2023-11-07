using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.PayoutFeatures.Queries.GetPayout;
public sealed class GetPayoutHandler : IRequestHandler<GetPayoutRequest, GetPayoutResponse>
{
    private readonly IPayoutService payoutService;
    private readonly IMapper mapper;

    public GetPayoutHandler(IMapper _mapper, IPayoutService _payoutService)
    {
        payoutService = _payoutService;
        mapper = _mapper;
    }

    public async Task<GetPayoutResponse> Handle(GetPayoutRequest request, CancellationToken cancellationToken)
    {
        Payout payout =  await payoutService.GetPayout(request.PayoutID);
        return mapper.Map<GetPayoutResponse>(payout);
    }
}
