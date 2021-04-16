using Microsoft.Extensions.DependencyInjection;

namespace Rotinas.Domain.Interfaces
{
    public interface IRotinasAppBuilder
    {
        IServiceCollection Services { get; }
    }
}
