using Roulette.Application.Features.PayoutFeatures.CreatePayout;
using Roulette.Application.Features.PayoutFeatures.DeletePayout;
using Roulette.Application.Features.PayoutFeatures.UpdatePayout;
using Roulette.Domain.Entities;

namespace Roulette.Application.Abstractions.Services;
public interface IPayoutService
{
    Task<CreatePayoutResponse> CreatePayout(Payout payout);
    Task<DeletePayoutResponse> DeletePayout(int id);
    Task<IEnumerable<Payout>> GetAllPayouts();
    Task<Payout> GetPayout(int id, CancellationToken cancellationToken);
    Task<UpdatePayoutResponse> UpdatePayout(Payout payout);
}
