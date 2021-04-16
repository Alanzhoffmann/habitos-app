using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rotinas.Domain.Interfaces;
using Rotinas.Domain.Interfaces.Repositories;
using Rotinas.Infra.Data.Repositories;

namespace Rotinas.Infra.Data
{
    public static class Container
    {
        public static IRotinasAppBuilder AddRotinasDbContext(this IRotinasAppBuilder builder, Action<DbContextOptionsBuilder> options)
        {
            AddDbContext(builder.Services, options);

            return builder;
        }

        private static void AddDbContext(IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            var contextScope = ServiceLifetime.Scoped;

            services.AddDbContext<RotinasContext>(options, contextScope);
            services.Add(ServiceDescriptor.Describe(typeof(DbContext), provider => provider.GetRequiredService<RotinasContext>(), contextScope));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
        }
    }
}
