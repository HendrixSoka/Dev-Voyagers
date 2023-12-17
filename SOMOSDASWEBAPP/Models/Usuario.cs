using SOMOSDASWEBAPP.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SOMOSDASWEBAPP.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        [Required]
        public RolEnum Rol { get; set; }

        ///Relacion 
       
        public virtual List<Inscripcion>? Inscripciones{ get; set; }
    }
}
