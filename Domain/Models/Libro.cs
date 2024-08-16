using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Libro
{
    public int LibroId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public int CategoriaId { get; set; }

    public string? Descripcion { get; set; }

    public string? CodigoBarras { get; set; }

    public decimal ValorReferencial { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Categorium Categoria { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
