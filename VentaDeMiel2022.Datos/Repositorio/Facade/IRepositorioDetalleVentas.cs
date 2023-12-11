using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Datos.Repositorio.Facade
{
    public interface IRepositorioDetalleVentas
    {
        void Guardar(DetalleVenta detalleVenta);
        List<DetalleVenta> GetDetalleVenta(int ventaId);
    }
}
