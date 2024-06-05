using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ObservacoesMap : IEntityTypeConfiguration<ObservacoesModel>
    {
        public void Configure(EntityTypeBuilder<ObservacoesModel> builder)
        {
            builder.HasKey(x => x.ObservacoesId);
            builder.Property(x=> x.ObservacaoDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObservacaoLocal).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ObservacaoData).IsRequired().HasMaxLength(255);
            builder.Property(x => x.AnimalId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
        }
    }
}
