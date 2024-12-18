using Autofac;
using Autofac.Extensions.DependencyInjection;
using EFCoreCodeFirstTogether_START.Infrastructure.DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreCodeFirstTogether_START
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapa och konfigurera host
            var host = Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) // Använd Autofac som DI-motor
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    // Ladda registreringar från DependencyRegistrar
                    builder.RegisterModule<DependencyRegistrar>();
                })
                .Build();

            // Skapa ett DI-scope och hämta huvudapplikationen
            using (var scope = host.Services.CreateScope())
            {
                var app = scope.ServiceProvider.GetRequiredService<Application>();
                app.Run();
            }
        }
    }
}
