using Proyecto_Final_API_SDG.Service;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_API_SDG.DTOs;
using Proyecto_Final_API_SDG.models;

namespace Proyecto_Final_API_SDG.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class VentaController : Controller
    {
        private VentaService ventaService;
        public VentaController(VentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        [HttpGet("ObtenerVentaXIdUsuario/{id:int}")]
        public ActionResult<List<VentaDTO>> ObtenerVentaXIdUsuario(int id)
        {
            if (id < 0) return BadRequest(new { message = $"El id no puede ser negativo ", StatusCode = 400 });
            List<VentaDTO> productoVBuscado = ventaService.ObtenerVentaXIdUsuario(id);
            if (productoVBuscado is null) return BadRequest(new { message = $"El Venta no existe ", StatusCode = 400 });
            else return productoVBuscado;
        }

     
        [HttpPost("CrearVenta")]
        public ActionResult CrearVenta(int idUsuario, [FromBody] List<ProductoDTO> productos)
        { 
            
            if (productos.Count == 0) return BadRequest("La lista de Productos esta vacia");
            try
            {
                var result = ventaService.AgregarNuevaVenta(idUsuario, productos);
                return Ok(result);
            }
            catch { return BadRequest("Fallo la creación de la venta."); };
            }

     
    }
}
