using Autofac;
using EFCoreCodeFirstTogether_START.Controllers;
using EFCoreCodeFirstTogether_START.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstTogether_START.Infrastructure.DI
{
    public class DependencyRegistrar : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Registrera ApplicationDbContext
            builder.Register(context =>
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>();
                options.UseSqlServer("Server=.;Database=Invoice12345;Trusted_Connection=True;TrustServerCertificate=true;");
                return new ApplicationDbContext(options.Options);
            }).As<ApplicationDbContext>().InstancePerLifetimeScope();

            // Controllers
            builder.RegisterType<Build>().AsSelf();
            builder.RegisterType<Application>().AsSelf();
            builder.RegisterType<MainMenu>().AsSelf();
            builder.RegisterType<Create>().AsSelf();
            builder.RegisterType<Read>().AsSelf();
            builder.RegisterType<Update>().AsSelf();
            builder.RegisterType<Delete>().AsSelf();

            //Data
            builder.RegisterType<ApplicationDbContext>().AsSelf();
            builder.RegisterType<County>().AsSelf();
            builder.RegisterType<DataInitializer>().AsSelf();
            builder.RegisterType<Invoice>().AsSelf();
            builder.RegisterType<Person>().AsSelf();
        }
    }
}
