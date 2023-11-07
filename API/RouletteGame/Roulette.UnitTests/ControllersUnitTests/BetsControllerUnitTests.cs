using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roulette.API.BetsAPI;
using Roulette.Application.Features.BetFeatures.Commands.CreateBet;
using Roulette.Application.Features.BetFeatures.Commands.DeleteBet;
using Roulette.Application.Features.BetFeatures.Commands.UpdateBet;
using Roulette.Application.Features.BetFeatures.Queries.GetBet;
using Roulette.Application.Features.BetFeatures.Queries.GetBets;
using Roulette.Application.Exceptions;

namespace Roulette.UnitTests.ControllersUnitTests
{
    [TestClass]
    public class BetsControllerUnitTests
    {
        private Mock<IMediator> _mediatorMock = new Mock<IMediator>();
        private BetsController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _controller = new BetsController(_mediatorMock.Object);
        }

        [TestMethod]
        public async Task GetAllBets_ReturnsOkResult()
        {
            // Arrange
            var bets = new List<GetBetsResponse>();
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetBetsRequest>(), default)).ReturnsAsync(bets);

            // Act
            var result = await _controller.GetAllBets();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetBet_ReturnsOkResult()
        {
            // Arrange
            var bet = new GetBetResponse();
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetBetRequest>(), default)).ReturnsAsync(bet);

            // Act
            var result = await _controller.GetBet(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task UpdateBet_ReturnsOkResult()
        {
            // Arrange
            var request = new UpdateBetRequest(1,20,"R",15,4,10);
            var response = new UpdateBetResponse();
            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _controller.UpdateBet(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateBet_ReturnsOkResult()
        {
            // Arrange
            var request = new CreateBetRequest(20, "R", 15, 4, 10);
            var response = new CreateBetResponse();
            _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(response);

            // Act
            var result = await _controller.CreateBet(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteBet_ReturnsOkResult()
        {
            // Arrange
            var response = new DeleteBetResponse();
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteBetRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _controller.DeleteBet(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}

