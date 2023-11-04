using Roulette.Application.Features.SpinFeatures.CreateSpin;
using Roulette.Application.Features.SpinFeatures.DeleteSpin;
using Roulette.Application.Features.SpinFeatures.UpdateSpin;
using Roulette.Domain.Entities;

namespace Roulette.Application.Abstractions.Services;
public interface ISpinService
{
    Task<CreateSpinResponse> CreateSpin(Spin spin);
    Task<DeleteSpinResponse> DeleteSpin(int id);
    Task<IEnumerable<Spin>> GetAllSpins();
    Task<Spin> GetSpin(int id, CancellationToken cancellationToken);
    Task<UpdateSpinResponse> UpdateSpin(Spin spin);
}
