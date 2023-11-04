using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SpinFeatures.GetSpin;
public sealed class GetSpinHandler : IRequestHandler<GetSpinRequest, GetSpinResponse>
{
    private readonly ISpinService betService;
    private readonly IMapper mapper;

    public GetSpinHandler(IMapper _mapper, ISpinService _betService)
    {
        betService = _betService;
        mapper = _mapper;
    }

    public async Task<GetSpinResponse> Handle(GetSpinRequest request, CancellationToken cancellationToken)
    {
        Spin bet =  await betService.GetSpin(request.Id, cancellationToken);
        return mapper.Map<GetSpinResponse>(bet);
    }
}
