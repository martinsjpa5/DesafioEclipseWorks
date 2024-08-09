using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.EF.Configurations
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CriadoEm);
            builder.Property(x => x.AtualizadoEm);
            builder.Property(x => x.Nome);

            builder.HasMany(x => x.Tarefas).WithOne(y => y.Projeto).HasForeignKey(x => x.ProjetoId);
        }
    }
}
