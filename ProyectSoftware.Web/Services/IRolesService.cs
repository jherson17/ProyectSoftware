using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Core;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ProyectSoftware.Web.Services
{
    public interface IRolesService
    {
        //public Task<Response<PrivateBlogRole>> CreateAsync(PrivateBlogRoleDTO dto);

        //public Task<Response<PrivateBlogRole>> EditAsync(PrivateBlogRoleDTO dto);

        //public Task<Response<PaginationResponse<ProyectSoftwareRole>>> GetListAsync(PaginationRequest request);

        //public Task<Response<PrivateBlogRoleDTO>> GetOneAsync(int id);
        public Task<Response<List<ProyectSoftwareRole>>> GetListAsync();

        //public Task<Response<IEnumerable<Permission>>> GetPermissionsAsync();

        //public Task<Response<IEnumerable<PermissionForDTO>>> GetPermissionsByRoleAsync(int id);
    }
    public class RolesService : IRolesService
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public RolesService(DataContext context, IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

    

        public async Task<Response<List<ProyectSoftwareRole>>> GetListAsync()
        {
            try
            {
                // Obtiene la lista de autores de la base de datos de manera asíncrona.
                List<ProyectSoftwareRole> list = await _context.ProyectSoftwareRoles.ToListAsync();

                // Crea una respuesta exitosa con la lista obtenida.
                return ResponseHelper<List<ProyectSoftwareRole>>.MakeResponseSuccess(list, "ProyectSoftwareRole Create created");
            }
            catch (Exception ex)
            {
                // En caso de excepción, crea una respuesta de error con el mensaje de la excepción.
                return ResponseHelper<List<ProyectSoftwareRole>>.MakeResponseSuccess(ex.Message);
            }
        }
    }
}
