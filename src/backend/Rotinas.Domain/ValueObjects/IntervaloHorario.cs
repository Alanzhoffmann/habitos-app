using System;

namespace Rotinas.Domain.ValueObjects
{
    public record IntervaloHorario
    {
        public IntervaloHorario(TimeSpan inicio, TimeSpan fim)
        {
            Inicio = inicio;
            Fim = fim;
        }

        public TimeSpan Inicio { get; }
        public TimeSpan Fim { get; }
    }
}
