using SOMOSDASWEBAPP.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SOMOSDASWEBAPP.Models
{
    public class Curso
    {
        [Key]
        public int CodCurso { get; set; }
        [Required]
        public string? Duracion  { get; set; }
        [Required]
        public string? Tema { get; set; }
        [Required]
        public string? Docente { get; set; }
        [Required]
        public int CuposCurso { get; set; }
        [Required]
        public TipoCursoEnum Tipo{ get; set; }
    }
}
