using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Core;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Data.Entities;
using static System.Collections.Specialized.BitVector32;

namespace ProyectSoftware.Web.Services
{
    
        public interface IAuthorsService
        {
        Task<Response<Author>> CreateAsync(Author model);
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
        public async Task<Response<Author>> CreateAsync(Author model)
        {
            try
            {
                Author author = new Author()
                {
                    Name = model.Name,
                    StageName = model.StageName,
                    LastName = model.LastName,
                };
                await _context.AddAsync(author);
                await _context.SaveChangesAsync();

                return new Response<Author>
                {
                    IsSuccess = true,
                    Message = "User created",
                    Result = author
                };
            }
            catch (Exception ex)
            {

                return new Response<Author>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        // Implementación del método para obtener la lista de Sections de manera asíncrona.
        public async Task<Response<List<User>>> GetListAsync()
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

