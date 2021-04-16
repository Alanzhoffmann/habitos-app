using System;
using System.Collections.Generic;
using System.Linq;

namespace Rotinas.Domain.ValueObjects
{
    public class Repeticao
    {
        public Repeticao(DayOfWeek[] diasSemana)
        {
            DiasSemana = diasSemana;
        }

        [Flags]
        private enum DiaSemana
        {
            Domingo = 1,
            Segunda = 2,
            Terca = 4,
            Quarta = 8,
            Quinta = 16,
            Sexta = 32,
            Sabado = 64
        }

        public IReadOnlyCollection<DayOfWeek> DiasSemana { get; }

        public static Repeticao MontarRepeticao(int valor)
        {
            var diasSemana = Enum.GetValues<DiaSemana>()
                .Where(d => ((DiaSemana)valor).HasFlag(d))
                .Select(d => d switch
                {
                    DiaSemana.Domingo => DayOfWeek.Sunday,
                    DiaSemana.Segunda => DayOfWeek.Monday,
                    DiaSemana.Terca => DayOfWeek.Tuesday,
                    DiaSemana.Quarta => DayOfWeek.Wednesday,
                    DiaSemana.Quinta => DayOfWeek.Thursday,
                    DiaSemana.Sexta => DayOfWeek.Friday,
                    DiaSemana.Sabado => DayOfWeek.Saturday,
                    _ => throw new NotImplementedException()
                })
                .ToArray();

            return new Repeticao(diasSemana);
        }

        public int RetornarValor()
        {
            return DiasSemana
                .Distinct()
                .Aggregate(0, (valor, dia) => valor + (int)Math.Pow(2, (double)dia));
        }
    }
}
