using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.PayoutFeatures.Commands.CreatePayout;
public sealed class CreatePayoutHandler : IRequestHandler<CreatePayoutRequest, CreatePayoutResponse>
{
    private readonly IPayoutService payoutService;
    private readonly IMapper mapper;

    public CreatePayoutHandler(IMapper _mapper, IPayoutService _payoutService)
    {
        payoutService = _payoutService;
        mapper = _mapper;
    }

    public async Task<CreatePayoutResponse> Handle(CreatePayoutRequest request, CancellationToken cancellationToken)
    {
        Payout payout = mapper.Map<Payout>(request);
        return await payoutService.CreatePayout(payout);
    }
}
