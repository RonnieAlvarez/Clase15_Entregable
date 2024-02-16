using Clase15_Entregable.database;
using Clase15_Entregable.models;

namespace Clase15_Entregable.Service
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
    }
}
