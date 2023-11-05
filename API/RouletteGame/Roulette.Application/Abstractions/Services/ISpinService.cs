using Roulette.Application.Features.SpinFeatures.Commands.DeleteSpin;
using Roulette.Domain.Entities;

namespace Roulette.Application.Abstractions.Services;
public interface ISpinService
{
    Task<DeleteSpinResponse> DeleteSpin(int id);
    Task<IEnumerable<Spin>> GetAllSpins();
    Task<Spin> GetSpin(int id, CancellationToken cancellationToken);
}
