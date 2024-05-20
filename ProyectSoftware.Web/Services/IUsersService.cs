using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Core;
using Microsoft.EntityFrameworkCore;

namespace ProyectSoftware.Web.Services
{
   

        public interface IUsersService
        {
            public Task<Response<List<User>>> GetListAsyc();
        }


        // Implementación del servicio de Sections.
        public class UserServices : IUsersService
        {
            private readonly DataContext _context; // Campo privado para el contexto de datos.

            // Constructor que inyecta el contexto de datos.
            public UserServices(DataContext context)
            {
                _context = context;
            }

            // Implementación del método para obtener la lista de Sections de manera asíncrona.
            public async Task<Response<List<User>>> GetListAsyc()
            {
                try
                {
                    // Obtiene la lista de autores de la base de datos de manera asíncrona.
                    List<User> list = await _context.Users.ToListAsync();

                    // Crea una respuesta exitosa con la lista obtenida.
                    Response<List<User>> response = new Response<List<User>>
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
                    return new Response<List<User>>
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    };
                }
            }
        }
    }

