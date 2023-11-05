using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.BetFeatures.Commands.DeleteBet;
public sealed class DeleteBetHandler : IRequestHandler<DeleteBetRequest, DeleteBetResponse>
{
    private readonly IBetService betService;
    private readonly IMapper mapper;

    public DeleteBetHandler(IMapper _mapper, IBetService _betService)
    {
        betService = _betService;
        mapper = _mapper;
    }

    public async Task<DeleteBetResponse> Handle(DeleteBetRequest request, CancellationToken cancellationToken)
    {
        return await betService.DeleteBet(request.Id);
    }
}
