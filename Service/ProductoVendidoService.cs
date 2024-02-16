using Clase15_Entregable.database;
using Clase15_Entregable.DTOs;
using Clase15_Entregable.Mapper;
using Clase15_Entregable.models;

namespace Clase15_Entregable.Service
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
