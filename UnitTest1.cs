using Moq;
using SustainableEnergyAPI.Models;
using SustainableEnergyAPI.DTO;
using SustainableEnergyAPI.Repositories;
using SustainableEnergyAPI.Services;
using Xunit;

namespace SustainableEnergyAPI.Tests
{

    public class UnitTest1
    {
        private readonly Mock<IEnergyProcessRepository> _mockRepository;
        private readonly EnergyProcessService _service;

        public UnitTest1()
        {
            // Criando o Mock do repositório
            _mockRepository = new Mock<IEnergyProcessRepository>();

            // Inicializando o serviço passando o mock do repositório
            _service = new EnergyProcessService(_mockRepository.Object);
        }

        [Fact]
        public void Test1()
        {
            var processDTO = new EnergyProcessDTO("Solar Energy", 85.5);
            var createdProcess = new EnergyProcess("Solar Energy", 85.5);

            // Configurando o comportamento do mock
            _mockRepository.Setup(repo => repo.Create(It.IsAny<EnergyProcess>())).Callback<EnergyProcess>(process =>
            {
                createdProcess = process; // Simulando a criação do processo
            });

            var result = _service.Create(processDTO);

            // Verificando se o processo foi criado corretamente
            Assert.NotNull(result);
            Assert.Equal("Solar Energy", result.Name);
            Assert.Equal(85.5, result.Efficiency);
        }

        [Fact]
        public void GetAll_ShouldReturnListOfEnergyProcesses()
        {
            // Arrange - Preparando os dados para o teste
            var processList = new List<EnergyProcess>
            {
                new EnergyProcess("Solar Energy", 85.5),
                new EnergyProcess("Wind Energy", 90.0)
            };

            // Configurando o comportamento do mock para retornar uma lista
            _mockRepository.Setup(repo => repo.GetAll()).Returns(processList);

            // Act - Chamando o método a ser testado
            var result = _service.GetAll();

            // Assert - Verificando o comportamento esperado
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Solar Energy", result.First().Name);
        }
    }
}