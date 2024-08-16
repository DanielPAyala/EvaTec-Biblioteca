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
    public class LibroRepository : ILibroRepository
    {
        private readonly BibliotecaContext _context;
        public LibroRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<Libro> GetLibroById(int libroId)
        {
            return await _context.Libros.FindAsync(libroId);
        }
    }
}
