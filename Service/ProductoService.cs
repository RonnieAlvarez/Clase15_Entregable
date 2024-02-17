using Clase15_Entregable.database;
using Clase15_Entregable.DTOs;
using Clase15_Entregable.Mapper;
using Clase15_Entregable.models;
using System.Diagnostics.Eventing.Reader;

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

        public Producto ObtenerProductoXId(int id)
        {
            var resultado = coderContext.Productos.FirstOrDefault(u => u.Id == id);
            if (resultado == null) 
                return resultado = new Producto();
            else
                    return resultado;
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
