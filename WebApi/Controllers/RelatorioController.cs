using Application.Interfaces;
using Application.ViewModels.Requests;
using Domain.Interfaces.Queues;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class RelatorioController : CommonController
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpPost("Gerar")]
        public async Task<IActionResult> PedirParaGerarRelatorioAsync(RelatorioRequest request)
        {
            var result = await _relatorioService.PedirParaGerarRelatorioAsync(request);
            return CommonResponse(result);
        }

        [HttpGet("Obter")]
        public async Task<IActionResult> ObterRelatorioDesempenhoAsync([FromQuery] RelatorioRequest request)
        {
            var result = await _relatorioService.ObterRelatorioDesempenhoAsync(request);
            return CommonResponse(result);
        }
    }
}
