using Clase15_Entregable.DTOs;
using Clase15_Entregable.models;

namespace Clase15_Entregable.Mapper
{
    public static class ProductoVendidoMapper
    {
        public static ProductoVendido MapperDtoToPV(ProductoVendidoDTO dTO)
        {
             ProductoVendido productoVendido = new ProductoVendido();

            productoVendido.Id=dTO.Id;
            productoVendido.Stock = dTO.Stock;
            productoVendido.IdProducto = dTO.IdProducto;
            productoVendido.IdVenta = dTO.IdVenta;

            return productoVendido;
        }

        public static ProductoVendidoDTO MapperPvToDto(ProductoVendido productoVendido)
        {
            ProductoVendidoDTO dTO = new ProductoVendidoDTO();

            dTO.Id = productoVendido.Id;
            dTO.Stock = productoVendido.Stock;
            dTO.IdProducto = productoVendido.IdProducto;
            dTO.IdVenta = productoVendido.IdVenta;

            return dTO;
        }

    }
}
