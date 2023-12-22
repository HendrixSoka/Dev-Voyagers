using Microsoft.EntityFrameworkCore;
using SOMOSDASWEBAPP.Models;

namespace SOMOSDASWEBAPP.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<SOMOSDASWEBAPP.Models.Inscripcion>? Inscripcion { get; set; }
    }
}
