using Domain.Entities;
using Moq.AutoMock;

namespace Tests.Domain.Entities
{
    
    public class HistoricoAlteracaoTarefaTests
    {
        private readonly AutoMocker _autoMocker;
        public HistoricoAlteracaoTarefaTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task EhValida_HistoricoAlteracaoTarefaValido_RetornaSucesso()
        {
            // Arrange
            var historico = new HistoricoAlteracaoTarefa();
            // Act
            var result = historico.EhValida();

            // Assert
            Assert.True(result.Sucesso);
        }
    }
}
