using Roulette.Application.Features.BetFeatures.CreateBet;
using Roulette.Application.Features.BetFeatures.DeleteBet;
using Roulette.Application.Features.BetFeatures.UpdateBet;
using Roulette.Domain.Entities;

namespace Roulette.Application.Abstractions.Services;
public interface IBetService
{
    Task<CreateBetResponse> CreateBet(Bet bet);
    Task<DeleteBetResponse> DeleteBet(int id);
    Task<IEnumerable<Bet>> GetAllBets();
    Task<Bet> GetBet(int id, CancellationToken cancellationToken);
    Task<UpdateBetResponse> UpdateBet(Bet bet);
}
}
