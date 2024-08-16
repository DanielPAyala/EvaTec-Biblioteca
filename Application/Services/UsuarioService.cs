using Application.IServices;
using Domain.IRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> GetUsuarioById(int usuarioId)
        {
            return await _usuarioRepository.GetUsuarioById(usuarioId);
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await _usuarioRepository.GetUsuarios();
        }
    }
}
