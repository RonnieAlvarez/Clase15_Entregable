using Microsoft.AspNetCore.Mvc;

namespace Clase15_Entregable.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class NombreController : Controller
    {
        [HttpGet]
        public string ObtenerNombre()
        {
            return "Ronnie";
        }
    }
}
