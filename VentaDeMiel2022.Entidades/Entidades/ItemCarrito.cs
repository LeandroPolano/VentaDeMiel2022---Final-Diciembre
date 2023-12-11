using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel2022.Entidades.Entidades
{
    public class ItemCarrito:ICloneable
    {
        [Key]
        public int ItemCarritoId { get; set; }
        public int MielEnvaseId { get; set; }
        public string NombreEnvase { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        //public decimal PrecioTotal => Cantidad * PrecioUnitario;

        public Envase MielEnvase { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();

        }

    }
}
