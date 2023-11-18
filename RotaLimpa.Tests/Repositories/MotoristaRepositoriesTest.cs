using Moq;
using RotaLimpa.Api.Repositories.Interfaces;
using RotaLimpa.Api.Repositories.UnitOfWork;
using RotaLimpa.Api.Repositories;

namespace RotaLimpa.Tests.Repositories
{
    public class MotoristaRepositoriesTest
    {
        private readonly Mock<IMotoristasRepository> _mockMotoristaRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly MotoristasRepository _motoristaTepository;
    }
}
