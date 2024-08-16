using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Auditorium
{
    public int AuditoriaId { get; set; }

    public int? UsuarioId { get; set; }

    public string Accion { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string? Detalles { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
