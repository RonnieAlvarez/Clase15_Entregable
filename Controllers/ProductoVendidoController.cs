using Proyecto_Final_API_SDG.DTOs;
using Proyecto_Final_API_SDG.models;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_API_SDG.Service;

namespace Proyecto_Final_API_SDG.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductoVendidoController : Controller
    {
        private ProductoVendidoService productoVendidoService;
        public ProductoVendidoController(ProductoVendidoService productoVendidoService)
        {
            this.productoVendidoService = productoVendidoService;
        }

        [HttpGet("ListarProductoVendidoXIdUsuario/{idUsuario:int}")]
        public ActionResult<List<ProductoVendidoDTO>> ListarProductoXId(int idUsuario)
        {
            if (idUsuario < 0) return BadRequest(new { message = $"El id no puede ser negativo ", StatusCode = 400 });
            List<ProductoVendidoDTO>? productoVBuscado = productoVendidoService.ListarProductosVendidosXId(idUsuario);
            if (productoVBuscado is null) return BadRequest(new { message = $"El Producto no existe ", StatusCode = 400 });
            else return productoVBuscado;
        }

        [HttpGet("ObtenerProductosVendidos")]
        public ActionResult<List<ProductoVendido>> ObtenerProductosVendidos()
        {
            var resultado = productoVendidoService.ListarTodosLosProductosVendidos();
            if (resultado.Count > 0 || resultado is not null) { return resultado; }
            else
                return BadRequest(new { message = $"No existen productos en esta lista ", StatusCode = 400 });
        }

    
    }
}
