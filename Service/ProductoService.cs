using Proyecto_Final_API_SDG.DTOs;
using Proyecto_Final_API_SDG.Mapper;
using Proyecto_Final_API_SDG.models;
using Proyecto_Final_API_SDG.database;
using System.Diagnostics.Eventing.Reader;

namespace Proyecto_Final_API_SDG.Service
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

        public List<ProductoDTO> ObtenerProductoXIdUsuario(int id)
        {
            var lista = coderContext.Productos.ToList();
            List<ProductoDTO> listadoxID = new List<ProductoDTO>();
            foreach (var item in lista)
            {
                if (item.IdUsuario == id)
                {
                    ProductoDTO lProducto = ProductoMapper.MappearProdToDto(item);
                    listadoxID.Add(lProducto);
                }
            }
                return listadoxID;
        }

        public bool EliminarProductoPorId(int id)
        {
            Producto? resultado = coderContext.Productos.FirstOrDefault(u => u.Id == id);
            if (resultado == null) return false;
            coderContext.Productos.Remove(resultado);
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
