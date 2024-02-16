using Clase15_Entregable.Service;
using Microsoft.AspNetCore.Mvc;
using Clase15_Entregable.DTOs;
using Clase15_Entregable.models;

namespace Clase15_Entregable.Controllers
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

        [HttpGet("ObtenerVentaVendidoXId/{id:int}")]
        public ActionResult<Ventum> ObtenerVentaXId(int id)
        {
            if (id < 0) return BadRequest(new { message = $"El id no puede ser negativo ", StatusCode = 400 });
            Ventum? productoVBuscado = ventaService.ObtenerVentaXId(id);
            if (productoVBuscado is null) return BadRequest(new { message = $"El Venta no existe ", StatusCode = 400 });
            else return productoVBuscado;
        }

        [HttpGet("ObtenerVentas")]
        public ActionResult<List<Ventum>> ObtenerVentas()
        {
            List<Ventum> resultado = new List<Ventum>();
            resultado = ventaService.ListarTodasLasVentas();
            if (resultado.Count > 0) { return resultado; }
            else
                return BadRequest(new { message = $"No existen ventas en esta lista ", StatusCode = 400 });
        }

        [HttpDelete("BorrarVentaVendidoXId")]
        public ActionResult<Ventum> BorrarVentaVendidoXId(int id)
        {
            if (id < 0) return BadRequest(new { message = $"El id no puede ser negativo ", StatusCode = 400 });
            var ventaBuscada = ventaService.ObtenerVentaXId(id);
            if (ventaBuscada is null) return BadRequest(new { message = $"El Venta no existe ", StatusCode = 400 });
            ventaService.EliminarVentaPorId(ventaBuscada);
            return Ok(new { message = $"Venta {id} eliminado exitosamente", StatusCode = 200 });

        }

        [HttpPost("AgregarVenta")]
        public ActionResult AgregarVenta([FromBody] VentaDTO ventaDto)
        {
            if (ventaDto == null)
            {
                return BadRequest("El campo 'Id venta' es obligatorio.");
            }
            ventaService.AgregarVenta(ventaDto);
            return Ok(new { message = $"Venta Vendido: {ventaDto.Id} agregado exitosamente" });
        }


        [HttpPut("ModificarVenta")]
        public ActionResult<VentaDTO> ModificarVenta([FromBody] VentaDTO ventaDto)
        {
            if (ventaDto is null) return BadRequest(new { message = $"La venta no puede estar vacia.", StatusCode = 400 });
            this.ventaService.ModificarVenta(ventaDto);
            return Ok(new { message = $"Venta {ventaDto.Id} Modificado exitosamente", StatusCode = 200 });
        }
    }
}
