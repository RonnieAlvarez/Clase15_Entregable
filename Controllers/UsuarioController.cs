using Proyecto_Final_API_SDG.database;
using Proyecto_Final_API_SDG.models;
using Proyecto_Final_API_SDG.DTOs;
using Proyecto_Final_API_SDG.Service;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_API_SDG.Mapper;
using Microsoft.AspNetCore.Http;

namespace Proyecto_Final_API_SDG.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        private UsuarioService usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet("obtenerUsuarioXId")]
        public ActionResult<Usuario> obtenerUsuarioXId(int id)
        {
            if (id < 0) return BadRequest(new { message = $"El id no puede ser negativo ", StatusCode = 400 });
            var usuarioBuscado = usuarioService.ObtenerUsuarioXId(id);
            if (usuarioBuscado is null) return BadRequest(new { message = $"El Usuario no existe ", StatusCode = 400 });
            else return usuarioBuscado;
        }

        [HttpGet("obtenerUsuarioXNommbreUsuario/{nombreUsuario}")]
        public ActionResult<Usuario?> obtenerUsuarioXNombreUsuario(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario)) return BadRequest(new { message = $"El Nombre Usuario no puede estar vacio ", StatusCode = 400 });
            var usuarioBuscado = usuarioService.ObtenerUsuarioXNombreUsuario(nombreUsuario);
            if (usuarioBuscado is null) return BadRequest(new { message = $"El Usuario no existe ", StatusCode = 400 });
            else return usuarioBuscado;
        }

        [HttpGet("obtenerUsuarioXUsuarioClave/{nombreUsuario}/{contrasena}")]
        public ActionResult<Usuario?> obtenerUsuarioXUsuarioClave(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena)) return BadRequest(new { message = $"Los datos no pueden estar vacios ", StatusCode = 400 });
            try
            {
                return  usuarioService.ObtenerUsuarioXUsuarioClave(nombreUsuario, contrasena);
            }
            catch
            {
                return BadRequest(new { message = $"El Usuario no existe ", StatusCode = 400 });
            }
        }
        [HttpGet("obtenerTodosLosUsuarios")]
        public ActionResult<List<Usuario>> obtenerTodosLosUsuarios()
        {
            var resultado = usuarioService.ObtenerTodosLosUsuarios();
            if (resultado.Count > 0)  return resultado; 
            else  return BadRequest(new { message = $"No existen usuarios en esta lista ", StatusCode = 400 });
        }

        [HttpDelete("BorrarUsuarioXId")]
        public ActionResult<Usuario> BorrarUsuarioXId(int id)
        {
            if (id < 0) return BadRequest(new { message = $"El id no puede ser negativo ", StatusCode = 400 });
            var usuarioBuscado = usuarioService.ObtenerUsuarioXId(id);
            if (usuarioBuscado is null) return BadRequest(new { message = $"El Usuario no existe ", StatusCode = 400 });
            usuarioService.EliminarUsuarioPorId(usuarioBuscado);
            return Ok(new { message = $"Usuario {id} eliminado exitosamente", StatusCode = 200 });
        }

        [HttpPost("AgregarUsuario")]
        public ActionResult<UsuarioDTO> AgregarUsuario([FromBody] UsuarioDTO usuarioDto)
        {
            if (usuarioDto is null) return BadRequest(new { message = $"El usuario no puede estar vacio.", StatusCode = 400 });
            Usuario usuario = UsuarioMapper.MappearDtoToUser(usuarioDto);
            usuarioService.AgregarUsuario(usuario);
            return Ok(new { message = $"Usuario {usuario.Id} Agregado exitosamente", StatusCode = 200 });

        }

        [HttpPut("ModificarUsuario")]
        public ActionResult<UsuarioDTO> ModificarUsuario([FromBody] UsuarioDTO usuarioDto)
        {
            if (usuarioDto is null) return BadRequest(new { message = $"El usuario no puede estar vacio.", StatusCode = 400 });
            Usuario usuario = UsuarioMapper.MappearDtoToUser(usuarioDto);
            usuarioService.ModificarUsuario(usuario);
            return Ok(new { message = $"Usuario {usuario.Id} Modificado exitosamente", StatusCode = 200 });
        }
    }
}
