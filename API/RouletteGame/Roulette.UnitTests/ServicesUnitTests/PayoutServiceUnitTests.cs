using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.PayoutFeatures.Commands.DeletePayout;
using Roulette.Domain.Entities;
using Roulette.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Tests.Infrastructure.Services
{
    [TestClass]
    public class PayoutServiceUnitTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private PayoutService _payoutService;

        [TestInitialize]
        public void TestInitialize()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _payoutService = new PayoutService(_unitOfWorkMock.Object);
        }

        [TestMethod]
        public async Task GetAllPayouts_ShouldReturnAllPayouts()
        {
            // Arrange
            var expectedPayouts = new List<Payout> { new Payout(), new Payout() };
            _unitOfWorkMock.Setup(x => x.PayoutRepository.GetAllAsync()).ReturnsAsync(expectedPayouts);

            // Act
            var actualPayouts = await _payoutService.GetAllPayouts();

            // Assert
            CollectionAssert.AreEqual(expectedPayouts, (List<Payout>)actualPayouts);
        }

        [TestMethod]
        public async Task GetPayout_WithValidId_ShouldReturnPayout()
        {
            // Arrange
            var expectedPayout = new Payout { PayoutID = 1 };
            _unitOfWorkMock.Setup(x => x.PayoutRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Payout, bool>>>())).ReturnsAsync(expectedPayout);

            // Act
            var actualPayout = await _payoutService.GetPayout(1);

            // Assert
            Assert.AreEqual(expectedPayout, actualPayout);
        }

        [TestMethod]
        public async Task GetPayout_WithInvalidId_ShouldThrowPayoutNotFoundException()
        {
            // Arrange
            _unitOfWorkMock.Setup(x => x.PayoutRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Payout, bool>>>())).ReturnsAsync((Payout)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<PayoutNotFoundException>(() => _payoutService.GetPayout(1));
        }

        [TestMethod]
        public async Task CreatePayout_ShouldAddPayoutToRepository()
        {
            // Arrange
            var payoutToAdd = new Payout();

            // Act
            await _payoutService.CreatePayout(payoutToAdd);

            // Assert
            _unitOfWorkMock.Verify(x => x.PayoutRepository.Add(payoutToAdd), Times.Once);
            _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
        }

        [TestMethod]
        public async Task UpdatePayout_WithValidPayout_ShouldUpdatePayoutInRepository()
        {
            // Arrange
            var payoutToUpdate = new Payout { PayoutID = 1 };
            _unitOfWorkMock.Setup(x => x.PayoutRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Payout, bool>>>())).ReturnsAsync(payoutToUpdate);

            // Act
            await _payoutService.UpdatePayout(payoutToUpdate);

            // Assert
            _unitOfWorkMock.Verify(x => x.PayoutRepository.Update(payoutToUpdate), Times.Once);
            _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
        }

        [TestMethod]
        public async Task UpdatePayout_WithInvalidPayout_ShouldThrowPayoutNotFoundException()
        {
            // Arrange
            var payoutToUpdate = new Payout { PayoutID = 1 };
            _unitOfWorkMock.Setup(x => x.PayoutRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Payout, bool>>>())).ReturnsAsync((Payout)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<PayoutNotFoundException>(() => _payoutService.UpdatePayout(payoutToUpdate));
        }

        [TestMethod]
        public async Task DeletePayout_WithValidId_ShouldRemovePayoutFromRepository()
        {
            // Arrange
            var payoutToDelete = new Payout { PayoutID = 1 };
            _unitOfWorkMock.Setup(x => x.PayoutRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Payout, bool>>>())).ReturnsAsync(payoutToDelete);

            // Act
            var response = await _payoutService.DeletePayout(1);

            // Assert
            _unitOfWorkMock.Verify(x => x.PayoutRepository.Remove(payoutToDelete), Times.Once);
            _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
            Assert.AreEqual($"Payout with id: {payoutToDelete.PayoutID} deleted successfully", response.Message);
        }

        [TestMethod]
        public async Task DeletePayout_WithInvalidId_ShouldThrowPayoutNotFoundException()
        {
            // Arrange
            _unitOfWorkMock.Setup(x => x.PayoutRepository.GetAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Payout, bool>>>())).ReturnsAsync((Payout)null);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<PayoutNotFoundException>(() => _payoutService.DeletePayout(1));
        }
    }
}

