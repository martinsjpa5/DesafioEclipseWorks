using System;

namespace Domain.Models
{
    public class RabbitMqAppSettings
    {
        public string Hostname { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public RabbitMqQueueAppSettings[] Queues { get; set; }
    }
    public class RabbitMqQueueAppSettings
    {
        public string Name { get; set; }
        public string[] RoutingKeys { get; set; }
        public string Exchange { get; set; }
    }
}
