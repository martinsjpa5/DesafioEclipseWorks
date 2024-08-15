using Application.Interfaces;
using Application.Services;
using Application.ViewModels.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class TarefaController : CommonController
    {
        private readonly ITarefaService _tarefaService;
        private readonly IComentarioService _comentarioService;

        public TarefaController(ITarefaService tarefaService, IComentarioService comentarioService)
        {
            _tarefaService = tarefaService;
            _comentarioService = comentarioService;
        }

        [HttpPut]
        public async Task<IActionResult> EditarAsync(TarefaEditarRequest request)
        {
            var result = await _tarefaService.EditarAsync(request);

            return CommonResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarAsync(TarefaSalvarRequest request)
        {
            var result = await _tarefaService.SalvarAsync(request);

            return CommonResponse(result);
        }

        [HttpDelete("{tarefaId}")]
        public async Task<IActionResult> DeletarAsync(int tarefaId)
        {
            var result = await _tarefaService.DeletarAsync(tarefaId);
            return CommonResponse(result);
        }

        [HttpPost("Comentario")]
        public async Task<IActionResult> SalvarComentarioAsync(ComentarioSalvarRequest request)
        {
            var result = await _comentarioService.SalvarAsync(request);

            return CommonResponse(result);
        }
    }
}
