using System;

namespace Rotinas.Domain.Entidades
{
    public class BaseEntidade
    {
        public Guid Id { get; }
        public DateTime CriadoEm { get; } = DateTime.Now;
        public DateTime AtualizadoEm { get; } = DateTime.Now;
    }
}
