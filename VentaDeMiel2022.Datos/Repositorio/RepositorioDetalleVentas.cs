using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Datos.Repositorio
{
    public class RepositorioDetalleVentas : IRepositorioDetalleVentas
    {
        private readonly VentaDeMiel2022DbContext context;
        public RepositorioDetalleVentas(VentaDeMiel2022DbContext context)
        {
            this.context = context;
        }
        public List<DetalleVenta> GetDetalleVenta(int ventaId)
        {
            try
            {
                return context.DetalleVentas
                    .Where(dt => dt.VentaId == ventaId)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(DetalleVenta detalleVenta)
        {
            try
            {
                context.DetalleVentas.Add(detalleVenta);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
