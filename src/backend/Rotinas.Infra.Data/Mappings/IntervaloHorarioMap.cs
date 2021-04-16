using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rotinas.Domain.ValueObjects;

namespace Rotinas.Infra.Data.Mappings
{
    public static class IntervaloHorarioMap
    {
        public static EntityTypeBuilder<T> OwnsIntervaloHorario<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, IntervaloHorario>> expression) where T : class
        {
            return builder.OwnsOne(expression, b =>
            {
                b.Property(i => i.Inicio);
                b.Property(i => i.Fim);
            });
        }
    }
}
