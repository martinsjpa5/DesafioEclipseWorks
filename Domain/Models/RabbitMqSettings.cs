

namespace Domain.Models
{
    public class RabbitMqSettings
    {
        public string Hostname { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Exchange { get; set; }
        public string QueueName { get; set; }
        public string ExchangeType { get; set; }
        public bool Durable { get; set; } = true;
        public bool Exclusive { get; set; } = false;
        public bool AutoDelete { get; set; } = false;
        public string[] RoutingKeys { get; set; }
    }
}
