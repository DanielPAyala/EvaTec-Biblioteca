using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string NumeroDocumento { get; set; } = null!;

    public string? Telefono { get; set; }

    public string Email { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Ubigeo { get; set; }

    public string Contrasena { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<Auditorium> Auditoria { get; set; } = new List<Auditorium>();

    public virtual ICollection<CodigoOtp> CodigoOtps { get; set; } = new List<CodigoOtp>();

    public virtual ListaNegra? ListaNegra { get; set; }

    public virtual ICollection<Notificacion> Notificacions { get; set; } = new List<Notificacion>();

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
