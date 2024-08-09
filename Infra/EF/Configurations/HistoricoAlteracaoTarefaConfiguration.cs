
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EF.Configurations
{
    public class HistoricoAlteracaoTarefaConfiguration : IEntityTypeConfiguration<HistoricoAlteracaoTarefa>
    {
        public void Configure(EntityTypeBuilder<HistoricoAlteracaoTarefa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AtualizadoEm);
            builder.Property(x => x.CriadoEm);
            builder.Property(x => x.CriadoPor);
            builder.Property(x => x.Alteracoes);

            builder.HasOne(x => x.Tarefa).WithMany(y => y.HistoricosAlteracoes).HasForeignKey(y => y.TarefaId);
        }
    }
}
