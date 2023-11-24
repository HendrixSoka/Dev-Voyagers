using System.ComponentModel.DataAnnotations;

namespace SOMOSDASWEBAPP.Models
{
    public class Estudiante
    {
        [Key]
        public int CedulaIdentidad { get; set; }
        [Required]
        public string? NombreCompleto { get; set; }
        public int Celular { get; set; }
        public string? CorreoElectronico { get; set; }
    }
}
