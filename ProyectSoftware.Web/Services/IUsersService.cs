using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Core;
using Microsoft.EntityFrameworkCore;
using ProyectSoftware.Web.Helpers;

namespace ProyectSoftware.Web.Services
{


    public interface IUsersServices
    {
        Task<Response<User>> CreateAsync(User model);
        
        public Task<Response<List<User>>> GetListAsync();

        public Task<Response<User>> GetOneAsync(string name);

        public Task<Response<User>> EditAsync(User model);

        public Task<Response<User>> DeleteAsync(string name);
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

                return ResponseHelper<User>.MakeResponseSuccess(user, "User created");
            }
            catch (Exception ex)
            {

                return ResponseHelper<User>.MakeResponseSuccess(ex.Message);
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
                return ResponseHelper<List<User>>.MakeResponseSuccess(list, "User created");
            }
            catch (Exception ex)
            {
                // En caso de excepción, crea una respuesta de error con el mensaje de la excepción.
                return ResponseHelper<List<User>>.MakeResponseSuccess(ex.Message);
            }
        }
        public async Task<Response<User>> GetOneAsync(string name)
        {
            try
            {
                User? user = await _context.Users.FirstOrDefaultAsync(s => s.Name == name);
                if (user is null)
                {
                    return ResponseHelper<User>.MakeResponseFail($"La sección con id '{name}' no existe.");
                }
                return ResponseHelper<User>.MakeResponseSuccess(user);

            }
            catch (Exception ex)
            {
                return ResponseHelper<User>.MakeResponseFail(ex);
            }


        }

        public async Task<Response<User>> EditAsync(User model)
        {
            try
            {
                _context.Users.Update(model);
                await _context.SaveChangesAsync();

                return ResponseHelper<User>.MakeResponseSuccess(model, "Sección editada con éxito");
            }
            catch (Exception ex)
            {
                return ResponseHelper<User>.MakeResponseFail(ex);
            }
        }

        public async Task<Response<User>> DeleteAsync(string name)
        {
            try
            {
                User? user = await _context.Users.FirstOrDefaultAsync(s => s.Name == name);

                if (user is null)
                {
                    return ResponseHelper<User>.MakeResponseFail($"La sección con name '{name}' no existe.");
                };
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return ResponseHelper<User>.MakeResponseSuccess("Sección eliminada con éxito");

            }
            catch (Exception ex)
            {
                return ResponseHelper<User>.MakeResponseFail(ex);
            }
        }
    }
}
