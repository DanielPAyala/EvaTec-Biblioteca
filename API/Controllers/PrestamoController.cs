using API.DTOs;
using Application.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;
        private readonly ILibroService _libroService;
        private readonly IUsuarioService _usuarioService;

        public PrestamoController(IPrestamoService prestamoService, ILibroService libroService, IUsuarioService usuarioService)
        {
            _prestamoService = prestamoService;
            _libroService = libroService;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PrestamoDTO prestamoDto)
        {
            var prestamo = new Prestamo
            {
                UsuarioId = prestamoDto.UsuarioId,
                LibroId = prestamoDto.LibroId,
                FechaSolicitud = prestamoDto.FechaSolicitud,
                FechaPrestamo = prestamoDto.FechaPrestamo,
                FechaDevolucion = prestamoDto.FechaDevolucion,
                Estado = prestamoDto.Estado,
                Usuario = await _usuarioService.GetUsuarioById(prestamoDto.UsuarioId),
                Libro = await _libroService.GetLibroById(prestamoDto.LibroId)
            };

            if (prestamo.Usuario is null || prestamo.Libro is null)
            {
                return BadRequest("Usuario o libro no encontrado");
            }

            _prestamoService.PrestamoSolicutud(prestamo);
            // return NoContent();
            return Ok("Solicitud recibidad");
        }
    }
}
