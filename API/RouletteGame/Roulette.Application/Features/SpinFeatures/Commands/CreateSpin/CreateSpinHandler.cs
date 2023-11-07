using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Features.SessionFeatures.Commands.UpdateSession;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SpinFeatures.Commands.CreateSpin;
public sealed class CreateSpinHandler : IRequestHandler<CreateSpinRequest, CreateSpinResponse>
{
    private readonly ISpinService spinService;
    private readonly IMapper mapper;

    public CreateSpinHandler(IMapper _mapper, ISpinService _spinService)
    {
        spinService = _spinService;
        mapper = _mapper;
    }

    public async Task<CreateSpinResponse> Handle(CreateSpinRequest request, CancellationToken cancellationToken)
    {
        Spin spin = mapper.Map<Spin>(request);
        var response = await spinService.CreateSpin(spin);
        return mapper.Map<CreateSpinResponse>(response);
    }
}
