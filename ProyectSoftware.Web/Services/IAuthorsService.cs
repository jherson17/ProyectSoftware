using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Core;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Helpers;
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
                    return ResponseHelper<List<Author>>.MakeResponseSuccess(list, "Author created");
            }
                catch (Exception ex)
                {
                // En caso de excepción, crea una respuesta de error con el mensaje de la excepción.
                return ResponseHelper<List<Author>>.MakeResponseSuccess(ex.Message);
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

                return ResponseHelper<Author>.MakeResponseSuccess(author, "Gender name created");
            }
            catch (Exception ex)
            {

                return ResponseHelper<Author>.MakeResponseSuccess(ex.Message);
            }
        }

        // Implementación del método para obtener la lista de Sections de manera asíncrona.
        public async Task<Response<List<Author>>> GetListAsync()
        {
            try
            {
                // Obtiene la lista de autores de la base de datos de manera asíncrona.
                List<Author> list = await _context.Authors.ToListAsync();

                // Crea una respuesta exitosa con la lista obtenida.
                return ResponseHelper<List<Author>>.MakeResponseSuccess(list, "Author created");
            }
            catch (Exception ex)
            {
                // En caso de excepción, crea una respuesta de error con el mensaje de la excepción.
                return ResponseHelper<List<Author>>.MakeResponseSuccess(ex.Message);
            }
        }

    }
}

