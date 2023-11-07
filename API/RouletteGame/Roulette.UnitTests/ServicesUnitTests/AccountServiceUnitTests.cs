using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
using Roulette.Application.Features.AccountFeatures.Commands.DeleteAccount;
using Roulette.Application.Features.AccountFeatures.Commands.UpdateAccount;
using Roulette.Domain.Entities;
using Roulette.Application.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Roulette.Infrastructure.Services;

namespace Roulette.UnitTests.ServicesUnitTests;
[TestClass]
public class AccountServiceUnitTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private AccountService _accountService;

    [TestInitialize]
    public void Initialize()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _accountService = new AccountService(_unitOfWorkMock.Object);
    }

    [TestMethod]
    public async Task GetAllAccounts_ShouldReturnAllAccounts_GivenAccountsExistInDatabase()
    {
        // Arrange
        var accounts = new List<Account> { new Account(), new Account() };
        _unitOfWorkMock.Setup(x => x.AccountRepository.GetAllAsync()).ReturnsAsync(accounts);

        // Act
        var result = await _accountService.GetAllAccounts();

        // Assert
        Assert.AreEqual(accounts.Count, result.ToList().Count);
    }

    [TestMethod]
    public async Task GetAccount_ShouldReturnAccountWithGivenAccountID()
    {
        // Arrange
        var account = new Account { AccountID = 1 };
        _unitOfWorkMock.Setup(x => x.AccountRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Account, bool>>>())).ReturnsAsync(account);

        // Act
        var result = await _accountService.GetAccount(1);

        // Assert
        Assert.AreEqual(account.AccountID, result.AccountID);
    }

    [TestMethod]
    public async Task CreateAccount_ShouldAddAccountToRepository()
    {
        // Arrange
        var account = new Account();
        _unitOfWorkMock.Setup(x => x.AccountRepository.Add(account));

        // Act
        var result = await _accountService.CreateAccount(account);

        // Assert
        _unitOfWorkMock.Verify(x => x.AccountRepository.Add(account), Times.Once);
        _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
        Assert.AreEqual(account, result);
    }

    [TestMethod]
    public async Task UpdateAccount_ShouldUpdateAccountInRepository()
    {
        // Arrange
        var account = new Account { AccountID = 1 };
        _unitOfWorkMock.Setup(x => x.AccountRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Account, bool>>>())).ReturnsAsync(account);

        // Act
        var result = await _accountService.UpdateAccount(account);

        // Assert
        _unitOfWorkMock.Verify(x => x.AccountRepository.Update(account), Times.Once);
        _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
        Assert.AreEqual(account, result);
    }

    [TestMethod]
    public async Task Deposit_ShouldUpdateAccountBalanceInRepository()
    {
        // Arrange
        var account = new Account { AccountID = 1 };
        _unitOfWorkMock.Setup(x => x.AccountRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Account, bool>>>())).ReturnsAsync(account);

        // Act
        var result = await _accountService.Deposit(1, 100);

        // Assert
        _unitOfWorkMock.Verify(x => x.AccountRepository.Update(account), Times.Once);
        _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
        Assert.AreEqual(100, result.Balance);
    }

    [TestMethod]
    public async Task DeleteAccount_ShouldRemoveAccountFromRepository()
    {
        // Arrange
        var account = new Account { AccountID = 1 };
        _unitOfWorkMock.Setup(x => x.AccountRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Account, bool>>>())).ReturnsAsync(account);

        // Act
        var result = await _accountService.DeleteAccount(1);

        // Assert
        _unitOfWorkMock.Verify(x => x.AccountRepository.Remove(account), Times.Once);
        _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
        Assert.AreEqual($"Account with id: {account.AccountID} deleted successfully", result.Message);
    }

    [TestMethod]
    [ExpectedException(typeof(AccountNotFoundException))]
    public async Task UpdateAccount_ShouldThrowAccountNotFoundException()
    {
        // Arrange
        var account = new Account { AccountID = 1 };
        _unitOfWorkMock.Setup(x => x.AccountRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Account, bool>>>())).ReturnsAsync((Account)null);

        // Act
        await _accountService.UpdateAccount(account);
    }

    [TestMethod]
    [ExpectedException(typeof(AccountNotFoundException))]
    public async Task Deposit_ShouldThrowAccountNotFoundException()
    {
        // Arrange
        var account = new Account { AccountID = 1 };
        _unitOfWorkMock.Setup(x => x.AccountRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Account, bool>>>())).ReturnsAsync((Account)null);

        // Act
        await _accountService.Deposit(1, 100);
    }

    [TestMethod]
    [ExpectedException(typeof(AccountNotFoundException))]
    public async Task DeleteAccount_ShouldThrowAccountNotFoundException()
    {
        // Arrange
        var account = new Account { AccountID = 1 };
        _unitOfWorkMock.Setup(x => x.AccountRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Account, bool>>>())).ReturnsAsync((Account)null);

        // Act
        await _accountService.DeleteAccount(1);
    }
}
