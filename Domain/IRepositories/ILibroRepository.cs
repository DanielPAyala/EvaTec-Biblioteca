﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface ILibroRepository
    {
        Task<Libro> GetLibroById(int libroId);
    }
}
