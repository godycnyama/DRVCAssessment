using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roulette.API.PayoutsAPI;
using Roulette.Application.Features.PayoutFeatures.Commands.CreatePayout;
using Roulette.Application.Features.PayoutFeatures.Commands.DeletePayout;
using Roulette.Application.Features.PayoutFeatures.Commands.UpdatePayout;
using Roulette.Application.Features.PayoutFeatures.Queries.GetPayout;
using Roulette.Application.Features.PayoutFeatures.Queries.GetPayouts;
using Roulette.Application.Exceptions;
using Roulette.Domain.Entities;
using Roulette.Application.Features.BetFeatures.Queries.GetBets;
using Roulette.Application.Features.BetFeatures.Queries.GetBet;

namespace Roulette.UnitTests.ControllersUnitTests
{
    [TestClass]
    public class PayoutsControllerUnitTests
    {
        private Mock<IMediator> _mediatorMock = new Mock<IMediator>();
        private PayoutsController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _controller = new PayoutsController(_mediatorMock.Object);
        }

        [TestMethod]
        public async Task GetAllPayouts_ReturnsOkResult_WhenPayoutsExist()
        {
            // Arrange
            var payouts = new List<GetPayoutsResponse>();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPayoutsRequest>(), default)).ReturnsAsync(payouts);

            // Act
            var result = await _controller.GetAllPayouts();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetAllPayouts_ThrowsPayoutsNotFoundException_WhenPayoutsDoNotExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPayoutsRequest>(), default)).ReturnsAsync((List<GetPayoutsResponse>)null);

            // Assert
            await Assert.ThrowsExceptionAsync<PayoutsNotFoundException>(() => _controller.GetAllPayouts());
        }

        [TestMethod]
        public async Task GetPayout_ReturnsOkResult_WhenPayoutExists()
        {
            // Arrange
            var payout = new GetPayoutResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPayoutRequest>(), default)).ReturnsAsync(payout);

            // Act
            var result = await _controller.GetPayout(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetPayout_ThrowsPayoutNotFoundException_WhenPayoutDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPayoutRequest>(), default)).ReturnsAsync((PayoutDto)null);

            // Assert
            await Assert.ThrowsExceptionAsync<PayoutNotFoundException>(() => _controller.GetPayout(1));
        }

        [TestMethod]
        public async Task UpdatePayout_ReturnsOkResult_WhenPayoutIsUpdated()
        {
            // Arrange
            var updatePayoutRequest = new UpdatePayoutRequest(3, 2, "R", 5, 10, 15);
            var response = new UpdatePayoutResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdatePayoutRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _controller.UpdatePayout(updatePayoutRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreatePayout_ReturnsOkResult_WhenPayoutIsCreated()
        {
            // Arrange
            var createPayoutRequest = new CreatePayoutRequest(2, "R", 5, 10, 15);
            var response = new CreatePayoutResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreatePayoutRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _controller.CreatePayout(createPayoutRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeletePayout_ReturnsOkResult_WhenPayoutIsDeleted()
        {
            // Arrange
            var response = new DeletePayoutResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeletePayoutRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _controller.DeletePayout(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}

