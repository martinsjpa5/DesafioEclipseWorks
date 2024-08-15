
using Domain.Contracts.Queues;
using Domain.Models;

namespace Domain.Interfaces.Queues
{
    public interface IRelatorioQueue : IRabbitMqQueue<RelatorioMessage>
    {
        extern RabbitMqSettings GetQueueSettings(RabbitMqAppSettings settings);
    }
}
