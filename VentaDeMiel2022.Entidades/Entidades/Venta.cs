using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel2022.Entidades.Entidades
{
    public class Venta
    {
        public int VentaId { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public List<DetalleVenta> DetalleVentas { get; set; } 

        public Venta()
        {
            DetalleVentas = new List<DetalleVenta>();
        }

    }
}
