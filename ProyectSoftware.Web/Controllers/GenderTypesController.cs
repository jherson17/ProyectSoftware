﻿using Microsoft.AspNetCore.Mvc;
using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.Data;
using ProyectSoftware.Web.Services;
using ProyectSoftware.Web.Core;

namespace ProyectSoftware.Web.Controllers
{
    public class GenderTypesController : Controller
    {
        private readonly DataContext _context;
        private readonly IGenderTypesService _GenderTypeService;

        public GenderTypesController(DataContext context, IGenderTypesService GenderTypeService/*, /*INotyfService notifyService*/)
        {
            _context = context;
            _GenderTypeService = GenderTypeService; // Asigna el servicio de autores recibido al campo privado.

        }
        [HttpGet]
        // Acción para mostrar la lista de autores.
        //click derecho - añador vista (debe tener el mismo nombre)
        public async Task<IActionResult> Index()
        {
            // Obtiene la lista de autores de forma asincrónica desde el servicio de autores.

            Response<List<GenderType>> response = await _GenderTypeService.GetListAsyc();

            // Devuelve una vista pasando la lista de autores como modelo.
            return View(response.Result);
        }
    }
}
