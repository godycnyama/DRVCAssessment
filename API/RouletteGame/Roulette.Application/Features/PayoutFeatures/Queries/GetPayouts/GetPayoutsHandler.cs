using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.PayoutFeatures.Queries.GetPayouts;
public sealed class GetPayoutsHandler : IRequestHandler<GetPayoutsRequest, List<GetPayoutsResponse>>
{
    private readonly IPayoutService payoutService;
    private readonly IMapper mapper;

    public GetPayoutsHandler(IPayoutService _payoutService, IMapper _mapper)
    {
        payoutService = _payoutService;
        mapper = _mapper;
    }
    
    public async Task<List<GetPayoutsResponse>> Handle(GetPayoutsRequest request, CancellationToken cancellationToken)
    {
        var payouts = await payoutService.GetAllPayouts();
        return mapper.Map<List<GetPayoutsResponse>>(payouts);
    }
}