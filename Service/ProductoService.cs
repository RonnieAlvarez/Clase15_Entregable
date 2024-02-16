using Clase15_Entregable.database;
using Clase15_Entregable.DTOs;
using Clase15_Entregable.Mapper;
using Clase15_Entregable.models;

namespace Clase15_Entregable.Service
{
    public class ProductoService
    {
        private CoderContext coderContext;

        public ProductoService(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        public List<Producto> ListarTodosLosProductos()
        {
            return coderContext.Productos.ToList();
        }

        public Producto? ObtenerProductoXId(int id)
        {
            return coderContext.Productos.FirstOrDefault(u => u.Id == id);
        }

        public bool EliminarProductoPorId(Producto producto)
        {
            coderContext.Productos.Remove(producto);
            coderContext.SaveChanges();
            return true;
        }

        public bool AgregarProductos(ProductoDTO dto)
        {
            if (dto is null)
            {
                return false;
            }
            Producto producto = ProductoMapper.MappearDtoToProd(dto);
            coderContext.Productos.Add(producto);
            coderContext.SaveChanges();
            return true;
            
        }

        public bool ModificarProducto(ProductoDTO dto)
        {
            Producto producto = ProductoMapper.MappearDtoToProd(dto);
            coderContext.Productos.Update(producto);
            coderContext.SaveChanges();
            return true;
        }
    }
}
