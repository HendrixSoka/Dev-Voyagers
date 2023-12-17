using NuGet.DependencyResolver;
using System.ComponentModel.DataAnnotations;

namespace SOMOSDASWEBAPP.Models
{
    public class Inscripcion
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int NroRecibo { get; set; }
        [Required]
        public decimal Costo { get; set; }

        //Relaciones

        public int UsuarioId {get ; set;}
        public virtual Usuario? Usuario { get; set; }
        public int EstudianteId { get; set; }
        public virtual Estudiante? Estudiante { get; set; }
        public int CursoId { get; set; }
        public virtual Curso? Curso { get; set; }
    }
}
