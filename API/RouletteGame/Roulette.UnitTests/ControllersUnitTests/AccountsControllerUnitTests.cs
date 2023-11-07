using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roulette.API.AccountAPI;
using Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
using Roulette.Application.Features.AccountFeatures.Commands.DeleteAccount;
using Roulette.Application.Features.AccountFeatures.Commands.UpdateAccount;
using Roulette.Application.Features.AccountFeatures.Queries.GetAccount;
using Roulette.Application.Features.AccountFeatures.Queries.GetAccounts;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Exceptions;
using System.Threading;
using Roulette.Domain.Entities;
using Roulette.Application.Features.BetFeatures.Queries.GetBets;
using Roulette.Application.Features.PayoutFeatures.Queries.GetPayouts;

namespace Roulette.UnitTests.ControllersUnitTests
{
    [TestClass]
    public class AccountsControllerUnitTests
    {
        private Mock<IMediator> _mediatorMock = new Mock<IMediator>();
        private AccountsController _accountsController;

        [TestInitialize]
        public void Initialize()
        {
            _accountsController = new AccountsController(_mediatorMock.Object);
        }

        [TestMethod]
        public async Task GetAllAccounts_ReturnsOkResult_WhenAccountsExist()
        {
            // Arrange

            var accounts = new List<GetAccountsResponse>();
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAccountsRequest>(), default)).ReturnsAsync(accounts);

            // Act
            var result = await _accountsController.GetAllAccounts();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetAllAccounts_ThrowsAccountsNotFoundException_WhenAccountsDoNotExist()
        {
            // Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAccountsRequest>(), default)).ReturnsAsync((List<GetAccountsResponse>)null);

            // Assert
            await Assert.ThrowsExceptionAsync<AccountsNotFoundException>(() => _accountsController.GetAllAccounts());
        }

        [TestMethod]
        public async Task GetAccount_ReturnsOkResult_WhenAccountExists()
        {
            // Arrange
            var account = new GetAccountRequest(1);
            var response = new GetAccountResponse();
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAccountRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _accountsController.GetAccount(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetAccount_ThrowsAccountNotFoundException_WhenAccountDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAccountRequest>(), default)).ReturnsAsync((GetAccountResponse)null);

            // Assert
            await Assert.ThrowsExceptionAsync<AccountNotFoundException>(() => _accountsController.GetAccount(1));
        }

        [TestMethod]
        public async Task UpdateAccount_ReturnsOkResult_WhenAccountIsUpdated()
        {
            // Arrange
            var updateAccountRequest = new UpdateAccountRequest(1,"Iceman","Hill", "ICEH", 50, "R");
            var response = new UpdateAccountResponse();
            _mediatorMock.Setup(x => x.Send(It.IsAny<UpdateAccountRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _accountsController.UpdateAccount(updateAccountRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateAccount_ReturnsOkResult_WhenAccountIsCreated()
        {
            // Arrange
            var createAccountRequest = new CreateAccountRequest("Iceman", "Hill", "ICEH", 50, "R");
            var response = new CreateAccountResponse();
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateAccountRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _accountsController.CreateAccount(createAccountRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteAccount_ReturnsOkResult_WhenAccountIsDeleted()
        {
            // Arrange
            var response = new DeleteAccountResponse();
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteAccountRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _accountsController.DeleteAccount(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}

