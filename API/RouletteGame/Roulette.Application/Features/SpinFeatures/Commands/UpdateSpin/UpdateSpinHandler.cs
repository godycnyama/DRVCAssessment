using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SpinFeatures.Commands.UpdateSpin;
public sealed class UpdateSpinHandler : IRequestHandler<UpdateSpinRequest, UpdateSpinResponse>
{
    private readonly ISpinService spinService;
    private readonly IMapper mapper;

    public UpdateSpinHandler(IMapper _mapper, ISpinService _spinService)
    {
        spinService = _spinService;
        mapper = _mapper;
    }

    public async Task<UpdateSpinResponse> Handle(UpdateSpinRequest request, CancellationToken cancellationToken)
    {
        Spin spin = mapper.Map<Spin>(request);
        var response = await spinService.UpdateSpin(spin);
        return mapper.Map<UpdateSpinResponse>(response);
    }
}
