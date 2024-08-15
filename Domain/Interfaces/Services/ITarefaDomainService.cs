using Domain.Entities;
using Domain.Models;
using Utils.Response;

namespace Domain.Interfaces.Services
{
    public interface ITarefaDomainService
    {
        public Task<CommonResponse> EditarAsync(Tarefa entidade, CommonUser user);
    }
}
