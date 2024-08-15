
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.EF.Configurations
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AtualizadoEm);
            builder.Property(x => x.CriadoEm);


            builder.ToTable("Comentarios");
        }
    }
}
