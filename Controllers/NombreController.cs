using Proyecto_Final_API_SDG.Service;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Final_API_SDG.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class NombreController : Controller
    {
        [HttpGet("Nombre")]
        public string ObtenerNombre()
        {
            return "Ronnie Alvarez";
        }
    }
}
