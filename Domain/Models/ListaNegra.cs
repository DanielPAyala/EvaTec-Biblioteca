using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ListaNegra
{
    public int ListaNegraId { get; set; }

    public int UsuarioId { get; set; }

    public string Motivo { get; set; } = null!;

    public DateTime FechaIngreso { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
