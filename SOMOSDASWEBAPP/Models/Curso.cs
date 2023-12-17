using SOMOSDASWEBAPP.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
       // public string? Foto { get; set; } //almacenar la foto

        //Solo de ayuda para cargar la foto
        [NotMapped]
        [Display(Name = "Cargar Foto")]
        public IFormFile? FotoFile { get; set; } //cargar la foto de la UI
    }
}
