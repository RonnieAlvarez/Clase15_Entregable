using Proyecto_Final_API_SDG.DTOs;
using Proyecto_Final_API_SDG.Mapper;
using Proyecto_Final_API_SDG.models;
using Proyecto_Final_API_SDG.database;
using Proyecto_Final_API_SDG.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Final_API_SDG.Service
{
    public class VentaService
    {
        private CoderContext coderContext;
     
        public VentaService(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        private List<Ventum> ListarTodasLasVentas()
        {
            return coderContext.Venta.ToList();
        }

        public List<VentaDTO> ObtenerVentaXIdUsuario(int id)
        {
            var lista = ListarTodasLasVentas();
            List<VentaDTO> listadoxID = new List<VentaDTO>();
            foreach (var item in lista)
            {
                if (item.IdUsuario == id)
                {
                    VentaDTO venta = VentaMapper.MappearVtaToDto(item);
                    listadoxID.Add(venta);
                }
            }
            return listadoxID;
        }
    
        public ActionResult<bool> AgregarNuevaVenta(int idUsuario, List<ProductoDTO> productos)
        {
            foreach (var item in productos)
            {
                VentaDTO venta = new VentaDTO();
                venta.Comentarios = "Venta realizado por: " + idUsuario.ToString();
                venta.IdUsuario = idUsuario;
                Ventum auxVentaMapeada = VentaMapper.MappearDtoToVenta(venta);
                coderContext.Venta.Add(auxVentaMapeada);
                coderContext.SaveChanges();
                coderContext.Venta.AsTracking();
                int ventaId = auxVentaMapeada.Id;
                RegistrarProductosVendidos(item, ventaId);
                
                ActualizaStockProductosVendidos(item);
            }
            return true;
        }

        private bool ActualizaStockProductosVendidos(ProductoDTO productos)
        {
            //https://learn.microsoft.com/es-es/ef/core/querying/tracking
            Producto productoActual = coderContext.Productos.AsNoTracking().First(pa=>pa.Id==productos.Id);
            ProductoDTO productoDTO = ProductoMapper.MappearProdToDto(productoActual);
            productoDTO.Stock = productoActual.Stock - productos.Stock;

            Producto producto = ProductoMapper.MappearDtoToProd(productoDTO);
            
            coderContext.Productos.Update(producto);
            coderContext.SaveChanges();
            //productoService.ModificarProducto(productoDTO);


            //  });
            return true;
        }

        private bool RegistrarProductosVendidos(ProductoDTO producto, int idVenta)
        {

            ProductoVendidoDTO productoVendidoDTO = new ProductoVendidoDTO();
            productoVendidoDTO.IdProducto = producto.Id;
            productoVendidoDTO.IdVenta = idVenta;
            productoVendidoDTO.Stock = producto.Stock;

            ProductoVendido productoVendido = ProductoVendidoMapper.MapperDtoToPV(productoVendidoDTO);
            coderContext.ProductoVendidos.Add(productoVendido);
            coderContext.SaveChanges();

            return true;
        }

            //private bool RegistrarProductosVendidos(List<ProductoDTO> productos, int idVenta)
            //{
            //    productos.ForEach(p =>
            //    {
            //        ProductoVendidoDTO productoVendidoDTO = new ProductoVendidoDTO();
            //        productoVendidoDTO.IdProducto = p.Id;
            //        productoVendidoDTO.IdVenta = idVenta;
            //        productoVendidoDTO.Stock = p.Stock;

            //        ProductoVendido productoVendido = ProductoVendidoMapper.MapperDtoToPV(productoVendidoDTO);
            //        coderContext.ProductoVendidos.Add(productoVendido);
            //        coderContext.SaveChanges();
            //    });
            //    return true;


            //}
    }
}
