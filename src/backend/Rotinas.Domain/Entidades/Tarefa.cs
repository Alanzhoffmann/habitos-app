using System;
using Rotinas.Domain.ValueObjects;

namespace Rotinas.Domain.Entidades
{
    public class Tarefa : BaseEntidade
    {
        public Tarefa(string nome, TimeSpan duracao, Repeticao? repeticao = null, IntervaloHorario? intervaloPossivel = null)
        {
            Nome = nome;
            Duracao = duracao;
            Repeticao = repeticao;
            IntervaloPossivel = intervaloPossivel;
        }

        private Tarefa()
        {
        }

        public string Nome { get; }
        public TimeSpan Duracao { get; }
        public Repeticao? Repeticao { get; }
        public IntervaloHorario? IntervaloPossivel { get; }
    }
}
