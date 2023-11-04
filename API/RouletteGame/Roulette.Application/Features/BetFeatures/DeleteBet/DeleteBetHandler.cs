using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.BetFeatures.DeleteBet;
public sealed class DeleteBetHandler : IRequestHandler<DeleteBetRequest, DeleteBetResponse>
{
    private readonly IBetService _betService;
    private readonly IMapper _mapper;

    public DeleteBetHandler(IMapper mapper, IBetService betService)
    {
        _betService = betService;
        _mapper = mapper;
    }

    public async Task<DeleteBetResponse> Handle(DeleteBetRequest request, CancellationToken cancellationToken)
    {
        return await _betService.DeleteBet(request.Id);
    }
}
