using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SpinFeatures.Queries.GetSpin;
public sealed class GetSpinHandler : IRequestHandler<GetSpinRequest, GetSpinResponse>
{
    private readonly ISpinService payoutService;
    private readonly IMapper mapper;

    public GetSpinHandler(IMapper _mapper, ISpinService _payoutService)
    {
        payoutService = _payoutService;
        mapper = _mapper;
    }

    public async Task<GetSpinResponse> Handle(GetSpinRequest request, CancellationToken cancellationToken)
    {
        Spin payout =  await payoutService.GetSpin(request.Id, cancellationToken);
        return mapper.Map<GetSpinResponse>(payout);
    }
}
