using Roulette.Application.Abstractions.Services;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Features.SpinFeatures.CreateSpin;
using Roulette.Application.Features.SpinFeatures.DeleteSpin;
using Roulette.Application.Features.SpinFeatures.UpdateSpin;
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
    public async Task<Spin> GetSpin(int id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.SpinRepository.GetAsync(item => item.Id == id, cancellationToken);

    }
    public async Task<CreateSpinResponse> CreateSpin(Spin spin)
    {
        _unitOfWork.SpinRepository.Add(spin);
        await _unitOfWork.CommitAsync();
        return new CreateSpinResponse { Message = $"Spin with id: {spin.Id} has been created succesfully" };
    }
    public async Task<UpdateSpinResponse> UpdateSpin(Spin spin)
    {
        Spin _spin = await _unitOfWork.SpinRepository.GetAsync(item => item.Id == spin.Id, CancellationToken.None);
        if (_spin == null)
        {
            throw new Exception($"Spin with id: {spin.Id} not found");
        }
        _unitOfWork.SpinRepository.Update(_spin);
        await _unitOfWork.CommitAsync();
        return new UpdateSpinResponse { Message = $"Spin with id: {spin.Id} updated successfully" };
    }

    public async Task<DeleteSpinResponse> DeleteSpin(int id)
    {
        Spin _spin = await _unitOfWork.SpinRepository.GetAsync(item => item.Id == id, CancellationToken.None);
        if (_spin == null)
        {
            throw new Exception($"Spin with id: {id} not found");
        }
        _unitOfWork.SpinRepository.Remove(_spin);
        await _unitOfWork.CommitAsync();
        return new DeleteSpinResponse { Message = $"Spin with id: {id} deleted successfully" };
    }
}
