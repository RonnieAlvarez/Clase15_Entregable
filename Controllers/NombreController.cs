using Clase15_Entregable.Service;
using Microsoft.AspNetCore.Mvc;

namespace Clase15_Entregable.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class NombreController : Controller
    {
        [HttpGet("Nombre")]
        public string ObtenerNombre()
        {
            return "Ronnie";
        }
        [HttpGet("UsuarioClave")]
        public string UsuarioClave ()
        {
            return "Usuario: Ronnie\nClave: 1234";
        }
    }
}
