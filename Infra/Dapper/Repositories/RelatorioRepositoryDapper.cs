
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infra.Dapper.Repositories
{
    public class RelatorioRepositoryDapper : IRelatorioRepositoryDapper
    {
        private readonly ICommonRepositoryDapper _commonRepositoryDapper;

        public RelatorioRepositoryDapper(ICommonRepositoryDapper commonRepositoryDapper)
        {
            _commonRepositoryDapper = commonRepositoryDapper;
        }

        public async Task<RelatorioDesempenho> ObterRelatorioDesempenhoAsync(Guid criadoPor)
        {
            string query = @$"SELECT 
                     h.CriadoPor as Usuario,
                     COUNT(DISTINCT h.TarefaId) AS TarefasConcluidasUltimos30Dias
                 FROM 
                     HistoricoAlteracaoTarefa as h
                 INNER JOIN 
                     Tarefas as t on t.Id = h.TarefaId
                 WHERE 
                     h.CriadoEm >= DATEADD(DAY, -30, GETDATE())
                     AND JSON_VALUE(h.Alteracoes, '$.Tarefa.Status') = '2'
                     AND h.CriadoPor = @CriadoPor
                     AND t.Status = 2
                 GROUP BY 
                     h.CriadoPor";

            var parameters = new { CriadoPor = criadoPor };

            var result = await _commonRepositoryDapper.QuerySingleAsync<RelatorioDesempenho>(query, parameters);

            if (result == null)
                return new RelatorioDesempenho { Usuario = criadoPor, TarefasConcluidasUltimos30Dias = 0 };

            return result;
        }

    }
}
