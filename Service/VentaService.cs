using Clase15_Entregable.database;
using Clase15_Entregable.DTOs;
using Clase15_Entregable.Mapper;
using Clase15_Entregable.models;

namespace Clase15_Entregable.Service
{
    public class VentaService
    {
        private CoderContext coderContext;

        public VentaService(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

        public List<Ventum> ListarTodasLasVentas()
        {
            return coderContext.Venta.ToList();
        }

        public Ventum? ObtenerVentaXId(int id)
        {
            return coderContext.Venta.FirstOrDefault(u => u.Id == id);
        }
 
        public bool EliminarVentaPorId(Ventum venta)
        {
            coderContext.Venta.Remove(venta);
            coderContext.SaveChanges();
            return true;
        }

        public bool AgregarVenta(VentaDTO dto)
        {
            if (dto is null)
            {
                return false;
            }
            Ventum venta = VentaMapper.MappearDtoToVenta(dto);
            coderContext.Venta.Add(venta);
            coderContext.SaveChanges();
            return true;

        }

        public bool ModificarVenta(VentaDTO dto)
        {
            Ventum venta = VentaMapper.MappearDtoToVenta(dto);
            coderContext.Venta.Update(venta);
            coderContext.SaveChanges();
            return true;
        }
    }
}
