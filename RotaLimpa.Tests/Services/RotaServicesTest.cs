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
    public class RotaServicesTest
    {
        private readonly Mock<IRotasRepository> _mockRotasRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly RotasService _service;


        public RotaServicesTest()
        {
            _mockRotasRepository = new Mock<IRotasRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _service = new RotasService(_mockRotasRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnAnExistentUser()
        {
            const int rotaId = 1;
            Rota expectedRota = new Rota

            { Id = rotaId, IdColaborador = rotaId, IdSetor = rotaId, DtRota = 2023-01-01,  TmRota = 2023-01-01};
            _mockRotasRepository.Setup(repo => repo.GetRotaByIdAsync(rotaId)).ReturnsAsync(expectedRota);

            Rota serviceOrdersDtoMock = expectedRota;

            var result = await _service.GetRotaByIdAsync(rotaId);

            Assert.Equal(serviceOrdersDtoMock, result);
        }
    }
}