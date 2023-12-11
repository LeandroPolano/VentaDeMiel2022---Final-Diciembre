using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel2022.Entidades.Entidades
{
    public class DetalleVenta:ICloneable

    {
    public int DetalleVentaId { get; set; }
    public int VentaId { get; set; }
    public int ClienteId { get; set; }
    public int TipoEnvaseId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioVenta { get; set; }
 
    public Cliente Cliente { get; set; }
    public Venta Venta { get; set; }
    public Envase TipoEnvase { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
    }
}
