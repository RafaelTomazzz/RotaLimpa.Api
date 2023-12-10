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
    public class FrotaServicesTest
    {
        private readonly Mock<IFrotasRepository> _mockFrotasRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly FrotasService _service;


        public FrotaServicesTest()
        {
            _mockFrotasRepository = new Mock<IFrotasRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _service = new FrotasService(_mockFrotasRepository.Object, _mockUnitOfWork.Object);
        }
        [Fact]
        public async Task  GetById_ShouldReturnAnExistentUser()
        {
            const int frotaId = 1;
            Frota expectedFrota = new Frota

            { IdVeiculo = frotaId, PVeiculo = "ASC12", TmnVeiculo = 1.52, StVeiculo = "1" };
            _mockFrotasRepository.Setup(repo => repo.GetFrotaByIdAsync(frotaId)).ReturnsAsync(expectedFrota);

            Frota serviceOrderDtoMock = expectedFrota;

            var result = await _service.GetFrotaByIdAsync(frotaId);
            Assert.Equal(serviceOrderDtoMock, result);
        }
        [Fact]
        public async Task ShouldThrowNotFoundExceptionIfFrotaIdDontExist()
        {
            const int frotaId = 1;
            _mockFrotasRepository.Setup(repo => repo.GetFrotaByIdAsync(frotaId)).ReturnsAsync((Frota)null);

            Assert.ThrowsAsync<NotFoundException>(() => _service.GetFrotaByIdAsync(2));

        }
       
    }
}
