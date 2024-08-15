using Microsoft.AspNetCore.Mvc;
using Utils.Response;

namespace WebApi.Controllers
{
    [ApiController]
    public class CommonController : ControllerBase
    {
        protected IActionResult CommonResponse(CommonResponse response)
        {
            if (response.Erros.Count > 0)
                return BadRequest(response);
            else
                return Ok(response);
        }
        protected IActionResult CommonResponse<T>(CommonGenericResponse<T> response)
        {
            if (response.Erros.Count > 0)
                return BadRequest(response);
            else
                return Ok(response);
        }
    }
}
