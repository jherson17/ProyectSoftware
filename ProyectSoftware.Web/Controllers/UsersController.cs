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
        private readonly IUsersServices _UserService;
        private readonly INotyfService _notify;

        public UsersController(DataContext context, IUsersServices UserService, INotyfService notify)
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
            
            Response<List<User>> response = await _UserService.GetListAsync();

            // Devuelve una vista pasando la lista de autores como modelo.
            return View(response.Result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Si hay errores de validación, vuelve a cargar la vista de creación con los datos y mensajes de error.
                    _notify.Error("Bebe ajustar los errores de validacion");
                    return View(model);
                }//esta sucediendo un error aqui y no se porque

                Response<User> Response = await _UserService.CreateAsync(model);

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
        [HttpGet("edit/{Name}")]
        public async Task<IActionResult> Edit([FromRoute] string Name)
        {
            Response<User> response = await _UserService.GetOneAsync(Name);

            if (response.IsSuccess)
            {
                return View(response.Result);
            }

            _notify.Error(response.Errors.First());
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(User model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _notify.Error("Debe ajustar los errores de validación.");
                    return View(model);
                }

                Response<User> response = await _UserService.EditAsync(model);

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

        [HttpPost("elete/{Name}")]
        public async Task<IActionResult> Delete([FromRoute] string Name)
        {
            Response<User> response = await _UserService.DeleteAsync(Name);

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
