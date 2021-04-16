using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rotinas.Domain.DTO;
using Rotinas.Domain.Entidades;
using Rotinas.Domain.Interfaces;
using Rotinas.Domain.Interfaces.Repositories;
using Rotinas.Domain.ValueObjects;

namespace Rotinas.Domain.Handlers
{
    public class TarefaHandler :
        IRequestHandler<SalvarTarefaCommand, Unit>,
        IRequestHandler<BuscarListaTarefasCommand, ListaTarefaViewModel>
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TarefaHandler(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWork)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SalvarTarefaCommand request, CancellationToken cancellationToken)
        {
            Repeticao? repeticao = null;
            if (request.Repetir)
            {
                var dicionarioDias = new Dictionary<DayOfWeek, bool>()
                {
                    [DayOfWeek.Sunday] = request.Domingo,
                    [DayOfWeek.Monday] = request.Segunda,
                    [DayOfWeek.Tuesday] = request.Terca,
                    [DayOfWeek.Wednesday] = request.Quarta,
                    [DayOfWeek.Thursday] = request.Quinta,
                    [DayOfWeek.Friday] = request.Sexta,
                    [DayOfWeek.Saturday] = request.Sabado
                };

                repeticao = new(dicionarioDias.Where(p => p.Value).Select(p => p.Key).ToArray());
            }

            IntervaloHorario? intervalo = null;
            if (request.InicioIntervalo.HasValue && request.FimIntervalo.HasValue)
            {
                intervalo = new(TimeSpan.FromMinutes(request.InicioIntervalo.Value), TimeSpan.FromMinutes(request.FimIntervalo.Value));
            }

            var tarefa = new Tarefa(request.Nome, TimeSpan.FromMinutes(request.DuracaoMinutos), repeticao, intervalo);
            _tarefaRepository.Adicionar(tarefa);

            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<ListaTarefaViewModel> Handle(BuscarListaTarefasCommand request, CancellationToken cancellationToken)
        {
            var tarefas = await _tarefaRepository.Buscar(request, cancellationToken);
            return new ListaTarefaViewModel(tarefas);
        }
    }
}
