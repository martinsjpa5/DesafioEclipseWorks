using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services;
using Moq;
using Moq.AutoMock;

namespace Tests.Domain.Services
{
    public class TarefaDomainServiceTests
    {
        private readonly AutoMocker _autoMocker;

        public TarefaDomainServiceTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task EditarAsync_TarefaQueAlteraResultadoRelatorio_RetornaSucessoAsync()
        {
            // Arrange
            var service = _autoMocker.CreateInstance<TarefaDomainService>();
            var tarefa = new Tarefa { Status = EStatusTarefa.CONCLUIDA, Id = 1 };
            var user = new CommonUser { Id = Guid.NewGuid() };

            // Act
            var result = await service.EditarAsync(tarefa,user);

            // Assert
            _autoMocker.GetMock<ICommonRepositoryEF>().Verify(x => x.AdicionarEntidadeAsync(It.IsAny<HistoricoAlteracaoTarefa>()), Times.Once);

            Assert.True(result.Sucesso);
        }
    }
}
