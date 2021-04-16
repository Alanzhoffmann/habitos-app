using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rotinas.Domain.Entidades;

namespace Rotinas.Infra.Data.Mappings
{
    public class TarefaMap : BaseEntidadeMap<Tarefa>
    {
        public override void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            base.Configure(builder);

            builder.Property(t => t.Nome);
            builder.Property(t => t.Duracao);

            builder.OwnsRepeticao(t => t.Repeticao);
        }
    }
}
