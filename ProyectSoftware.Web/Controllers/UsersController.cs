using Microsoft.AspNetCore.Mvc;
using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Services;
using ProyectSoftware.Web.Core;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace ProyectSoftware.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataContext _context;
        private readonly IUsersService _UserService;
        private readonly INotyfService _notify;

        public UsersController(DataContext context, IUsersService UserService, INotyfService notify)
        {
            _context = context;
            _UserService = UserService; // Asigna el servicio de autores recibido al campo privado.
            _notify = notify;
        }
        [HttpGet]
        // Acción para mostrar la lista de autores.
        //click derecho - añador vista (debe tener el mismo nombre)
        public async Task<IActionResult> Index()
        {
            // Obtiene la lista de autores de forma asincrónica desde el servicio de autores.
            
            Response<List<User>> response = await _UserService.GetListAsyc();

            // Devuelve una vista pasando la lista de autores como modelo.
            return View(response.Result);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
