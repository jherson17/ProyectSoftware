using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectSoftware.Web.Data.Entities;
using ProyectSoftware.Web.DTOs;
using ProyectSoftware.Web.Helpers;
using ProyectSoftware.Web.Services;

namespace ProyectSoftware.Web.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IConverterHelper _converterHelper;
        private readonly INotyfService _noty;
        private readonly IUsersService _usersService;
        private readonly IConverterHelper _converterHelper;

        public AccountController(IUsersService usersService, INotyfService noty , IConverterHelper converterHelper)
        {
            _usersService = usersService;
            _noty = noty;
          
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _usersService.LoginAsync(dto);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Dashboard", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos");
                _noty.Error("Email o contraseña incorrectos");
            }

            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _usersService.LogoutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult NotAuthorized()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser()
        {
            User? user = await _usersService.GetUserAsync(User.Identity.Name);

            if (user is null)
            {
                return NotFound();
            }

            AccountUserDTO dto = _converterHelper.ToAccountDTO(user);

            return View(dto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateUser(AccountUserDTO dto)
        {
            if (ModelState.IsValid)
            {
                User user = await _usersService.GetUserAsync(User.Identity.Name);

                user.Document = dto.Document;
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.PhoneNumber = dto.PhoneNumber;

                await _usersService.UpdateUserAsync(user);

                _noty.Success("Usuario editado con éxito");

                return RedirectToAction("Dashboard", "Home");
            }

            _noty.Error("Debe ajustar los errores de validación.");
            return View(dto);
        }
    }
}
