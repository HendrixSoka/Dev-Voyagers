namespace SOMOSDASWEBAPP.Models
{
    public class Estudiante
    {
        public int CedulaIdentidad { get; set; }
        public string? NombreCompleto { get; set; }
        public int Celular { get; set; }
        ///Opcional se podria enviar ofertas de cursos a su correo a los estudiantes que estan en la base de datos
        public string? CorreoElectronico { get; set; }
    }
}
