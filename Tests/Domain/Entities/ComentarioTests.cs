using Domain.Entities;
using Moq.AutoMock;
namespace Tests.Domain.Entities
{
    public class ComentarioTests
    {
        private readonly AutoMocker _autoMocker;

        public ComentarioTests()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task EhValida_ComentarioValido_RetornaSucesso()
        {
            // Arrange
            var comentario = new Comentario { Descricao = "oi" };
            // Act
            var result = comentario.EhValida();

            // Assert
            Assert.True(result.Sucesso);
        }

    }
}
