using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Core;
using Microsoft.EntityFrameworkCore;

namespace ProyectSoftware.Web.Services
{

    public interface IGenderTypesService
    {
        Task<Response<GenderType>> CreateAsync(GenderType model);
        public Task<Response<List<GenderType>>> GetListAsync();
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

        public async Task<Response<GenderType>> CreateAsync(GenderType model)
        {
            try
            {
                GenderType genderType = new GenderType()
                {
                    GenderName = model.GenderName,
                };
                await _context.AddAsync(genderType);
                await _context.SaveChangesAsync();

                return new Response<GenderType>
                {
                    IsSuccess = true,
                    Message = "Gender type created",
                    Result = genderType
                };
            }catch(Exception ex){

                return new Response<GenderType>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        // Implementación del método para obtener la lista de Sections de manera asíncrona.
        public async Task<Response<List<GenderType>>> GetListAsync()
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
