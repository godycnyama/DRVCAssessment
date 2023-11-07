using Roulette.Application.Features.AccountFeatures.Commands.DeleteAccount;
using Roulette.Domain.Entities;

namespace Roulette.Application.Abstractions.Services;
public interface IAccountService
{
    Task<Account> CreateAccount(Account deposit);
    Task<DeleteAccountResponse> DeleteAccount(int id);
    Task<IEnumerable<Account>> GetAllAccounts();
    Task<Account> GetAccount(int id);
    Task<Account> UpdateAccount(Account deposit);
    Task<Account> Deposit(int id,decimal amount);
}
