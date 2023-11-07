using Roulette.Application.Abstractions.Services;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.BetFeatures.Commands.DeleteBet;
using Roulette.Domain.Entities;

namespace Roulette.Infrastructure.Services;
public class BetService : IBetService
{
    private readonly IUnitOfWork _unitOfWork;
    public BetService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Bet>> GetAllBets()
    {
        return await _unitOfWork.BetRepository.GetAllAsync();

    }
    public async Task<Bet> GetBet(int id)
    {
        return await _unitOfWork.BetRepository.GetAsync(item => item.BetID == id);

    }
    public async Task<Bet> CreateBet(Bet bet)
    {
        _unitOfWork.BetRepository.Add(bet);
        await _unitOfWork.CommitAsync();

        return bet;
    }
    public async Task<Bet> UpdateBet(Bet bet)
    {
        Bet _bet = await _unitOfWork.BetRepository.GetAsync(item => item.BetID == bet.BetID);
        if (_bet == null)
        {
            throw new BetNotFoundException(bet.BetID.ToString());
        }
        _unitOfWork.BetRepository.Update(_bet);
        await _unitOfWork.CommitAsync();
        return bet;
    }

    public async Task<DeleteBetResponse> DeleteBet(int id)
    {
            Bet _bet = await _unitOfWork.BetRepository.GetAsync(item => item.BetID == id);
            if (_bet == null)
        {
            throw new BetNotFoundException(id.ToString());
        }
        _unitOfWork.BetRepository.Remove(_bet);
        await _unitOfWork.CommitAsync();
        return new DeleteBetResponse { Message = $"Bet with id: {id} deleted successfully" };
    }
}
