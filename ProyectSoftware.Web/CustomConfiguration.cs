using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Services;
using static ProyectSoftware.Web.Services.IAuthorsService;

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

            return builder;
        }
        private static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthorsService, AuthorServices>();
            builder.Services.AddScoped<IUsersService, UserServices>();

            //helpers
        }

    }
}
