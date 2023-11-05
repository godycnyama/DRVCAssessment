using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.PayoutFeatures.Commands.DeletePayout;
public sealed class DeletePayoutHandler : IRequestHandler<DeletePayoutRequest, DeletePayoutResponse>
{
    private readonly IPayoutService payoutService;
    private readonly IMapper _mapper;

    public DeletePayoutHandler(IMapper mapper, IPayoutService _payoutService)
    {
        payoutService = _payoutService;
        _mapper = mapper;
    }

    public async Task<DeletePayoutResponse> Handle(DeletePayoutRequest request, CancellationToken cancellationToken)
    {
        return await payoutService.DeletePayout(request.Id);
    }
}
