using Microsoft.AspNetCore.Mvc;
using ProyectSoftware.Web.Core;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Services;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using ProyectSoftware.Web.Core.Atributes;

namespace ProyectSoftware.Web.Controllers
{
    [Authorize]
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
        [CustomAuthorizeAtributte(permission: "showAuthors", module: "Authors")]
        public async Task<IActionResult> Index()
        {
            _notify.Success("Authors");
            // Obtiene la lista de autores de forma asincrónica desde el servicio de autores.

            Response<List<Author>> response = await _AuthorService.GetListAsyc();

            // Devuelve una vista pasando la lista de autores como modelo.
            return View(response.Result);
        }
        [HttpGet]
        [CustomAuthorizeAtributte(permission: "createAuthors", module: "Authors")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [CustomAuthorizeAtributte(permission: "createAuthors", module: "Authors")]
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
        [HttpGet("editstagename/{StageName}")]
        [CustomAuthorizeAtributte(permission: "showAuthors", module: "Authors")]
        public async Task<IActionResult> Edit([FromRoute] string StageName)
        {
            Response<Author> response = await _AuthorService.GetOneAsync(StageName);

            if (response.IsSuccess)
            {
                return View(response.Result);
            }

            _notify.Error(response.Errors.First());
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [CustomAuthorizeAtributte(permission: "updateAuthors", module: "Authors")]
        public async Task<IActionResult> Update(Author model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _notify.Error("Debe ajustar los errores de validación.");
                    return View(model);
                }

                Response<Author> response = await _AuthorService.EditAsync(model);

                if (response.IsSuccess)
                {
                    _notify.Success(response.Message);
                    return RedirectToAction(nameof(Index));
                }

                _notify.Error(response.Errors.First());
                return View(model);
            }
            catch (Exception ex)
            {
                _notify.Error(ex.Message);
                return View(model);
            }
        }

        [HttpPost("deletebystagename/{StageName}")]//Cada httpos me toco cambiar la ruta preguntar al profe porque
        [CustomAuthorizeAtributte(permission: "updateAuthors", module: "Authors")]
        public async Task<IActionResult> Delete([FromRoute] string StageName)
        {
            Response<Author> response = await _AuthorService.DeleteAsync(StageName);

            if (response.IsSuccess)
            {
                _notify.Success(response.Message);
                return RedirectToAction(nameof(Index));
            }

            _notify.Error(response.Errors.First());
            return RedirectToAction(nameof(Index));
        }
    }
}
