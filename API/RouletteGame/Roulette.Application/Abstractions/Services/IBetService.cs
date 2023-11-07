using Roulette.Application.Features.BetFeatures.Commands.DeleteBet;
using Roulette.Domain.Entities;

namespace Roulette.Application.Abstractions.Services;
public interface IBetService
{
    Task<Bet> CreateBet(Bet bet);
    Task<DeleteBetResponse> DeleteBet(int id);
    Task<IEnumerable<Bet>> GetAllBets();
    Task<Bet> GetBet(int id);
    Task<Bet> UpdateBet(Bet bet);
}
