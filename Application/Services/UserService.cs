using Application.Interfaces;
using Domain.Interfaces.Caching.Repositories;
using Domain.Models;
using ExternalServices.Interfaces;
using Utils.Response;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthExternalService _externalService;

        public UserService(IAuthExternalService externalService)
        {
            _externalService = externalService;
        }

        public CommonGenericResponse<List<CommonUser>> ObterGerentes()
        {
            return CommonGenericResponse<List<CommonUser>>.SucessoBuilder(_externalService.ObterGerentes());
        }
        public CommonGenericResponse<List<CommonUser>> ObterAnalistas()
        {
            return CommonGenericResponse<List<CommonUser>>.SucessoBuilder(_externalService.ObterAnalistas());
        }
    }
}
