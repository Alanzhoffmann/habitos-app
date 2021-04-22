using System;
using System.Linq;
using Rotinas.Domain.ValueObjects;

namespace Rotinas.Domain.DTO
{
    public class RepeticaoViewModel
    {
        public bool Domingo { get; private set; }
        public bool Segunda { get; private set; }
        public bool Terca { get; private set; }
        public bool Quarta { get; private set; }
        public bool Quinta { get; private set; }
        public bool Sexta { get; private set; }
        public bool Sabado { get; private set; }

        public static explicit operator RepeticaoViewModel?(Repeticao? repeticao)
        {
            if (repeticao is null)
            {
                return null;
            }

            return new RepeticaoViewModel
            {
                Domingo = repeticao.DiasSemana.Contains(DayOfWeek.Sunday),
                Segunda = repeticao.DiasSemana.Contains(DayOfWeek.Monday),
                Terca = repeticao.DiasSemana.Contains(DayOfWeek.Tuesday),
                Quarta = repeticao.DiasSemana.Contains(DayOfWeek.Wednesday),
                Quinta = repeticao.DiasSemana.Contains(DayOfWeek.Thursday),
                Sexta = repeticao.DiasSemana.Contains(DayOfWeek.Friday),
                Sabado = repeticao.DiasSemana.Contains(DayOfWeek.Saturday)
            };
        }
    }
}