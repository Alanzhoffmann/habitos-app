using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rotinas.Domain.ValueObjects;

namespace Rotinas.Infra.Data.Mappings
{
    public static class RepeticaoMap
    {
        public static EntityTypeBuilder<T> OwnsRepeticao<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, Repeticao>> expression) where T : class
        {
            builder.Property(expression)
                .HasConversion(r => r.RetornarValor(), valor => Repeticao.MontarRepeticao(valor));

            return builder;
        }
    }
}
