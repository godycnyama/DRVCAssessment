using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.SpinFeatures.Queries.GetSpins;
public sealed class GetSpinsHandler : IRequestHandler<GetSpinsRequest, List<GetSpinsResponse>>
{
    private readonly ISpinService spinService;
    private readonly IMapper mapper;

    public GetSpinsHandler(ISpinService _spinService, IMapper _mapper)
    {
        spinService = _spinService;
        mapper = _mapper;
    }
    
    public async Task<List<GetSpinsResponse>> Handle(GetSpinsRequest request, CancellationToken cancellationToken)
    {
        var spins = await spinService.GetAllSpins();
        return mapper.Map<List<GetSpinsResponse>>(spins);
    }
}