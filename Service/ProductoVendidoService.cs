using Proyecto_Final_API_SDG.DTOs;
using Proyecto_Final_API_SDG.Mapper;
using Proyecto_Final_API_SDG.models;
using Proyecto_Final_API_SDG.database;

namespace Proyecto_Final_API_SDG.Service
{
    public class ProductoVendidoService
    {
        private CoderContext coderContext;

        public ProductoVendidoService(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        public List<ProductoVendido> ListarTodosLosProductosVendidos()
        {
            return coderContext.ProductoVendidos.ToList();
        }
       
        public List<ProductoVendido> ListarPVxIdProducto(int idProducto)
        {
            return coderContext.ProductoVendidos.Where(p => p.IdProducto == idProducto).ToList();
        }
        public List<ProductoVendidoDTO> ListarProductosVendidosXId(int idUsuario)
        {
            var productos = coderContext.Productos.ToList();
            var Productosfiltrados = productos.Where(u => u.IdUsuario == idUsuario).ToList();
            var productosVendidos = coderContext.ProductoVendidos.Where(p => p.IdVenta == idUsuario).ToList();

            var resultadoFinal = new List<ProductoVendidoDTO>();
            foreach (var item in productosVendidos)
            {
                resultadoFinal.Add(ProductoVendidoMapper.MapperPvToDto(item));
            }

            return resultadoFinal;
        }

        public ProductoVendido? ObtenerProductosVendidosXId(int id)
        {
            return coderContext.ProductoVendidos.FirstOrDefault(u => u.Id == id);
        }

        public bool EliminarProductoVendidoPorId(ProductoVendido productoVendido)
        {
            coderContext.ProductoVendidos.Remove(productoVendido);
            coderContext.SaveChanges();
            return true;
        }

        public bool AgregarProductosVendidos(ProductoVendidoDTO dto)
        {
            if (dto is null)
            {
                return false;
            }
            ProductoVendido productoVendido = ProductoVendidoMapper.MapperDtoToPV(dto);
            coderContext.ProductoVendidos.Add(productoVendido);
            coderContext.SaveChanges();
            return true;

        }

        public bool ModificarProductoVendido(ProductoVendidoDTO dto)
        {
            ProductoVendido productoV = ProductoVendidoMapper.MapperDtoToPV(dto);
            coderContext.ProductoVendidos.Update(productoV);
            coderContext.SaveChanges();
            return true;
        }
    }
}
