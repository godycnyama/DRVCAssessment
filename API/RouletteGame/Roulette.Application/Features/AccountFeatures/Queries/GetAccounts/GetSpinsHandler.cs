using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.SpinFeatures.GetSpins;
public sealed class GetSpinsHandler : IRequestHandler<GetSpinsRequest, List<GetSpinsResponse>>
{
    private readonly ISpinService payoutService;
    private readonly IMapper mapper;

    public GetSpinsHandler(ISpinService _payoutService, IMapper _mapper)
    {
        payoutService = _payoutService;
        mapper = _mapper;
    }
    
    public async Task<List<GetSpinsResponse>> Handle(GetSpinsRequest request, CancellationToken cancellationToken)
    {
        var payouts = await payoutService.GetAllSpins();
        return mapper.Map<List<GetSpinsResponse>>(payouts);
    }
}