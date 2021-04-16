namespace Rotinas.Domain.DTO
{
    public class TarefaViewModel
    {
        public TarefaViewModel(string id, RepeticaoViewModel repeticao, IntervaloViewModel intervalo)
        {
            Id = id;
            Repeticao = repeticao;
            Intervalo = intervalo;
        }

        public string Id { get; }
        public RepeticaoViewModel Repeticao { get; }
        public IntervaloViewModel Intervalo { get; }
    }
}
