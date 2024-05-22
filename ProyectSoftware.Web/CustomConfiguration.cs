using AspNetCoreHero.ToastNotification;
using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Data;
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

            //helpers
        }

    }
}
