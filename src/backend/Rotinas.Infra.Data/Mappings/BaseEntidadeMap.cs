using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rotinas.Domain.Entidades;

namespace Rotinas.Infra.Data.Mappings
{
    public abstract class BaseEntidadeMap<T> : IEntityTypeConfiguration<T> where T : BaseEntidade
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.CriadoEm);

            builder.Property(t => t.AtualizadoEm)
                .HasConversion(toProvider => DateTime.Now, fromProvider => fromProvider);
        }
    }
}
