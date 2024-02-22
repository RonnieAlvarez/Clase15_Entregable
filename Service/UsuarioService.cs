using Proyecto_Final_API_SDG.models;
using Proyecto_Final_API_SDG.database;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_API_SDG.DTOs;

namespace Proyecto_Final_API_SDG.Service
{
    public class UsuarioService
    {
        private CoderContext coderContext;

        public UsuarioService(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }
        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return coderContext.Usuarios.ToList();
        }
        public Usuario? ObtenerUsuarioXId(int id)
        {
            return coderContext.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public bool EliminarUsuarioPorId(Usuario usuario)
        {
            coderContext.Usuarios.Remove(usuario);
            coderContext.SaveChanges();
            return true;
        }

        public bool AgregarUsuario(Usuario usuario)
        {
            coderContext.Usuarios.Add(usuario);
            coderContext.SaveChanges();
            return true;
        }

        public bool ModificarUsuario(Usuario usuario)
        {
            coderContext.Usuarios.Update(usuario);
            coderContext.SaveChanges();
            return true;
        }

        public ActionResult<Usuario?> ObtenerUsuarioXNombreUsuario(string nombreUsuario)
        {
            return coderContext.Usuarios.FirstOrDefault(u => u.NombreUsuario.Equals(nombreUsuario));
        }

        internal ActionResult<Usuario?> ObtenerUsuarioXUsuarioClave(string usuario, string clave)
        {
            return coderContext.Usuarios.FirstOrDefault(u=>u.NombreUsuario.Equals(usuario)&&u.Contraseña.Equals(clave));
        }
    }
}
