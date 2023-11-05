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
    public async Task<Spin> GetSpin(int id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.SpinRepository.GetAsync(item => item.Id == id, cancellationToken);

    }

    public async Task<DeleteSpinResponse> DeleteSpin(int id)
    {
        Spin _spin = await _unitOfWork.SpinRepository.GetAsync(item => item.Id == id, CancellationToken.None);
        if (_spin == null)
        {

            throw new SpinNotFoundException(id.ToString());
        }
        _unitOfWork.SpinRepository.Remove(_spin);
        await _unitOfWork.CommitAsync();
        return new DeleteSpinResponse { Message = $"Spin with id: {id} deleted successfully" };
    }
}
