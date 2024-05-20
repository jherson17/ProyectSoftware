using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Core;
using Microsoft.EntityFrameworkCore;

namespace ProyectSoftware.Web.Services
{

    public interface IGenderTypesService
    {
        public Task<Response<List<GenderType>>> GetListAsyc();
    }


    // Implementación del servicio de Sections.
    public class GenderTypeServices : IGenderTypesService
    {
        private readonly DataContext _context; // Campo privado para el contexto de datos.

        // Constructor que inyecta el contexto de datos.
        public GenderTypeServices(DataContext context)
        {
            _context = context;
        }

        // Implementación del método para obtener la lista de Sections de manera asíncrona.
        public async Task<Response<List<GenderType>>> GetListAsyc()
        {
            try
            {
                // Obtiene la lista de autores de la base de datos de manera asíncrona.
                List<GenderType> list = await _context.GenderTypes.ToListAsync();

                // Crea una respuesta exitosa con la lista obtenida.
                Response<List<GenderType>> response = new Response<List<GenderType>>
                {
                    IsSuccess = true,
                    Message = "Lista Obtenida",
                    Result = list
                };

                return response;
            }
            catch (Exception ex)
            {
                // En caso de excepción, crea una respuesta de error con el mensaje de la excepción.
                return new Response<List<GenderType>>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
