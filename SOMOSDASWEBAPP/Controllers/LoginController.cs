using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOMOSDASWEBAPP.Context;
using SOMOSDASWEBAPP.Models;

namespace SOMOSDASWEBAPP.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyContext _context;
        public LoginController(MyContext miContext)
        {
            _context = miContext;
        }

        //GET
        public IActionResult Index()
        {
            //para que muestre la pantalla del login
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string correo, string contrasena)
        {
            var usuario = await _context.Usuario
                            .Where(x => x.Email == correo && x.Password == contrasena)
                            .FirstOrDefaultAsync();

            if (usuario != null) //se ha encontrado al usuario
            {
                await SetAuthenticationInCookie(usuario);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Cuenta o Password incorrectos";
                return Redirect("Index");
            }
        }
        private async Task SetAuthenticationInCookie(Usuario? user)
        {
            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.NombreCompleto!),
                    new Claim("Email", user.Email!),
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Rol!.ToString()),
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }

    }
}
