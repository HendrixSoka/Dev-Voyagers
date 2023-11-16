using SOMOSDASWEBAPP.Dtos;

namespace SOMOSDASWEBAPP.Models
{
    public class Curso
    {
        public int CodCurso { get; set; }
        public string? Duracion  { get; set; }
        public string? Tema { get; set; }
        public string? Docente { get; set; }
        public TipoCursoEnum Tipo{ get; set; }
    }
}
