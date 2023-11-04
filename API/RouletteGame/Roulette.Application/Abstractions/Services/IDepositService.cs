using Roulette.Application.Features.DepositFeatures.CreateDeposit;
using Roulette.Application.Features.DepositFeatures.DeleteDeposit;
using Roulette.Application.Features.DepositFeatures.UpdateDeposit;
using Roulette.Domain.Entities;

namespace Roulette.Application.Abstractions.Services;
public interface IDepositService
{
    Task<CreateDepositResponse> CreateDeposit(Deposit deposit);
    Task<DeleteDepositResponse> DeleteDeposit(int id);
    Task<IEnumerable<Deposit>> GetAllDeposits();
    Task<Deposit> GetDeposit(int id, CancellationToken cancellationToken);
    Task<UpdateDepositResponse> UpdateDeposit(Deposit deposit);
}
