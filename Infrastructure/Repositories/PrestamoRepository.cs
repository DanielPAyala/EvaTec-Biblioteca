using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly BibliotecaContext _context;
        public PrestamoRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public void SolicitudPrestamo(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            _context.SaveChanges();
        }
    }
}
