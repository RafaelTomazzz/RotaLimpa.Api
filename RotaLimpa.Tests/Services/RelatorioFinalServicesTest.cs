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
    public class RelatorioFinalServicesTest
    {
        private readonly Mock<IRelatoriosFinaisRepository> _mockRelatorioFinalRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly RelatoriosFinaisService _service;
        private readonly Mock<ITrajetosService> _mocktrajetosService; 
        private readonly Mock<ISetoresService> _mocksetoresService; 

        public RelatorioFinalServicesTest()
        {
            _mockRelatorioFinalRepository = new Mock<IRelatoriosFinaisRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mocktrajetosService = new Mock<ITrajetosService>(); 
            _mocksetoresService = new Mock<ISetoresService>(); 

            _service = new RelatoriosFinaisService(_mockRelatorioFinalRepository.Object, _mockUnitOfWork.Object, _mocktrajetosService.Object, _mocksetoresService.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnAnExistentUser()
        {
            const int relatorioFinalId = 1;
            RelatorioFinal expectedRelatorioFinal = new RelatorioFinal

            { IdRelatorio =  relatorioFinalId, IdSetor = 1, IdTrajeto = 1};
            _mockRelatorioFinalRepository.Setup(repo => repo.GetRelatorioFinalByIdAsync(relatorioFinalId)).ReturnsAsync(expectedRelatorioFinal);

            RelatorioFinal serviceOrderDtoMock = expectedRelatorioFinal;

            var result = await _service.GetRelatorioFinalByIdAsync(relatorioFinalId);
            Assert.Equal(serviceOrderDtoMock, result);
        }
        [Fact]
        public async Task ShouldThrowNotFoundExceptionIfFrotaIdDontExist()
        {
            const int relatorioFinalId = 1;
            _mockRelatorioFinalRepository.Setup(repo => repo.GetRelatorioFinalByIdAsync(relatorioFinalId)).ReturnsAsync((RelatorioFinal)null);

            Assert.ThrowsAsync<NotFoundException>(() => _service.GetRelatorioFinalByIdAsync(2));

        }
    }
}
