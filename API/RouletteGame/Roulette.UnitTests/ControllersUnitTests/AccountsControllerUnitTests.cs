using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roulette.API.AccountAPI;
using Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
using Roulette.Application.Features.AccountFeatures.Queries.GetAccounts;
using System.Threading.Tasks;
using Roulette.Application.Exceptions;
using MediatR;

namespace Roulette.UnitTests.ControllersUnitTests;

[TestClass]

public class AccountsControllerUnitTests
{
    [TestMethod]
    public async Task GetAllAccounts_ReturnsOkResult()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new AccountController(mediatorMock.Object);

        var accountsResponse = new GetAccountsResponse(); // Replace with test data

        mediatorMock.Setup(m => m.Send(It.IsAny<GetAccountsRequest>(), default))
            .ReturnsAsync(accountsResponse);

        // Act
        var result = await controller.GetAllAccounts();

        // Assert
        var okResult = Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        var okValue = (GetAccountsResponse)((OkObjectResult)okResult).Value;
        Assert.AreEqual(accountsResponse, okValue);
    }

}
