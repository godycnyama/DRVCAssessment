using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
using Roulette.Domain.Entities;
using MediatR;

namespace Roulette.UnitTests.CommandHandlersUnitTests
{
    [TestClass]
    public class CreateAccountHandlerTests
    {
        private Mock<IAccountService> _accountServiceMock;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void Initialize()
        {
            _accountServiceMock = new Mock<IAccountService>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public async Task Handle_ShouldCreateAccount_WhenRequestIsValid()
        {
            // Arrange
            var request = new CreateAccountRequest("Ket","Hillary","KeH",50,"R") ;
            var cancellationToken = new CancellationToken();
            var account = new Account();
            var response = new CreateAccountResponse();

            _mapperMock.Setup(m => m.Map<Account>(request)).Returns(account);
            _accountServiceMock.Setup(s => s.CreateAccount(account)).ReturnsAsync(account);
            _mapperMock.Setup(m => m.Map<CreateAccountResponse>(response)).Returns(new CreateAccountResponse());

            var handler = new CreateAccountHandler(_mapperMock.Object, _accountServiceMock.Object);

            // Act
            var result = await handler.Handle(request, cancellationToken);

            // Assert
            _mapperMock.Verify(m => m.Map<Account>(request), Times.Once);
            _accountServiceMock.Verify(s => s.CreateAccount(account), Times.Once);
            _mapperMock.Verify(m => m.Map<CreateAccountResponse>(response), Times.Once);
        }
    }
}

