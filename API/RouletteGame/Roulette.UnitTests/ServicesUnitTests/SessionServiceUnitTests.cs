using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.SessionFeatures.Commands.DeleteSession;
using Roulette.Domain.Entities;
using Roulette.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Tests.Infrastructure.Services
{
    [TestClass]
    public class SessionServiceUnitTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private SessionService _sessionService;

        [TestInitialize]
        public void TestInitialize()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sessionService = new SessionService(_unitOfWorkMock.Object);
        }

        [TestMethod]
        public async Task GetAllSessions_ShouldReturnAllSessions()
        {
            // Arrange
            var sessions = new List<Session> { new Session(), new Session() };
            _unitOfWorkMock.Setup(uow => uow.SessionRepository.GetAllAsync()).ReturnsAsync(sessions);

            // Act
            var result = await _sessionService.GetAllSessions();

            // Assert
            Assert.AreEqual(sessions.Count, result.ToList().Count);
        }

        [TestMethod]
        public async Task GetSession_WithValidId_ShouldReturnSession()
        {
            // Arrange
            var session = new Session { SessionID = 1 };
            _unitOfWorkMock.Setup(uow => uow.SessionRepository.GetAsync(s => s.SessionID == session.SessionID)).ReturnsAsync(session);

            // Act
            var result = await _sessionService.GetSession(session.SessionID);

            // Assert
            Assert.AreEqual(session.SessionID, result.SessionID);
        }

        [TestMethod]
        public async Task GetSession_WithInvalidId_ShouldThrowSessionNotFoundException()
        {
            // Arrange
            var invalidId = 1;
            _unitOfWorkMock.Setup(uow => uow.SessionRepository.GetAsync(s => s.SessionID == invalidId)).ReturnsAsync((Session)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<SessionNotFoundException>(() => _sessionService.GetSession(invalidId));
        }

        [TestMethod]
        public async Task CreateSession_ShouldAddSessionToRepository()
        {
            // Arrange
            var session = new Session();

            // Act
            await _sessionService.CreateSession(session);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.SessionRepository.Add(session), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
        }

        [TestMethod]
        public async Task UpdateSession_WithValidSession_ShouldUpdateSessionInRepository()
        {
            // Arrange
            var session = new Session { SessionID = 1 };
            _unitOfWorkMock.Setup(uow => uow.SessionRepository.GetAsync(s => s.SessionID == session.SessionID)).ReturnsAsync(session);

            // Act
            await _sessionService.UpdateSession(session);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.SessionRepository.Update(session), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
        }

        [TestMethod]
        public async Task UpdateSession_WithInvalidSession_ShouldThrowSessionNotFoundException()
        {
            // Arrange
            var invalidSession = new Session { SessionID = 1 };
            _unitOfWorkMock.Setup(uow => uow.SessionRepository.GetAsync(s => s.SessionID == invalidSession.SessionID)).ReturnsAsync((Session)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<SessionNotFoundException>(() => _sessionService.UpdateSession(invalidSession));
        }

        [TestMethod]
        public async Task DeleteSession_WithValidId_ShouldRemoveSessionFromRepository()
        {
            // Arrange
            var session = new Session { SessionID = 1 };
            _unitOfWorkMock.Setup(uow => uow.SessionRepository.GetAsync(s => s.SessionID == session.SessionID)).ReturnsAsync(session);

            // Act
            var result = await _sessionService.DeleteSession(session.SessionID);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.SessionRepository.Remove(session), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
            Assert.AreEqual($"Session with id: {session.SessionID} deleted successfully", result.Message);
        }

        [TestMethod]
        public async Task DeleteSession_WithInvalidId_ShouldThrowSessionNotFoundException()
        {
            // Arrange
            var invalidId = 1;
            _unitOfWorkMock.Setup(uow => uow.SessionRepository.GetAsync(s => s.SessionID == invalidId)).ReturnsAsync((Session)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<SessionNotFoundException>(() => _sessionService.DeleteSession(invalidId));
        }
    }
}

