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
    public class PeriodoServicesTest
    {
        private readonly Mock<IPeriodosRepository> _mockPeriodoRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly PeriodosService _service;

        public PeriodoServicesTest ()
        {
            _mockPeriodoRepository = new Mock<IPeriodosRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _service = new PeriodosService(_mockPeriodoRepository.Object, _mockUnitOfWork.Object);
        }
        [Fact]
        public async Task GetById_ShoulReturnExistentUser()
        {
            const int periodoId = 1;
            Periodo expectedPeriodos = new Periodo
            { Id = periodoId, MfPeriodo = "Sim" };
            _mockPeriodoRepository.Setup(repo => repo.GetPeriodoByIdAsync(periodoId)).ReturnsAsync(expectedPeriodos);

            Periodo ServiceOrderDtoMock = expectedPeriodos;
            var result = await _service.GetPeriodoByIdAsync(periodoId);

            Assert.Equal(expectedPeriodos, result);
        }
        [Fact]
        public async Task ShouldThrowNotFoundExceptionIfPeriodoIdDontExist()
        {
            const int periodoId = 1;
            _mockPeriodoRepository.Setup(repo => repo.GetPeriodoByIdAsync(periodoId)).ReturnsAsync((Periodo)null);

            Assert.ThrowsAsync<NotFoundException>(() => _service.GetPeriodoByIdAsync(2));

        }
    }
}
