using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Servicio.Servicios.Facades
{
    public interface IServicioVentas
    {

        List<VentaListDto> GetVentas();
        void Guardar(Venta venta);
        bool Existe(Venta venta);
        //List<DetalleVenta> GetDetalleVenta(int ventaVentaId);


    }
}
