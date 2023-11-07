using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Exceptions;
using Roulette.Domain.Entities;
using Roulette.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Features.SpinFeatures.Commands.DeleteSpin;

namespace Roulette.Tests.Infrastructure.Services
{
    [TestClass]
    public class SpinServiceUnitTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private SpinService _spinService;

        [TestInitialize]
        public void Initialize()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _spinService = new SpinService(_unitOfWorkMock.Object);
        }

        [TestMethod]
        public async Task GetAllSpins_ShouldReturnAllSpins()
        {
            // Arrange
            var expectedSpins = new List<Spin> { new Spin(), new Spin() };
            _unitOfWorkMock.Setup(uow => uow.SpinRepository.GetAllAsync()).ReturnsAsync(expectedSpins);

            // Act
            var actualSpins = await _spinService.GetAllSpins();

            // Assert
            Assert.AreEqual(expectedSpins.Count, actualSpins.Count);
        }

        [TestMethod]
        public async Task CreateSpin_ShouldAddSpinToRepository()
        {
            // Arrange
            var spinToAdd = new Spin();
            _unitOfWorkMock.Setup(uow => uow.SpinRepository.Add(spinToAdd));

            // Act
            var actualSpin = await _spinService.CreateSpin(spinToAdd);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.SpinRepository.Add(spinToAdd), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
            Assert.AreEqual(spinToAdd, actualSpin);
        }

        [TestMethod]
        public async Task UpdateSpin_ShouldUpdateExistingSpin()
        {
            // Arrange
            var existingSpin = new Spin { SpinID = 1 };
            var updatedSpin = new Spin { SpinID = 1 };
            _unitOfWorkMock.Setup(uow => uow.SpinRepository.GetAsync(s => s.SpinID == existingSpin.SpinID)).ReturnsAsync(existingSpin);

            // Act
            var actualSpin = await _spinService.UpdateSpin(updatedSpin);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.SpinRepository.Update(existingSpin), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
            Assert.AreEqual(updatedSpin, actualSpin);
        }

        [TestMethod]
        public async Task UpdateSpin_ShouldThrowSpinNotFoundException_WhenSpinDoesNotExist()
        {
            // Arrange
            var nonExistingSpin = new Spin { SpinID = 1 };
            _unitOfWorkMock.Setup(uow => uow.SpinRepository.GetAsync(s => s.SpinID == nonExistingSpin.SpinID)).ReturnsAsync(null as Spin);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<SpinNotFoundException>(() => _spinService.UpdateSpin(nonExistingSpin));
        }

        [TestMethod]
        public async Task GetSpin_ShouldReturnSpinWithGivenId()
        {
            // Arrange
            var expectedSpin = new Spin { SpinID = 1 };
            _unitOfWorkMock.Setup(uow => uow.SpinRepository.GetAsync(s => s.SpinID == expectedSpin.SpinID)).ReturnsAsync(expectedSpin);

            // Act
            var actualSpin = await _spinService.GetSpin(expectedSpin.SpinID);

            // Assert
            Assert.AreEqual(expectedSpin, actualSpin);
        }

        [TestMethod]
        public async Task DeleteSpin_ShouldRemoveSpinWithGivenId()
        {
            // Arrange
            var spinToRemove = new Spin { SpinID = 1 };
            _unitOfWorkMock.Setup(uow => uow.SpinRepository.GetAsync(s => s.SpinID == spinToRemove.SpinID)).ReturnsAsync(spinToRemove);

            // Act
            var response = await _spinService.DeleteSpin(spinToRemove.SpinID);

            // Assert
            _unitOfWorkMock.Verify(uow => uow.SpinRepository.Remove(spinToRemove), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CommitAsync(), Times.Once);
            Assert.AreEqual($"Spin with id: {spinToRemove.SpinID} deleted successfully", response.Message);
        }

        [TestMethod]
        public async Task DeleteSpin_ShouldThrowSpinNotFoundException_WhenSpinDoesNotExist()
        {
            // Arrange
            var nonExistingSpinId = 1;
            _unitOfWorkMock.Setup(uow => uow.SpinRepository.GetAsync(s => s.SpinID == nonExistingSpinId)).ReturnsAsync(null as Spin);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<SpinNotFoundException>(() => _spinService.DeleteSpin(nonExistingSpinId));
        }
    }
}

