using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.BetFeatures.Commands.DeleteBet;
using Roulette.Domain.Entities;
using Roulette.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Tests.Infrastructure.Services
{
    [TestClass]
    public class BetServiceUnitTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private BetService _betService;

        [TestInitialize]
        public void TestInitialize()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _betService = new BetService(_unitOfWorkMock.Object);
        }

        [TestMethod]
        public async Task GetAllBets_ShouldReturnAllBets()
        {
            // Arrange
            var bets = new List<Bet> { new Bet(), new Bet() };
            _unitOfWorkMock.Setup(x => x.BetRepository.GetAllAsync()).ReturnsAsync(bets);

            // Act
            var result = await _betService.GetAllBets();

            // Assert
            Assert.AreEqual(bets.Count, result.ToList().Count);
        }

        [TestMethod]
        public async Task GetBet_WithValidId_ShouldReturnBet()
        {
            // Arrange
            var bet = new Bet { BetID = 1 };
            _unitOfWorkMock.Setup(x => x.BetRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Bet, bool>>>())).ReturnsAsync(bet);

            // Act
            var result = await _betService.GetBet(bet.BetID);

            // Assert
            Assert.AreEqual(bet, result);
        }

        [TestMethod]
        [ExpectedException(typeof(BetNotFoundException))]
        public async Task GetBet_WithInvalidId_ShouldThrowBetNotFoundException()
        {
            // Arrange
            _unitOfWorkMock.Setup(x => x.BetRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Bet, bool>>>())).ReturnsAsync((Bet)null);

            // Act
            await _betService.GetBet(1);

            // Assert
            // Expects exception to be thrown
        }

        [TestMethod]
        public async Task CreateBet_ShouldAddBetToRepository()
        {
            // Arrange
            var bet = new Bet();
            _unitOfWorkMock.Setup(x => x.BetRepository.Add(bet));

            // Act
            var result = await _betService.CreateBet(bet);

            // Assert
            _unitOfWorkMock.Verify(x => x.BetRepository.Add(bet), Times.Once);
            _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
            Assert.AreEqual(bet, result);
        }

        [TestMethod]
        public async Task UpdateBet_WithValidBet_ShouldUpdateBetInRepository()
        {
            // Arrange
            var bet = new Bet { BetID = 1 };
            _unitOfWorkMock.Setup(x => x.BetRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Bet, bool>>>())).ReturnsAsync(bet);

            // Act
            var result = await _betService.UpdateBet(bet);

            // Assert
            _unitOfWorkMock.Verify(x => x.BetRepository.Update(bet), Times.Once);
            _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
            Assert.AreEqual(bet, result);
        }

        [TestMethod]
        [ExpectedException(typeof(BetNotFoundException))]
        public async Task UpdateBet_WithInvalidBet_ShouldThrowBetNotFoundException()
        {
            // Arrange
            var bet = new Bet { BetID = 1 };
            _unitOfWorkMock.Setup(x => x.BetRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Bet, bool>>>())).ReturnsAsync((Bet)null);

            // Act
            await _betService.UpdateBet(bet);

            // Assert
            // Expects exception to be thrown
        }

        [TestMethod]
        public async Task DeleteBet_WithValidId_ShouldRemoveBetFromRepository()
        {
            // Arrange
            var bet = new Bet { BetID = 1 };
            _unitOfWorkMock.Setup(x => x.BetRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Bet, bool>>>())).ReturnsAsync(bet);

            // Act
            var result = await _betService.DeleteBet(bet.BetID);

            // Assert
            _unitOfWorkMock.Verify(x => x.BetRepository.Remove(bet), Times.Once);
            _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
            Assert.AreEqual($"Bet with id: {bet.BetID} deleted successfully", result.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(BetNotFoundException))]
        public async Task DeleteBet_WithInvalidId_ShouldThrowBetNotFoundException()
        {
            // Arrange
            _unitOfWorkMock.Setup(x => x.BetRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Bet, bool>>>())).ReturnsAsync((Bet)null);

            // Act
            await _betService.DeleteBet(1);

            // Assert
            // Expects exception to be thrown
        }
    }
}

