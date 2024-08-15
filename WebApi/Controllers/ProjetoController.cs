using Application.Interfaces;
using Application.ViewModels.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class ProjetoController : CommonController
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var result = await _projetoService.ObterTodosAsync();

            return CommonResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarAsync(ProjetoSalvarRequest request)
        {
            var result = await _projetoService.SalvarAsync(request);
            return CommonResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditarAsync(ProjetoEditarRequest request)
        {
            var result = await _projetoService.EditarAsync(request);
            return CommonResponse(result);
        }

        [HttpDelete("{projetoId}")]
        public async Task<IActionResult> DeletarAsync(int projetoId)
        {
            var result = await _projetoService.DeletarAsync(projetoId);
            return CommonResponse(result);
        }
    }
}
