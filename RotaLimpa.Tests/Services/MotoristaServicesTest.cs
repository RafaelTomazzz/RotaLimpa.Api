using Moq;
using RotaLimpa.Api.Exceptions;
using RotaLimpa.Api.Models;
using RotaLimpa.Api.Repositories.Interfaces;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Services;

namespace RotaLimpa.Tests.Services
{
    public class MotoristaServicesTest
    {
        private readonly Mock<IMotoristasRepository> _mockMotoristaRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly MotoristasService _service;


        public MotoristaServicesTest()
        {
            _mockMotoristaRepository = new Mock<IMotoristasRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _service = new MotoristasService(_mockMotoristaRepository.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task ShouldGenerateUniqueLoginInTheYearDifferentCurrentYear()
        {
            var expectedLogin = "0011223";
            string loginAtual = await _service.GerarUnicoLoginAsync();

            Assert.Equal(loginAtual, expectedLogin);
        }

        [Fact]
        public async Task ShouldGenerateLogin999()
        {
            string loginAtual = "";
            for (int i = 0; i < 3; i++)
            {
                loginAtual = await _service.GerarUnicoLoginAsync();

            }
            var expectedLogin = "0011223"; //consulta no banco de dados de motorista quantos estão cadastrados
            Assert.Equal(loginAtual, expectedLogin);
        }
        [Fact]
        public async Task GetById_ShouldReturnAnExistentUser()
        {
            const int motoristaId = 1;
            Motorista expectedMotorista = new Motorista

            { Id = motoristaId, Cpf = "524788321560", PNome = "Marcos", SNome = "Paulo", Login = "0011223" };
            _mockMotoristaRepository.Setup(repo => repo.GetMotoristaByIdAsync(motoristaId)).ReturnsAsync(expectedMotorista);

            Motorista serviceOrderDtoMock = expectedMotorista;

            var result = await _service.GetMotoristaByIdAsync(motoristaId);
            Assert.Equal(serviceOrderDtoMock, expectedMotorista);
        }
        [Fact]
        public async Task ShouldThrowNotFoundExceptionIfFrotaIdDontExist()
        {
            const int motoristaId = 1;
            _mockMotoristaRepository.Setup(repo => repo.GetMotoristaByIdAsync(motoristaId)).ReturnsAsync((Motorista)null);

            Assert.ThrowsAsync<NotFoundException>(() => _service.GetMotoristaByIdAsync(2));

        }
    }
}
