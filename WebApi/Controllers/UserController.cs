using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class UserController : CommonController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Gerentes")]
        public IActionResult ObterGerentes()
        {
            var result = _userService.ObterGerentes();

            return CommonResponse(result);
        }

        [HttpGet("Analistas")]
        public IActionResult ObterAnalistas()
        {
            var result = _userService.ObterAnalistas();

            return CommonResponse(result);
        }
    }
}
