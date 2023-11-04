using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SpinFeatures.DeleteSpin;
public sealed class DeleteSpinHandler : IRequestHandler<DeleteSpinRequest, DeleteSpinResponse>
{
    private readonly ISpinService betService;
    private readonly IMapper mapper;

    public DeleteSpinHandler(IMapper _mapper, ISpinService _betService)
    {
        betService = _betService;
        mapper = _mapper;
    }

    public async Task<DeleteSpinResponse> Handle(DeleteSpinRequest request, CancellationToken cancellationToken)
    {
        return await betService.DeleteSpin(request.Id);
    }
}
