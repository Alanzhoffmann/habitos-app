using System;

namespace Rotinas.Domain.Entidades
{
    public class Atividade : BaseEntidade
    {
        public Atividade(string titulo, DateTime dataHora, string? descricao = null)
        {
            Titulo = titulo;
            DataHora = dataHora;
            Descricao = descricao;
        }

        private Atividade() { }

        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHora { get; set; }
    }
}
