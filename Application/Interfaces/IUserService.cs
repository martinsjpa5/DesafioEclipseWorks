using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Response;

namespace Application.Interfaces
{
    public interface IUserService
    {
        CommonGenericResponse<List<CommonUser>> ObterGerentes();
        CommonGenericResponse<List<CommonUser>> ObterAnalistas();
    }
}
