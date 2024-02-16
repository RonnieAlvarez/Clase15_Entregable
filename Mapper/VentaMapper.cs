using Clase15_Entregable.DTOs;
using Clase15_Entregable.models;

namespace Clase15_Entregable.Mapper
{
    public class VentaMapper
    {
        public static Ventum MappearDtoToVenta(VentaDTO dto)
        {
            Ventum VentaMapeada = new Ventum();

            VentaMapeada.Id = dto.Id;
            VentaMapeada.Comentarios = dto.Comentarios;
            VentaMapeada.IdUsuario = dto.IdUsuario;

            return VentaMapeada;
        }

        public static VentaDTO MappearProdToDto(Ventum venta)
        {
            VentaDTO dto = new VentaDTO();

            dto.Id = venta.Id;
            dto.Comentarios = venta.Comentarios;
            dto.IdUsuario = venta.IdUsuario;

            return dto;
        }
    }
}
