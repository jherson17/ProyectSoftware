using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Core;
using Microsoft.EntityFrameworkCore;

namespace ProyectSoftware.Web.Services
{


    public interface IUsersServices
    {
        Task<Response<User>> CreateAsync(User model);
        
        public Task<Response<List<User>>> GetListAsync();
    }


    // Implementación del servicio de Sections.
    public class UserServices : IUsersServices
    {
        private readonly DataContext _context; // Campo privado para el contexto de datos.

        // Constructor que inyecta el contexto de datos.
        public UserServices(DataContext context)
        {
            _context = context;
        }

        public async Task<Response<User>> CreateAsync(User model)
        {
            try
            {
                User user = new User()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    Edad = model.Edad,
                };
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();

                return new Response<User>
                {
                    IsSuccess = true,
                    Message = "User created",
                    Result = user
                };
            }
            catch (Exception ex)
            {

                return new Response<User>
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
