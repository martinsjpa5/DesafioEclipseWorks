
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EF.Configurations
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AtualizadoEm);
            builder.Property(x => x.CriadoEm);
            builder.Property(x => x.Titulo);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.DataVencimento);
            builder.Property(x => x.Status);

            builder.HasMany(x => x.Comentarios).WithOne(y => y.Tarefa).HasForeignKey(y => y.TarefaId);

        }
    }
}
