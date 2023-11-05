using Roulette.Application.Abstractions.Services;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.BetFeatures.Commands.CreateBet;
using Roulette.Application.Features.BetFeatures.Commands.DeleteBet;
using Roulette.Application.Features.BetFeatures.Commands.UpdateBet;
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
    public async Task<Bet> GetBet(int id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.BetRepository.GetAsync(item => item.Id == id, cancellationToken);

    }
    public async Task<CreateBetResponse> CreateBet(Bet bet)
    {
        _unitOfWork.BetRepository.Add(bet);
        await _unitOfWork.CommitAsync();
        return new CreateBetResponse { Message = $"Bet with id: {bet.Id} has been created succesfully" };
    }
    public async Task<UpdateBetResponse> UpdateBet(Bet bet)
    {
        Bet _bet = await _unitOfWork.BetRepository.GetAsync(item => item.Id == bet.Id, CancellationToken.None);
        if (_bet == null)
        {
            throw new BetNotFoundException(bet.Id.ToString());
        }
        _unitOfWork.BetRepository.Update(_bet);
        await _unitOfWork.CommitAsync();
        return new UpdateBetResponse { Message = $"Bet with id: {bet.Id} updated successfully" };
    }

    public async Task<DeleteBetResponse> DeleteBet(int id)
    {
        Bet _bet = await _unitOfWork.BetRepository.GetAsync(item => item.Id == id, CancellationToken.None);
        if (_bet == null)
        {
            throw new BetNotFoundException(id.ToString());
        }
        _unitOfWork.BetRepository.Remove(_bet);
        await _unitOfWork.CommitAsync();
        return new DeleteBetResponse { Message = $"Bet with id: {id} deleted successfully" };
    }
}
