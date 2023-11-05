using Roulette.Application.Abstractions.Services;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.PayoutFeatures.Commands.CreatePayout;
using Roulette.Application.Features.PayoutFeatures.Commands.DeletePayout;
using Roulette.Application.Features.PayoutFeatures.Commands.UpdatePayout;
using Roulette.Domain.Entities;

namespace Roulette.Infrastructure.Services;
public class PayoutService : IPayoutService
{
    private readonly IUnitOfWork _unitOfWork;
    public PayoutService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Payout>> GetAllPayouts()
    {
        return await _unitOfWork.PayoutRepository.GetAllAsync();

    }
    public async Task<Payout> GetPayout(int id)
    {
        return await _unitOfWork.PayoutRepository.GetAsync(item => item.Id == id);

    }
    public async Task<CreatePayoutResponse> CreatePayout(Payout payout)
    {
        _unitOfWork.PayoutRepository.Add(payout);
        await _unitOfWork.CommitAsync();
        return new CreatePayoutResponse { Message = $"Payout with id: {payout.Id} has been created succesfully" };
    }
    public async Task<UpdatePayoutResponse> UpdatePayout(Payout payout)
    {
        Payout _payout = await _unitOfWork.PayoutRepository.GetAsync(item => item.Id == payout.Id);
        if (_payout == null)
        {
            throw new PayoutNotFoundException(payout.Id.ToString());
        }
        _unitOfWork.PayoutRepository.Update(_payout);
        await _unitOfWork.CommitAsync();
        return new UpdatePayoutResponse { Message = $"Payout with id: {payout.Id} updated successfully" };
    }

    public async Task<DeletePayoutResponse> DeletePayout(int id)
    {
        Payout _payout = await _unitOfWork.PayoutRepository.GetAsync(item => item.Id == id);
        if (_payout == null)
        {
            throw new PayoutNotFoundException(id.ToString());
        }
        _unitOfWork.PayoutRepository.Remove(_payout);
        await _unitOfWork.CommitAsync();
        return new DeletePayoutResponse { Message = $"Payout with id: {id} deleted successfully" };
    }
}
