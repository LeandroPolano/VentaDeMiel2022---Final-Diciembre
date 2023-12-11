using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Datos.Repositorio
{
    public class RepositorioVentas : IRepositorioVentas
    {
        private readonly VentaDeMiel2022DbContext context;

        public RepositorioVentas(VentaDeMiel2022DbContext ventaDeMiel2022DbContext)
        {
            context = new VentaDeMiel2022DbContext();
        }
        public void AnularVenta(Venta venta)
        {
            try
            {
                context.Entry(venta).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Venta venta)
        {
            try
            {
                if (venta.VentaId == 0)
                {
                    return context.Ventas.Any(m => m.Total == venta.Total);
                }

                return context.Ventas.Any(m => m.Total == venta.Total
                                                   && m.VentaId != venta.VentaId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<VentaListDto> GetVentas()
        {
            return context.Ventas
                 .OrderBy(v => v.Fecha)
                 .Select(v => new VentaListDto
                 {
                     VentaId = v.VentaId,
                     Fecha = v.Fecha,
                     Total = v.Total
                 }).ToList();
        }

       
        public void Guardar(Venta venta)
        {
            try
            {
                context.Ventas.Add(venta);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
