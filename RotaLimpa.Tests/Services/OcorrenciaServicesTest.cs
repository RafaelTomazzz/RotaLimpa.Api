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
    public class OcorrenciaServicesTest
    {
        private readonly Mock<IOcorrenciasRepository> _mockOcorrenciaRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ITrajetosService> _mockTrajetosService;
        private readonly OcorrenciasService _service;
        

        public OcorrenciaServicesTest ()
        {
            _mockOcorrenciaRepository = new Mock<IOcorrenciasRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockTrajetosService = new Mock<ITrajetosService>();
            _service = new OcorrenciasService(_mockOcorrenciaRepository.Object, _mockUnitOfWork.Object, _mockTrajetosService.Object);

        }
        [Fact]
        public async Task GetById_ShouldReturnExistentUser()
        {
            const int ocorrenciaId = 1;

            Ocorrencia expectedOcorrencia = new Ocorrencia
            { Id = ocorrenciaId, IdCep = 1, IdTrajeto = 1 };

            _mockOcorrenciaRepository.Setup(repo => repo.GetOcorrenciaByIdAsync(ocorrenciaId)).ReturnsAsync(expectedOcorrencia);

            Ocorrencia ServiceOrderDtoMock = expectedOcorrencia;

            var result = await _service.GetOcorrenciaByIdAsync(ocorrenciaId);
            Assert.Equal(ServiceOrderDtoMock, result);
        }
        [Fact]
        public async Task ShouldThrowNotFoundExceptionIfOcorrenciaIdDontExist()
        {
            const int ocorrenciaId = 1;
            _mockOcorrenciaRepository.Setup(repo => repo.GetOcorrenciaByIdAsync(ocorrenciaId)).ReturnsAsync((Ocorrencia)null);

            Assert.ThrowsAsync<NotFoundException>(() => _service.GetOcorrenciaByIdAsync(8));

        }

    }
}
