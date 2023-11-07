using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roulette.Application.Features.SessionFeatures.Commands.CreateSession;
using Roulette.Application.Features.SessionFeatures.Commands.DeleteSession;
using Roulette.Application.Features.SessionFeatures.Commands.UpdateSession;
using Roulette.Application.Features.SessionFeatures.Queries.GetSession;
using Roulette.Application.Features.SessionFeatures.Queries.GetSessions;
using Roulette.API.SessionsAPI;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.BetFeatures.Queries.GetBets;

namespace Roulette.UnitTests.ControllersUnitTests
{
    [TestClass]
    public class SessionsControllerUnitTests
    {
        private Mock<IMediator> _mediatorMock = new Mock<IMediator>();
        private SessionsController _sessionsController;

        [TestInitialize]
        public void Initialize()
        {
            _sessionsController = new SessionsController(_mediatorMock.Object);
        }

        [TestMethod]
        public async Task GetAllSessions_ReturnsOkResult_WhenSessionsExist()
        {
            // Arrange
            var sessions = new List<GetSessionsResponse>();
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetSessionsRequest>(), default)).ReturnsAsync(sessions);

            // Act
            var result = await _sessionsController.GetAllSessions();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetAllSessions_ThrowsSessionsNotFoundException_WhenSessionsDoNotExist()
        {
            // Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetSessionsRequest>(), default)).ReturnsAsync((List<GetSessionsResponse>)null);

            // Assert
            await Assert.ThrowsExceptionAsync<SessionsNotFoundException>(() => _sessionsController.GetAllSessions());
        }

        [TestMethod]
        public async Task GetSession_ReturnsOkResult_WhenSessionExists()
        {
            // Arrange
            var session = new GetSessionResponse();
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetSessionRequest>(), default)).ReturnsAsync(session);

            // Act
            var result = await _sessionsController.GetSession(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetSession_ThrowsSessionNotFoundException_WhenSessionDoesNotExist()
        {
            // Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetSessionRequest>(), default)).ReturnsAsync((SessionDto)null);

            // Assert
            await Assert.ThrowsExceptionAsync<SessionNotFoundException>(() => _sessionsController.GetSession(1));
        }

        [TestMethod]
        public async Task UpdateSession_ReturnsOkResult_WhenSessionIsUpdated()
        {
            // Arrange
            var updateSessionRequest = new UpdateSessionRequest(1,60,"R");
            var response = new UpdateSessionResponse();
            _mediatorMock.Setup(x => x.Send(It.IsAny<UpdateSessionRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _sessionsController.UpdateSession(updateSessionRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateSession_ReturnsOkResult_WhenSessionIsCreated()
        {
            // Arrange
            var createSessionRequest = new CreateSessionRequest(100,"R");
            var response = new CreateSessionResponse();
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateSessionRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _sessionsController.CreateSession(createSessionRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteSession_ReturnsOkResult_WhenSessionIsDeleted()
        {
            // Arrange
            var response = new DeleteSessionResponse();
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteSessionRequest>(), default)).ReturnsAsync(response);

            // Act
            var result = await _sessionsController.DeleteSession(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}

