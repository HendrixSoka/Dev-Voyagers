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
    public class InscripcionsController : Controller
    {
        private readonly MyContext _context;

        public InscripcionsController(MyContext context)
        {
            _context = context;
        }

        // GET: Inscripcions
        public async Task<IActionResult> Index()
        {
            var myContext = _context.Inscripcion.Include(i => i.Curso).Include(i => i.Estudiante).Include(i => i.Usuario);
            return View(await myContext.ToListAsync());
        }

        // GET: Inscripcions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inscripcion == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion
                .Include(i => i.Curso)
                .Include(i => i.Estudiante)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // GET: Inscripcions/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Curso, "CodCurso", "Docente");
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "CedulaIdentidad", "NombreCompleto");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email");
            return View();
        }

        // POST: Inscripcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,NroRecibo,Costo,UsuarioId,EstudianteId,CursoId")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                var curso = await _context.Curso.FindAsync(inscripcion.CursoId);

                if (curso.CuposCurso > 0)
                {
                    inscripcion.Fecha = DateTime.Now;
                    inscripcion.UsuarioId = int.Parse(User.Claims.ToList()[2].Value);

                    _context.Add(inscripcion);
                    curso.CuposCurso = curso.CuposCurso - 1;
                    _context.Update(curso);

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Details", "Inscripciones", new { id = inscripcion.Id });
                }
                else
                {
                    ModelState.AddModelError("", "No hay cupos disponibles para este curso.");
                }
            }

            // Si el modelo no es válido o no hay cupos disponibles, vuelve a mostrar la vista de inscripción
            ViewData["CursoId"] = new SelectList(_context.Curso, "CodCurso", "Docente", inscripcion.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "CedulaIdentidad", "NombreCompleto", inscripcion.EstudianteId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", inscripcion.UsuarioId);
            return View(inscripcion);

        }

        // GET: Inscripcions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inscripcion == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion.FindAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "CodCurso", "Docente", inscripcion.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "CedulaIdentidad", "NombreCompleto", inscripcion.EstudianteId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", inscripcion.UsuarioId);
            return View(inscripcion);
        }

        // POST: Inscripcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,NroRecibo,Costo,UsuarioId,EstudianteId,CursoId")] Inscripcion inscripcion)
        {
            if (id != inscripcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscripcionExists(inscripcion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Curso, "CodCurso", "Docente", inscripcion.CursoId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiante, "CedulaIdentidad", "NombreCompleto", inscripcion.EstudianteId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", inscripcion.UsuarioId);
            return View(inscripcion);
        }

        // GET: Inscripcions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inscripcion == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion
                .Include(i => i.Curso)
                .Include(i => i.Estudiante)
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // POST: Inscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inscripcion == null)
            {
                return Problem("Entity set 'MyContext.Inscripcion'  is null.");
            }
            var inscripcion = await _context.Inscripcion.FindAsync(id);
            if (inscripcion != null)
            {
                _context.Inscripcion.Remove(inscripcion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscripcionExists(int id)
        {
          return (_context.Inscripcion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
