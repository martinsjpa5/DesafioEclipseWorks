using Domain.Entities;
using Domain.Enum;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain.Entities
{
    public class ProjetoTests
    {
        private readonly AutoMocker _autoMocker;

        public ProjetoTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task Editar_Projeto_RetornaSucesso()
        {
            // Arrange
            var projeto = new Projeto { Nome = "Teste" };
            // Act
            var result = projeto.Editar("teste2");

            // Assert
            Assert.True(result.Sucesso);
            Assert.NotNull(projeto.AtualizadoEm); ;
        }

        [Fact]
        public async Task PodeDeletar_ProjetoSemTarefaOuTodosConcluidas_RetornaSucesso()
        {
            // Arrange
            var projeto = new Projeto { Nome = "Teste", Tarefas = [] };
            // Act
            var result = projeto.PodeDeletar();

            // Assert
            Assert.True(result.Sucesso);
        }

        [Fact]
        public async Task PodeDeletar_ProjetoComTarefaNaoConcluida_RetornaErro()
        {
            // Arrange
            var projeto = new Projeto { Nome = "Teste", Tarefas = [new Tarefa { Status = EStatusTarefa.PENDENTE}] };
            // Act
            var result = projeto.PodeDeletar();

            // Assert
            Assert.False(result.Sucesso);
        }

        [Fact]
        public async Task AdicionarTarefa_ProjetoDentroDaQuantidadeMaximaDeTarefas_RetornaSucesso()
        {
            // Arrange
            var projeto = new Projeto { Nome = "Teste", Tarefas = [new Tarefa { Status = EStatusTarefa.PENDENTE }] };
            // Act
            var result = projeto.AdicionarTarefa(new Tarefa());

            // Assert
            Assert.True(result.Sucesso);
        }

        [Fact]
        public async Task AdicionarTarefa_ProjetoForaDaQuantidadeMaximaDeTarefas_RetornaErro()
        {
            // Arrange
            var projeto = new Projeto { Nome = "Teste", Tarefas = [new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa(), new Tarefa()] };
            
            // Act
            var result = projeto.AdicionarTarefa(new Tarefa());

            // Assert
            Assert.False(result.Sucesso);
        }

    }
}
