using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.SpinFeatures.Commands.DeleteSpin;
public sealed class DeleteSpinHandler : IRequestHandler<DeleteSpinRequest, DeleteSpinResponse>
{
    private readonly ISpinService spinService;
    private readonly IMapper mapper;

    public DeleteSpinHandler(IMapper _mapper, ISpinService _spinService)
    {
        spinService = _spinService;
        mapper = _mapper;
    }

    public async Task<DeleteSpinResponse> Handle(DeleteSpinRequest request, CancellationToken cancellationToken)
    {
        return await spinService.DeleteSpin(request.SpinID);
    }
}
