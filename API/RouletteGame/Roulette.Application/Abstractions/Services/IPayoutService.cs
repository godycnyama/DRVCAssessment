using Roulette.Application.Features.PayoutFeatures.Commands.DeletePayout;
using Roulette.Domain.Entities;

namespace Roulette.Application.Abstractions.Services;
public interface IPayoutService
{
    Task<Payout> CreatePayout(Payout payout);
    Task<DeletePayoutResponse> DeletePayout(int id);
    Task<IEnumerable<Payout>> GetAllPayouts();
    Task<Payout> GetPayout(int id);
    Task<Payout> UpdatePayout(Payout payout);
}
