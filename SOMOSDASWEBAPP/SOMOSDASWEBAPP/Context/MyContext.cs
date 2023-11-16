using Microsoft.EntityFrameworkCore;
using SOMOSDASWEBAPP.Models;

namespace SOMOSDASWEBAPP.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
    }
}
