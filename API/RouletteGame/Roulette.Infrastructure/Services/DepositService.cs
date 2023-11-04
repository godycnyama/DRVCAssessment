using Roulette.Application.Abstractions.Services;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Features.DepositFeatures.CreateDeposit;
using Roulette.Application.Features.DepositFeatures.DeleteDeposit;
using Roulette.Application.Features.DepositFeatures.UpdateDeposit;
using Roulette.Domain.Entities;

namespace Roulette.Infrastructure.Services;
public class DepositService : IDepositService
{
    private readonly IUnitOfWork _unitOfWork;
    public DepositService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Deposit>> GetAllDeposits()
    {
        return await _unitOfWork.DepositRepository.GetAllAsync();

    }
    public async Task<Deposit> GetDeposit(int id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.DepositRepository.GetAsync(item => item.Id == id, cancellationToken);

    }
    public async Task<CreateDepositResponse> CreateDeposit(Deposit deposit)
    {
        _unitOfWork.DepositRepository.Add(deposit);
        await _unitOfWork.CommitAsync();
        return new CreateDepositResponse { Message = $"Deposit with id: {deposit.Id} has been created succesfully" };
    }
    public async Task<UpdateDepositResponse> UpdateDeposit(Deposit deposit)
    {
        Deposit _deposit = await _unitOfWork.DepositRepository.GetAsync(item => item.Id == deposit.Id, CancellationToken.None);
        if (_deposit == null)
        {
            throw new Exception($"Deposit with id: {deposit.Id} not found");
        }
        _unitOfWork.DepositRepository.Update(_deposit);
        await _unitOfWork.CommitAsync();
        return new UpdateDepositResponse { Message = $"Deposit with id: {deposit.Id} updated successfully" };
    }

    public async Task<DeleteDepositResponse> DeleteDeposit(int id)
    {
        Deposit _deposit = await _unitOfWork.DepositRepository.GetAsync(item => item.Id == id, CancellationToken.None);
        if (_deposit == null)
        {
            throw new Exception($"Deposit with id: {id} not found");
        }
        _unitOfWork.DepositRepository.Remove(_deposit);
        await _unitOfWork.CommitAsync();
        return new DeleteDepositResponse { Message = $"Deposit with id: {id} deleted successfully" };
    }
}
