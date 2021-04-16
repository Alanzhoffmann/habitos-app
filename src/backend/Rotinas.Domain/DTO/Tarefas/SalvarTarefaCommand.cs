using System.Dynamic;
using MediatR;

namespace Rotinas.Domain.DTO
{
    public class SalvarTarefaCommand : IRequest
    {
        public int DuracaoMinutos { get; set; }
        public string? Nome { get; set; }
        public bool Repetir { get; set; }
        public bool Domingo { get; set; }
        public bool Segunda { get; set; }
        public bool Terca { get; set; }
        public bool Quarta { get; set; }
        public bool Quinta { get; set; }
        public bool Sexta { get; set; }
        public bool Sabado { get; set; }

        public int? InicioIntervalo { get; set; }
        public int? FimIntervalo { get; set; }
    }
}
