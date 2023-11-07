using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roulette.Application.Features.SpinFeatures.Commands.CreateSpin;
using Roulette.Application.Features.SpinFeatures.Commands.DeleteSpin;
using Roulette.Application.Features.SpinFeatures.Commands.UpdateSpin;
using Roulette.Application.Features.SpinFeatures.Queries.GetSpin;
using Roulette.Application.Features.SpinFeatures.Queries.GetSpins;
using Roulette.API.SpinsAPI;
using Roulette.Application.Exceptions;
using Roulette.API.SessionsAPI;

namespace Roulette.UnitTests.ControllersUnitTests
{
    [TestClass]
    public class SpinsControllerUnitTests
    {
        private readonly Mock<IMediator> _mediatorMock = new Mock<IMediator>();
        private SpinsController _spinsController;

        [TestInitialize]
        public void Initialize()
        {
            _spinsController = new SpinsController(_mediatorMock.Object);
        }

        [TestMethod]
        public async Task GetAllSpins_ReturnsOkResult()
        {
            // Arrange
            var spins = new List<GetSpinsResponse>();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSpinsRequest>(), default)).ReturnsAsync(spins);

            // Act
            var result = await _spinsController.GetAllSpins();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetSpin_ReturnsOkResult()
        {
            // Arrange
            var spin = new GetSpinResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetSpinRequest>(), default)).ReturnsAsync(spin);

            // Act
            var result = await _spinsController.GetSpin(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task UpdateSpin_ReturnsOkResult()
        {
            // Arrange
            var response = new UpdateSpinResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateSpinRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _spinsController.UpdateSpin(new UpdateSpinRequest(6, 1, 34, 5));

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateSpin_ReturnsOkResult()
        {
            // Arrange
            var response = new CreateSpinResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateSpinRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _spinsController.CreateSpin(new CreateSpinRequest(1,34,5));

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteSpin_ReturnsOkResult()
        {
            // Arrange
            var response = new DeleteSpinResponse();
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteSpinRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _spinsController.DeleteSpin(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}

