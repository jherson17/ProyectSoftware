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
        [HttpGet]
        
        [HttpPost]
        public async Task<IActionResult> Create(Author model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Si hay errores de validación, vuelve a cargar la vista de creación con los datos y mensajes de error.
                    _notify.Error("Bebe ajustar los errores de validacion");
                    return View(model);
                }//esta sucediendo un error aqui y no se porque

                Response<Author> Response = await _AuthorService.CreateAsync(model);

                if (Response.IsSuccess)
                {
                    _notify.Success(Response.Message);
                    return RedirectToAction(nameof(Index));

                }

                _notify.Error(Response.Message);
                return View(model);
            }
            catch (Exception ex)
            {
                _notify.Error(ex.Message);
            }
            return View();
        }
    }
}
