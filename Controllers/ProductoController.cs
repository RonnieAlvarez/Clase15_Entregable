using Clase15_Entregable.database;
using Clase15_Entregable.models;
using Clase15_Entregable.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Clase15_Entregable.Service;

namespace Clase15_Entregable.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductoController : Controller
    {
        private ProductoService productoService;
        public ProductoController(ProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HttpGet("obtenerProductoXId")]
        public ActionResult<Producto> obtenerProductoXId(int id)
        {
            if (id < 0) return BadRequest(new { message = $"El id no puede ser negativo ", StatusCode = 400 });
            var productoBuscado = productoService.ObtenerProductoXId(id);
            if (productoBuscado is null) return BadRequest(new { message = $"El Producto no existe ", StatusCode = 400 });
            else return productoBuscado;
        }

        [HttpGet("obtenerTodosLosProductos")]
        public ActionResult<List<Producto>> obtenerTodosLosProductos()
        {
            var resultado = productoService.ListarTodosLosProductos();

            if (resultado.Count > 0) return resultado;
            else return BadRequest(new { message = $"No existen productos en esta lista ", StatusCode = 400 });
        }

        [HttpDelete("BorrarProductoXId")]
        public ActionResult<Producto> BorrarProductoXId(int id)
        {
            if (id < 0) return BadRequest(new { message = $"El id no puede ser negativo ", StatusCode = 400 });
            var productoBuscado = productoService.ObtenerProductoXId(id);
            if (productoBuscado is null) return BadRequest(new { message = $"El Producto no existe ", StatusCode = 400 });
            productoService.EliminarProductoPorId(productoBuscado);
            return Ok(new { message = $"Producto {id} eliminado exitosamente", StatusCode = 200 });
        }

        
        [HttpPost("AgregarProducto")]
        public IActionResult AgregarProducto([FromBody] ProductoDTO productoDTO)
        {
            try
            {
                if (productoDTO is null) return BadRequest(new { message = $"El producto no puede estar vacio.", StatusCode = 400 });
                productoService.AgregarProductos(productoDTO);
                return Ok(new { message = $"Producto {productoDTO.Id} Agregado exitosamente", StatusCode = 200 });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = $"Producto no Agregado erro: {ex.Message} " });
            }
        }
        
        [HttpPut("ModificarProducto")]
        public ActionResult<ProductoDTO> ModificarProducto([FromBody] ProductoDTO productoDTO)
        {
            if (productoDTO is null) return BadRequest(new { message = $"El producto no puede estar vacio.", StatusCode = 400 });
            productoService.ModificarProducto(productoDTO);
            return Ok(new { message = $"Producto {productoDTO.Id} Modificado exitosamente", StatusCode = 200 });
        }


    }
}
