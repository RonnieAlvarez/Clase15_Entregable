using Proyecto_Final_API_SDG.DTOs;
using Proyecto_Final_API_SDG.models;

namespace Proyecto_Final_API_SDG.Mapper
{
    public static class ProductoMapper
    {
        public static Producto MappearDtoToProd(ProductoDTO dto)
        {
            Producto productoMapeado = new Producto();

            productoMapeado.Id = dto.Id;
            productoMapeado.Costo = dto.Costo;
            productoMapeado.Descripciones = dto.Descripciones;
            productoMapeado.PrecioVenta = dto.PrecioVenta;
            productoMapeado.Stock = dto.Stock;
            productoMapeado.IdUsuario = dto.IdUsuario;

            return productoMapeado;
        }

        public static ProductoDTO MappearProdToDto(Producto producto)
        {
            ProductoDTO dto = new ProductoDTO();

            dto.Id = producto.Id;
            dto.Costo = producto.Costo;
            dto.Descripciones = producto.Descripciones;
            dto.PrecioVenta = producto.PrecioVenta;
            dto.Stock = producto.Stock;
            dto.IdUsuario = producto.IdUsuario;

            return dto;
        }
    }
}
