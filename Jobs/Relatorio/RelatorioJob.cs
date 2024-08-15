using Application.Interfaces;
using Domain.Interfaces.Queues;
using Newtonsoft.Json;

namespace Relatorio
{
    public class RelatorioJob : BackgroundService
    {
        private readonly IRelatorioQueue _relatorioQueue;
        private readonly IRelatorioService _relatorioService;

        public RelatorioJob(IRelatorioQueue relatorioQueue, IRelatorioService relatorioService)
        {
            _relatorioQueue = relatorioQueue;
            _relatorioService = relatorioService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _relatorioQueue.StartConsumers(1, async (msg) =>
            {
                await _relatorioService.GerarRelatorioDesempenhoAsync(new Application.ViewModels.Requests.RelatorioRequest { AnalistaId = msg.Usuario });
            }, stoppingToken);
        }
    }
}
