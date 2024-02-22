using Proyecto_Final_API_SDG.DTOs;
using Proyecto_Final_API_SDG.models;

namespace Proyecto_Final_API_SDG.Mapper
{
    public static class UsuarioMapper
    {
        public static Usuario MappearDtoToUser(UsuarioDTO dto)
        {
            Usuario UsuarioMapeado = new Usuario();
          
            UsuarioMapeado.Id = dto.Id;
            UsuarioMapeado.Nombre = dto.Nombre;
            UsuarioMapeado.Apellido = dto.Apellido;
            UsuarioMapeado.NombreUsuario = dto.NombreUsuario;
            UsuarioMapeado.Contraseña = dto.Contraseña;
            UsuarioMapeado.Mail = dto.Mail;

            return UsuarioMapeado;
        }

        public static UsuarioDTO MappearProdToDto(Usuario usuario)
        {
            UsuarioDTO dto = new UsuarioDTO();

            dto.Id = usuario.Id;
            dto.Nombre = usuario.Nombre;
            dto.Apellido = usuario.Apellido;
            dto.NombreUsuario = usuario.NombreUsuario;
            dto.Contraseña = usuario.Contraseña;
            dto.Mail = usuario.Mail;

            return dto;
        }
    }
}
