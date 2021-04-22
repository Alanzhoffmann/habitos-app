using Rotinas.Domain.ValueObjects;

namespace Rotinas.Domain.DTO
{
    public class IntervaloViewModel
    {
        public int Inicio { get; private set; }
        public int Fim { get; private set; }

        public static explicit operator IntervaloViewModel?(IntervaloHorario? intervalo)
        {
            if (intervalo is null)
            {
                return null;
            }

            return new IntervaloViewModel
            {
                Inicio = (int)intervalo.Inicio.TotalMinutes,
                Fim = (int)intervalo.Fim.TotalMinutes,
            };
        }
    }
}