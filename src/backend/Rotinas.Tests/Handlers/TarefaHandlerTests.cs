using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rotinas.Domain;
using Rotinas.Domain.DTO;
using Rotinas.Domain.Handlers;
using Rotinas.Infra.Data;
using Xunit;

namespace Rotinas.Tests.Handlers
{
    public class TarefaHandlerTests
    {
        private readonly IHost _hostBuilder;

        public TarefaHandlerTests()
        {
            _hostBuilder = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(config =>
                {

                })
                .ConfigureServices((ctx, services) =>
                {
                    services.AddRotinasApp()
                        .AddRotinasDbContext(options =>
                        {
                            options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                        });
                })
                .ConfigureLogging((ctx, logConfig) =>
                {
                    logConfig.AddConsole();
                    logConfig.AddDebug();
                }).Build();

            //Task.Run(() => _hostBuilder.RunAsync());
        }

        [Fact]
        public async Task BuscarListaTarefa_DeveRetornar_ListaTarefaViewModelAsync()
        {
            // arrange
            var handler = _hostBuilder.Services.GetRequiredService<ISender>();
            var command = new BuscarListaTarefasCommand();

            // act
            await handler.Send(new SalvarTarefaCommand
            {
                Nome = "teste",
                DuracaoMinutos = 50,
                Repetir = true,
                Domingo = true,
                Quinta = true,
                InicioIntervalo = 300,
                FimIntervalo = 1200
            });

            var lista = await handler.Send(command);

            // assert
        }
    }
}
