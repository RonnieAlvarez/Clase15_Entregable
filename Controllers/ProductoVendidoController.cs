using Clase15_Entregable.DTOs;
using Clase15_Entregable.models;
using Clase15_Entregable.Service;
using Microsoft.AspNetCore.Mvc;

namespace Clase15_Entregable.Controllers
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

        [HttpGet("ObtenerProductoVendidoXId/{id:int}")]
        public ActionResult<ProductoVendido> ObtenerProductoXId(int id)
        {
            if (id < 0) return BadRequest(new { message = $"El id no puede ser negativo ", StatusCode = 400 });
            ProductoVendido? productoVBuscado = productoVendidoService.ObtenerProductosVendidosXId(id);
            if (productoVBuscado is null) return BadRequest(new { message = $"El Producto no existe ", StatusCode = 400 });
            else return productoVBuscado;
        }

        [HttpGet("ObtenerProductosVendidos")]
        public ActionResult<List<ProductoVendido>> ObtenerProductosVendidos()
        {
            List<ProductoVendido> resultado = new List<ProductoVendido>();
            resultado = productoVendidoService.ListarTodosLosProductosVendidos();
            if (resultado.Count > 0) { return resultado; }
            else
                return BadRequest(new { message = $"No existen productos en esta lista ", StatusCode = 400 });
        }

        [HttpDelete("BorrarProductoVendidoXId")]
        public ActionResult<ProductoVendido> BorrarProductoVendidoXId(int id)
        {
            if (id < 0) return BadRequest(new { message = $"El id no puede ser negativo ", StatusCode = 400 });
            var productoVBuscado = productoVendidoService.ObtenerProductosVendidosXId(id);
            if (productoVBuscado is null) return BadRequest(new { message = $"El Producto no existe ", StatusCode = 400 });
            productoVendidoService.EliminarProductoVendidoPorId(productoVBuscado);
            return Ok(new { message = $"Producto {id} eliminado exitosamente", StatusCode = 200 });

        }
      
        [HttpPost("AgregarProductoVendido")]
        public ActionResult AgregarProductoVendido([FromBody] ProductoVendidoDTO productoVDto)
        {
            if (productoVDto == null)
            {
                return BadRequest("El campo 'Id productoVendido' es obligatorio.");
            }
            productoVendidoService.AgregarProductosVendidos(productoVDto);
            return Ok(new { message = $"Producto Vendido: {productoVDto.IdProducto } agregado exitosamente" });
        }


        [HttpPut("ModificarProductoVendido")]
        public ActionResult<ProductoVendidoDTO> ModificarProductoVendido([FromBody] ProductoVendidoDTO productoVDto)
        {
            if (productoVDto is null) return BadRequest(new { message = $"El producto vendido no puede estar vacio.", StatusCode = 400 });
            this.productoVendidoService.ModificarProductoVendido(productoVDto);
            return Ok(new { message = $"Producto {productoVDto.Id} Modificado exitosamente", StatusCode = 200 });
        }
    }
}
