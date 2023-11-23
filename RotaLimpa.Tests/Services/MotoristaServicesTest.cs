using Moq;
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
            var expectedLogin = "0011123";
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
            var expectedLogin = "0041123"; //consulta no banco de dados de motorista quantos estão cadastrados
            Assert.Equal(loginAtual, expectedLogin);
        }
    }
}
