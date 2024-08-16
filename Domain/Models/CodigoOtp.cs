using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CodigoOtp
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string CodigoOtp1 { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaExpiracion { get; set; }

    public bool Verificado { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
