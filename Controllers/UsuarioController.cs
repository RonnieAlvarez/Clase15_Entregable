using Clase15_Entregable.database;
using Clase15_Entregable.models;
using Clase15_Entregable.DTOs;
using Clase15_Entregable.Service;
using Microsoft.AspNetCore.Mvc;
using Clase15_Entregable.Mapper;

namespace Clase15_Entregable.Controllers
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
