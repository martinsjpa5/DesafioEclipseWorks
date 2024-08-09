
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
            builder.Property(x => x.Detalhes);
            builder.Property(x => x.Status);
            


        }
    }
}
