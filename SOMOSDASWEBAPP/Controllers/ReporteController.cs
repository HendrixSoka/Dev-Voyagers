using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SOMOSDASWEBAPP.Context;
using SOMOSDASWEBAPP.Models;

namespace SOMOSDASWEBAPP.Controllers
{
    
    public class ReporteController : Controller
    {
        private readonly MyContext _myContext;
        public  ReporteController(MyContext myContext) {
            _myContext = myContext;
        }  
           public IActionResult Index()
        {
            int idUsuario = int.Parse(User.Claims.ToList()[2].Value);
            var usuario = _myContext.Usuario
            .Where(x => x.Id == idUsuario)
            .Include(x => x.Inscripciones)
            .FirstOrDefault();
            return View(usuario);
        }
    }
}
