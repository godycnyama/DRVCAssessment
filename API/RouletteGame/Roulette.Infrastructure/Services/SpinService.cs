using Roulette.Application.Abstractions.Services;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.SpinFeatures.Commands.DeleteSpin;
using Roulette.Domain.Entities;

namespace Roulette.Infrastructure.Services;
public class SpinService : ISpinService
{
    private readonly IUnitOfWork _unitOfWork;
    public SpinService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Spin>> GetAllSpins()
    {
        return await _unitOfWork.SpinRepository.GetAllAsync();
    }
    public async Task<Spin> CreateSpin(Spin spin)
    {
        _unitOfWork.SpinRepository.Add(spin);
        await _unitOfWork.CommitAsync();
        return spin;
    }
    public async Task<Spin> UpdateSpin(Spin spin)
    {
        Spin _spin = await _unitOfWork.SpinRepository.GetAsync(item => item.SpinID == spin.SpinID);
        if (_spin == null)
        {
            throw new SpinNotFoundException(spin.SpinID.ToString());
        }
        _unitOfWork.SpinRepository.Update(_spin);
        await _unitOfWork.CommitAsync();
        return spin;
    }
    public async Task<Spin> GetSpin(int id)
    {
        return await _unitOfWork.SpinRepository.GetAsync(item => item.SpinID == id);

    }

    public async Task<DeleteSpinResponse> DeleteSpin(int id)
    {
        Spin _spin = await _unitOfWork.SpinRepository.GetAsync(item => item.SpinID == id);
        if (_spin == null)
        {

            throw new SpinNotFoundException(id.ToString());
        }
        _unitOfWork.SpinRepository.Remove(_spin);
        await _unitOfWork.CommitAsync();
        return new DeleteSpinResponse { Message = $"Spin with id: {id} deleted successfully" };
    }
}
