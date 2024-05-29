using Microsoft.AspNetCore.Mvc;
using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Services;
using ProyectSoftware.Web.Core;
using AspNetCoreHero.ToastNotification.Abstractions;
using ProyectSoftware.Web.Core.Atributes;


namespace ProyectSoftware.Web.Controllers
{
    public class RolesController : Controller
    {
        private IRolesService _rolesService;
        private readonly INotyfService _notify;

        public RolesController(IRolesService rolesService, INotyfService noty)
        {
            _rolesService = rolesService;
            _notify = noty;
        }
        [HttpGet]
        // Acción para mostrar la lista de autores.
        //click derecho - añador vista (debe tener el mismo nombre)
        [CustomAuthorizeAtributte(permission: "showRoles", module: "Roles")]
        public async Task<IActionResult> Index()
        {
            // Obtiene la lista de autores de forma asincrónica desde el servicio de autores.

            Response<List<ProyectSoftwareRole>> response = await _rolesService.GetListAsync();

            // Devuelve una vista pasando la lista de autores como modelo.
            return View(response.Result);
        }
       
    }
}
