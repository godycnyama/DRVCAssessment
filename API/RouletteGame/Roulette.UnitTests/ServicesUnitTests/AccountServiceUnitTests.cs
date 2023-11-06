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
    [TestMethod]
    public async Task GetAllAccounts_ReturnsAllAccounts()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var accountService = new AccountService(unitOfWorkMock.Object);

        // Mock the behavior of the repository and unit of work
        unitOfWorkMock.Setup(u => u.AccountRepository.GetAllAsync()).ReturnsAsync(new List<Account>
            {
                new Account { Id = 1,FirstName = "James", LastName = "Mug", UserName = "Jimalo", Balance = 1000 },
                new Account { Id = 2, FirstName = "Amos", LastName = "Smut", UserName = "Smua", Balance = 2000 }
            });

        // Act
        var accounts = await accountService.GetAllAccounts();

        // Assert
        Assert.IsNotNull(accounts);
        Assert.AreEqual(2, accounts.Count());
    }
}
