using Domain.Contracts.Queues;
using Domain.Interfaces.Queues;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infra.Queues
{
    public class RelatorioQueue : RabbitMqQueue<RelatorioMessage>, IRelatorioQueue
    {
        public RelatorioQueue(IOptions<RabbitMqAppSettings> settings, ILogger<RabbitMqQueue<RelatorioMessage>> logger) : base(GetQueueSettings(settings.Value), logger)
        {

        }

        public static RabbitMqSettings GetQueueSettings(RabbitMqAppSettings settings)
        {

            return new RabbitMqSettings
            {
                Hostname = settings.Hostname,
                Port = settings.Port,
                Username = settings.Username,
                Password = settings.Password,
                Exchange = "EXG.RELATORIO",
                ExchangeType = ExchangeType.DIRECT,
                QueueName = "QUEUE.RELATORIO",
                RoutingKeys = ["produce_start"],
            };
        }
    }
}
