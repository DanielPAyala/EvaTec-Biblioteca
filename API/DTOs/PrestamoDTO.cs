namespace API.DTOs
{
    public class PrestamoDTO
    {
        public int UsuarioId { get; set; }
        public int LibroId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string Estado { get; set; }
    }
}
