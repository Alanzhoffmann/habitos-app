using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rotinas.Domain.ValueObjects;

namespace Rotinas.Infra.Data.Mappings
{
    public static class RepeticaoMap
    {
        public static PropertyBuilder<Repeticao> OwnsRepeticao<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, Repeticao>> expression) where T : class
        {
            return builder.Property(expression)
                 .HasConversion(r => r.ParaInt32(), valor => Repeticao.DeInt32(valor));
        }
    }
}
