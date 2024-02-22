using Proyecto_Final_API_SDG.DTOs;
using Proyecto_Final_API_SDG.models;

namespace Proyecto_Final_API_SDG.Mapper
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

        public static VentaDTO MappearVtaToDto(Ventum venta)
        {
            VentaDTO dto = new VentaDTO();

            dto.Id = venta.Id;
            dto.Comentarios = venta.Comentarios;
            dto.IdUsuario = venta.IdUsuario;

            return dto;
        }
    }
}
