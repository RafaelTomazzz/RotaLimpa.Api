using Moq;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaLimpa.Tests.Services
{
    public class KilometragemServicesTest
    {
        private readonly Mock<IKilometragensRepository> _mockKilometragemRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IFrotasService> _mockFrotasService;
        private readonly KilometragensService _service;

        public KilometragemServicesTest()
        {
            _mockKilometragemRepository = new Mock<IKilometragensRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockFrotasService = new Mock<IFrotasService>();
            _service = new KilometragensService(_mockKilometragemRepository.Object, _mockUnitOfWork.Object, _mockFrotasService.Object);
        }
        [Fact]
        public async Task GetById_ShouldReturnExistentUser()
        {
            const int kilometragemId = 1;
            Kilometragem expectedKilometragem = new Kilometragem 
            
            { IdVeiculo = kilometragemId, Km = 120 };
            _mockKilometragemRepository.Setup(repo => repo.GetKilometragemByIdAsync(kilometragemId)).ReturnsAsync(expectedKilometragem);

            Kilometragem ServiceOrderDtoMock = expectedKilometragem;
            var result = await _service.GetKilometragemByIdAsync(kilometragemId);

            Assert.Equal(ServiceOrderDtoMock, result);
        }
        [Fact]
        public async Task ShouldThrowNotFoundExceptionIfFrotaIdDontExist()
        {
            const int kilometragemId = 1;
            _mockKilometragemRepository.Setup(repo => repo.GetKilometragemByIdAsync(kilometragemId)).ReturnsAsync((Kilometragem)null);

            Assert.ThrowsAsync<NotFoundException>(() => _service.GetKilometragemByIdAsync(2));

        }
    }
}
