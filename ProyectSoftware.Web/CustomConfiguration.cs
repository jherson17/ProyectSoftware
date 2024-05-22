using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Data.Seeders;
using ProyectSoftware.Web.Services;

namespace ProyectSoftware.Web
{
    public static class CustomConfiguration
    {
        public static WebApplicationBuilder AddCustomBuilderConfiguration(this WebApplicationBuilder builder)
        {

            // Data Context
            builder.Services.AddDbContext<DataContext>(conf =>
            {
                conf.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));// Configura Entity Framework Core para usar SQL Server como proveedor de base de datos y obtiene la cadena de conexión desde la configuración de la aplicación.
            });
            AddServices(builder);
            

            builder.Services.AddNotyf(config =>
            {
                config.DurationInSeconds = 10; // Configura la duración de las notificaciones a 10 segundos.
                config.IsDismissable = true; // Permite que las notificaciones sean descartables por el usuario.
                config.Position = NotyfPosition.BottomRight; // Configura la posición de las notificaciones en la esquina inferior derecha.
            });

            return builder;
        }
        private static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthorsService, AuthorServices>();
            builder.Services.AddScoped<IUsersServices, UserServices>();
            builder.Services.AddScoped<IGenderTypesService, GenderTypeServices>();
            builder.Services.AddTransient<SeedDb>();
            //helpers
        }

        public static WebApplication AddCustomConfiguration(this WebApplication app)
        {
            app.UseNotyf();

            SeedData(app);

            return app;
        }


        private static void SeedData(WebApplication app)
        {
            IServiceScopeFactory scopedFactory = app.Services.GetService<IServiceScopeFactory>();

            using (IServiceScope scope = scopedFactory!.CreateScope())
            {
                SeedDb service = scope.ServiceProvider.GetService<SeedDb>();
                service!.SeedAsync().Wait();
            }
        }
    }
}
