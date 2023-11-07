using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SpinFeatures.Queries.GetSpin;
public sealed class GetSpinHandler : IRequestHandler<GetSpinRequest, GetSpinResponse>
{
    private readonly ISpinService spinService;
    private readonly IMapper mapper;

    public GetSpinHandler(IMapper _mapper, ISpinService _spinService)
    {
        spinService = _spinService;
        mapper = _mapper;
    }

    public async Task<GetSpinResponse> Handle(GetSpinRequest request, CancellationToken cancellationToken)
    {
        Spin spin =  await spinService.GetSpin(request.SpinID);
        return mapper.Map<GetSpinResponse>(spin);
    }
}
