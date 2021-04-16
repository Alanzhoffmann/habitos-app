using System;
using System.Collections.Generic;

namespace Rotinas.Domain.DTO
{
    public class ListaTarefaViewModel
    {
        public ListaTarefaViewModel(IReadOnlyCollection<TarefaViewModel> tarefas)
        {
            Tarefas = tarefas;
        }

        public IReadOnlyCollection<TarefaViewModel> Tarefas { get; init; } = Array.Empty<TarefaViewModel>();
    }
}
