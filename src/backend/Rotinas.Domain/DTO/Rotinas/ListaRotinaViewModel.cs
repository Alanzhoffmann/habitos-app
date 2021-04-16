using System;
using System.Collections.Generic;

namespace Rotinas.Domain.DTO
{
    public class ListaRotinaViewModel
    {
        public IReadOnlyCollection<RotinaViewModel> Rotinas { get; init; } = Array.Empty<RotinaViewModel>();
    }
}