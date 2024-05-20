using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Core;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Data.Entities;
using static System.Collections.Specialized.BitVector32;

namespace ProyectSoftware.Web.Services
{
    
        public interface IAuthorsService
        {
            public Task<Response<List<Author>>> GetListAsyc();
        }


        // Implementación del servicio de Sections.
        public class AuthorServices : IAuthorsService
        {
            private readonly DataContext _context; // Campo privado para el contexto de datos.

            // Constructor que inyecta el contexto de datos.
            public AuthorServices(DataContext context)
            {
                _context = context;
            }

            // Implementación del método para obtener la lista de Sections de manera asíncrona.
            public async Task<Response<List<Author>>> GetListAsyc()
            {
                try
                {
                    // Obtiene la lista de autores de la base de datos de manera asíncrona.
                    List<Author> list = await _context.Authors.ToListAsync();

                    // Crea una respuesta exitosa con la lista obtenida.
                    Response<List<Author>> response = new Response<List<Author>>
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
                    return new Response<List<Author>>
                    {
                        IsSuccess = false,
                        Message = ex.Message
                    };
                }
            }
        }
   }

