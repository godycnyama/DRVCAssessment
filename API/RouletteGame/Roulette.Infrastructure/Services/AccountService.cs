using Roulette.Application.Abstractions.Services;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.AccountFeatures.Commands.DeleteAccount;
using Roulette.Domain.Entities;

namespace Roulette.Infrastructure.Services;
public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    public AccountService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Account>> GetAllAccounts()
    {
        return await _unitOfWork.AccountRepository.GetAllAsync();

    }
    public async Task<Account> GetAccount(int id)
    {
        return await _unitOfWork.AccountRepository.GetAsync(item => item.AccountID == id);

    }
    public async Task<Account> CreateAccount(Account account)
    {
        _unitOfWork.AccountRepository.Add(account);
        await _unitOfWork.CommitAsync();
        return account;
    }
    public async Task<Account> UpdateAccount(Account account)
    {
        Account _account = await _unitOfWork.AccountRepository.GetAsync(item => item.AccountID == account.AccountID);
        if (_account == null)
        {
            throw new AccountNotFoundException(account.AccountID.ToString());
        }
        _unitOfWork.AccountRepository.Update(_account);
        await _unitOfWork.CommitAsync();
        return account;
    }

    public async Task<Account> Deposit(int id, decimal amount)
    {
        Account _account = await _unitOfWork.AccountRepository.GetAsync(item => item.AccountID == id);
        if (_account == null)
        {
            throw new AccountNotFoundException(id.ToString());
        }
        _account.Balance = amount;
        _unitOfWork.AccountRepository.Update(_account);
        await _unitOfWork.CommitAsync();
        return _account;
    }

    public async Task<DeleteAccountResponse> DeleteAccount(int id)
    {
        Account _account = await _unitOfWork.AccountRepository.GetAsync(item => item.AccountID == id);
        if (_account == null)
        {
            throw new AccountNotFoundException(id.ToString());
        }
        _unitOfWork.AccountRepository.Remove(_account);
        await _unitOfWork.CommitAsync();
        return new DeleteAccountResponse { Message = $"Account with id: {id} deleted successfully" };
    }
}
