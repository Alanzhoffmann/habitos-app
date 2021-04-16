using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rotinas.Domain.Interfaces;

namespace Rotinas.Domain
{
    public static class Container
    {
        public static IRotinasAppBuilder AddRotinasApp(this IServiceCollection services)
        {
            // Adicionar os serviços a serem implementados
            services.AddMediatR(typeof(Container).Assembly);

            return new RotinasAppBuilder(services);
        }
    }

    public class RotinasAppBuilder : IRotinasAppBuilder
    {
        public RotinasAppBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
