using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Services;
using Moq.AutoMock;
using Moq;


namespace Tests.Domain.Entities
{
    public class TarefaTests
    {
        private readonly AutoMocker _autoMocker;

        public TarefaTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task Editar_Tarefa_RetornaSucesso()
        {
            // Arrange
            var tarefa = new Tarefa { Status = EStatusTarefa.CONCLUIDA, Id = 1, Titulo = "teste", Descricao = "teste", DataVencimento = DateTime.Now };
            var commonValueString = "editado";
            // Act
            var result = tarefa.Editar(commonValueString, commonValueString, DateTime.Now, EStatusTarefa.CONCLUIDA);

            // Assert
            Assert.True(result.Sucesso);
            Assert.NotNull(tarefa.AtualizadoEm);
        }

        [Fact]
        public async Task EhValida_Tarefa_RetornaSucesso()
        {
            // Arrange
            var tarefa = new Tarefa { Status = EStatusTarefa.CONCLUIDA, Id = 1, Titulo = "teste" };

            // Act
            var result = tarefa.EhValida();

            // Assert
            Assert.True(result.Sucesso);
        }
    }
}
