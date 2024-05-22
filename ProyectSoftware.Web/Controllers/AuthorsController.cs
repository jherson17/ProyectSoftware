using Microsoft.AspNetCore.Mvc;
using ProyectSoftware.Web.Core;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Services;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace ProyectSoftware.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly DataContext _context;
        private readonly IAuthorsService _AuthorService;
        private readonly INotyfService _notify;

        public AuthorsController(DataContext context, IAuthorsService AuthorService, INotyfService notify)
        {
            _context = context;
            _AuthorService = AuthorService; // Asigna el servicio de autores recibido al campo privado.
            _notify = notify;
        }
        [HttpGet]
        // Acción para mostrar la lista de autores.
        //click derecho - añador vista (debe tener el mismo nombre)
        public async Task<IActionResult> Index()
        {
            _notify.Success("Authors");
            // Obtiene la lista de autores de forma asincrónica desde el servicio de autores.

            Response<List<Author>> response = await _AuthorService.GetListAsyc();

            // Devuelve una vista pasando la lista de autores como modelo.
            return View(response.Result);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
