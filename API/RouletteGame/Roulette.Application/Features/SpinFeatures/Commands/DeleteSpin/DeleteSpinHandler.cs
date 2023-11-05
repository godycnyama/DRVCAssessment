using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.SpinFeatures.Commands.DeleteSpin;
public sealed class DeleteSpinHandler : IRequestHandler<DeleteSpinRequest, DeleteSpinResponse>
{
    private readonly ISpinService payoutService;
    private readonly IMapper mapper;

    public DeleteSpinHandler(IMapper _mapper, ISpinService _payoutService)
    {
        payoutService = _payoutService;
        mapper = _mapper;
    }

    public async Task<DeleteSpinResponse> Handle(DeleteSpinRequest request, CancellationToken cancellationToken)
    {
        return await payoutService.DeleteSpin(request.Id);
    }
}
