using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.SpinFeatures.GetSpins;
public sealed class GetSpinsHandler : IRequestHandler<GetSpinsRequest, List<GetSpinsResponse>>
{
    private readonly ISpinService betService;
    private readonly IMapper mapper;

    public GetSpinsHandler(ISpinService _betService, IMapper _mapper)
    {
        betService = _betService;
        mapper = _mapper;
    }
    
    public async Task<List<GetSpinsResponse>> Handle(GetSpinsRequest request, CancellationToken cancellationToken)
    {
        var bets = await betService.GetAllSpins();
        return mapper.Map<List<GetSpinsResponse>>(bets);
    }
}